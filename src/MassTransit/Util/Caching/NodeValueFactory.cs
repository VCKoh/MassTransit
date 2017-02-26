﻿namespace MassTransit.Util.Caching
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;


    /// <summary>
    /// A factory for a node which keeps track of subsequent attempts to create the
    /// same node, passing through until a valid node is created.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class NodeValueFactory<TValue> :
        INodeValueFactory<TValue>
        where TValue : class
    {
        readonly BlockingCollection<IPendingValue<TValue>> _pendingCollection;
        readonly int _timeout;
        readonly TaskCompletionSource<TValue> _value;

        /// <summary>
        /// Creates a node value factory, with the inital pending value
        /// </summary>
        /// <param name="initialPendingValue">The value that brought the node to the cache</param>
        /// <param name="timeoutInMilliseconds">The timeout to wait for additional factories before faulting</param>
        public NodeValueFactory(IPendingValue<TValue> initialPendingValue, int timeoutInMilliseconds)
        {
            _timeout = timeoutInMilliseconds;

            _pendingCollection = new BlockingCollection<IPendingValue<TValue>>();

            _value = new TaskCompletionSource<TValue>();

            _pendingCollection.Add(initialPendingValue);
        }

        public Task<TValue> Value => _value.Task;

        public void Add(IPendingValue<TValue> pendingValue)
        {
            if (_value.Task.Status != TaskStatus.WaitingForActivation)
            {
                pendingValue.SetValue(_value.Task);
            }
            else
            {
                _pendingCollection.Add(pendingValue);
            }
        }

        public async Task<TValue> CreateValue()
        {
            Exception lastException = null;

            try
            {
                IPendingValue<TValue> pendingValue;
                while (_pendingCollection.TryTake(out pendingValue, _timeout))
                {
                    try
                    {
                        var value = await pendingValue.CreateValue().ConfigureAwait(false);

                        _value.TrySetResult(value);

                        CompletePendingValues();

                        return value;
                    }
                    catch (Exception exception)
                    {
                        lastException = exception;
                    }
                }
            }
            finally
            {
                _pendingCollection.Dispose();
            }

            var createException = new ValueFactoryException($"Value factory faulted: {lastException?.Message ?? ""}", lastException);

            _value.TrySetException(createException);

            throw createException;
        }

        void CompletePendingValues()
        {
            IPendingValue<TValue> pendingValue;
            while (_pendingCollection.TryTake(out pendingValue, _timeout))
            {
                pendingValue.SetValue(_value.Task);
            }

            _pendingCollection.CompleteAdding();
        }
    }
}