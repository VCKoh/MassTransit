(window.webpackJsonp=window.webpackJsonp||[]).push([[39],{430:function(t,s,a){"use strict";a.r(s);var e=a(0),n=Object(e.a)({},(function(){var t=this,s=t.$createElement,a=t._self._c||s;return a("ContentSlotsDistributor",{attrs:{"slot-key":t.$parent.slotKey}},[a("h1",{attrs:{id:"rabbitmq-scheduler"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#rabbitmq-scheduler"}},[t._v("#")]),t._v(" RabbitMQ Scheduler")]),t._v(" "),a("p",[t._v("RabbitMQ has no native support for deferred dispatch. However, the community has developed a plugin that makes such functionality possible, enabling native support for message scheduling for RabbitMQ.")]),t._v(" "),a("p",[t._v("This plugin is still considered as experimental. It is supported by MassTransit, but we cannot guarantee anything more than the plugin guarantees itself. Please read the message on the plugin "),a("a",{attrs:{href:"https://github.com/rabbitmq/rabbitmq-delayed-message-exchange/",target:"_blank",rel:"noopener noreferrer"}},[t._v("project home page"),a("OutboundLink")],1),t._v(" to get full understanding of the current status and limitations.")]),t._v(" "),a("p",[t._v("The plugin is not included in the RabbitMQ distribution. Please follow the instructions on the "),a("a",{attrs:{href:"https://github.com/rabbitmq/rabbitmq-delayed-message-exchange/",target:"_blank",rel:"noopener noreferrer"}},[t._v("project wiki"),a("OutboundLink")],1),t._v(" to install it.")]),t._v(" "),a("h3",{attrs:{id:"scheduling-messages"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#scheduling-messages"}},[t._v("#")]),t._v(" Scheduling messages")]),t._v(" "),a("p",[t._v("You can use the delayed exchange to scheduled messages instead of Quartz. To enable this, you need to configure your bus properly:")]),t._v(" "),a("div",{staticClass:"language-csharp extra-class"},[a("pre",{pre:!0,attrs:{class:"language-csharp"}},[a("code",[a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("var")]),t._v(" busControl "),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("=")]),t._v(" Bus"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),t._v("Factory"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("CreateUsingRabbitMq")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),t._v("cfg "),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("=>")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n    cfg"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("UseDelayedExchangeMessageScheduler")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n\n    "),a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("var")]),t._v(" host "),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("=")]),t._v(" cfg"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("Host")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("new")]),t._v(" "),a("span",{pre:!0,attrs:{class:"token class-name"}},[t._v("Uri")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token string"}},[t._v('"rabbitmq://localhost/"')]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(",")]),t._v(" h "),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("=>")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n        h"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("Username")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token string"}},[t._v('"guest"')]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n        h"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("Password")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token string"}},[t._v('"guest"')]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),t._v("\n")])])]),a("p",[a("strong",[t._v("Important:")]),t._v(" there is no support for unscheduling messages that are scheduled with the delayed exchange.")]),t._v(" "),a("h3",{attrs:{id:"redelivery"}},[a("a",{staticClass:"header-anchor",attrs:{href:"#redelivery"}},[t._v("#")]),t._v(" Redelivery")]),t._v(" "),a("p",[t._v("You also can use the delayed exchange to implement message redelivery (second-level retries). All you need to do is to call the "),a("code",[t._v("context.Defer(TimeSpan delay)")]),t._v(" method in your consumer.")]),t._v(" "),a("div",{staticClass:"language-csharp extra-class"},[a("pre",{pre:!0,attrs:{class:"language-csharp"}},[a("code",[a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("public")]),t._v(" "),a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("async")]),t._v(" "),a("span",{pre:!0,attrs:{class:"token class-name"}},[t._v("Task")]),t._v(" "),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("Consume")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),t._v("ConsumeContext"),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v("<")]),t._v("MyMessage"),a("span",{pre:!0,attrs:{class:"token operator"}},[t._v(">")]),t._v(" context"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("try")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n        "),a("span",{pre:!0,attrs:{class:"token comment"}},[t._v("// process message")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token keyword"}},[t._v("catch")]),t._v(" "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token class-name"}},[t._v("MyTemporaryException")]),t._v(" e"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("{")]),t._v("\n        "),a("span",{pre:!0,attrs:{class:"token comment"}},[t._v("// we will try again later")]),t._v("\n        context"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("Defer")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),t._v("TimeSpan"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(".")]),a("span",{pre:!0,attrs:{class:"token function"}},[t._v("FromSeconds")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("(")]),a("span",{pre:!0,attrs:{class:"token number"}},[t._v("10")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(")")]),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v(";")]),t._v("\n    "),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),t._v("\n"),a("span",{pre:!0,attrs:{class:"token punctuation"}},[t._v("}")]),t._v("\n")])])]),a("p",[t._v("Read more about message redelivery in "),a("a",{attrs:{href:"redeliver"}},[t._v("Redelivering messages")])])])}),[],!1,null,null,null);s.default=n.exports}}]);