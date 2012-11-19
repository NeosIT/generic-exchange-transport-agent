NeosIT Generic Exchange Transport Agent
=============================================
It is possible to extend the default behavior of Microsoft Exchange Server 2007/2010 on occuring events by writing so-called "Transport Agents", e.g. extract all attachments of an incoming E-Mail sent by a specified address (let's say "alice@example.com") or with a specified subject (just a very basic example).

In order to do so, you need to write your own Transport Agent (derived from either DeliveryAgent, RoutingAgent or SmtpReceiveAgent), implement your desired logic as an event handler and write an AgentFactory (derived from either DeliveryAgentFactory<Manager>, RoutingAgentFactory or SmtpReceiveAgentFactory) returning your new Transport Agent. Finally you need to register and enable this Transport Agent (or better: its Factory) in your Exchange Server.

Sounds pretty easy and common, so why this project? Because most of the time, you will find yourself writing the same code over and over again, with just a few changes. For example, if you additionally need to extract the attachments of incoming E-Mails by "bob@example.com", you could either do one of the following:

- Just change some hard-coded strings in your existing Transport Agent (from "alice" to "bob"), register and enable the (almost) same Transport Agent.
- Better than the first one, you could try to export your filter value to some external config file, e.g. app.config or something else. You still need to register and enable the (almost) same Transport Agent.
- Make your existing Transport Agent handle both situations by enhancing your filter logic to handle both E-Mail addresses.

These are just a few examples off the top of my head, but there are definitely more...

What this project offers is some base to develop, use, and configure your Transport Agents in an easy way by splitting up basic parts into handlers and filters.

Handlers: The action(s) to perform
----------------------------------
Handlers contain the actual logic. Whether you need to extract attachments, execute some command (perhaps on the exported eml file) or add a disclaimer to all outgoing E-Mails, these actions are all performed by individual handlers.

Handlers can be configured individually, so you can, for example, extract the attachments of E-Mails sent by "alice@example.com" to "\\\\{storage}\\mails\\incoming\\from\\alice" and those by "bob@example.com" to "\\\\{storage}\\mails\\incoming\\from\\bob" (or elsewhere).

Filters: The easy way to make decisions
---------------------------------------
Filters are used when you want some action to be performed on some conditions. In the example above, catching up all E-Mails sent by "alice@example.com" will result in a filter like "FROM equals alice@example.com".

We have some predefined filter attributes and operators to make things simple. Feel free to implement your own.

Predefined filter attributes are: From, To, Subject and LastExitCode.

Predefined filter operators are: Equals, NotEquals, StartsWith, EndsWith, Contains and Regex.

Plugins: An easy mechanism to deploy new handlers
----------------------------------------------
By using the Managed Extensibility Framework (MEF, http://mef.codeplex.com/) you do not need to worry about how to make the GenericExchangeTransportAgent recognize your new handler. If you follow the guidelines in the documentation, you only need to copy your new handler to the directory where the other binaries reside. The GenericExchangeTransportAgent will automatically fetch up the new Transport Agent and use it when appropriate.

All (y)our base are belong to us(e)
-----------------------------------
Didn't find a good headline for this topic ;) 

In order to keep development simple, we wrote some base classes from which you can derive. 

- LoggingBase: Abstract base class for using a logger in handlers and filters.
- HandlerBase: Abstract base class for new handlers. Derived from LoggingBase. Defines the handler name, a list of subhandlers and the "Execute" method (can be used for handlers that should be run on every E-Mail).
- FilterableHandlerBase: Abstract base class for new handlers that need to be filterable (see example above). Derived from HandlerBase. Defines a list of filters and the "AppliesTo" method.

I hope these base classes will get you started when developing your own handlers... (Maybe your handlers will get into the next release of the GenericExchangeTransportAgent?)

What do we have already?
------------------------
So, what did we already implement in GenericExchangeTransportAgent?

- DisclaimerHandler: Adds some text to the bottom of the E-Mail message. [State: Stable]
- DkimSigningHandler: Signs your E-Mail with your Domain Key. [State: Beta]
- ExecutableHandler: Runs a defined command. You can export the E-Mail to an .eml file, either specifying a filename or generating a random one by leaving it blank. To pass the filename to your command, use "$emlfile$" in your command arguments. [State: Stable]
- ExtractAttachmentHandler: Extracts all available attachments to a directory of your choice. [State: Stable]
- NoopHandler: No operations, just executes its subhandlers. Can be used as a template for new handlers. [State: Stable]
- TwitterNotificationHandler: Just a gimmick ;) Twitters a message when you got a new E-Mail in your Inbox. Format of the message is "[{DATETIME}] New mail from {FROM}". [Status: Stable]

Feel free to write and contribute your own handlers. We would appreciate it. ;)

Contact
-------
fwe [AT] neos-it [DOT] de / [prunkster@twitter](http://twitter.com "prunkstar@twitter") / [http://www.neos-it.de](http://www.neos-it.de "NeosIT")

License
-------
Copyright (C) 2012  NeosIT GmbH

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.