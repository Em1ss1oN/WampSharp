﻿using WampSharp.Auxiliary.Server;
using WampSharp.Core.Contracts.V1;
using WampSharp.Core.Serialization;
using WampSharp.PubSub.Server;
using WampSharp.Rpc.Server;

namespace WampSharp
{
    public class WampServerBuilder<TMessage> : IWampServerBuilder<TMessage>
    {
        public virtual IWampServer<TMessage> Build(IWampFormatter<TMessage> formatter,
                                                   WampRpcMetadataCatalog rpcMetadataCatalog,
                                                   IWampTopicContainerExtended<TMessage> topicContainer)
        {
            IWampRpcServer<TMessage> rpcServer = BuildRpcServer(formatter, rpcMetadataCatalog);
            IWampPubSubServer<TMessage> pubSubServer = BuildPubSubServer(formatter, topicContainer);
            IWampAuxiliaryServer auxiliaryServer = BuildAuxiliaryServer(formatter);

            DefaultWampServer<TMessage> server =
                new DefaultWampServer<TMessage>(rpcServer, pubSubServer, auxiliaryServer);

            return server;
        }

        protected virtual IWampRpcServer<TMessage> BuildRpcServer(IWampFormatter<TMessage> formatter,
                                                                  WampRpcMetadataCatalog rpcMetadataCatalog)
        {
            WampRpcServer<TMessage> rpcServer = new WampRpcServer<TMessage>(formatter, rpcMetadataCatalog);
            return rpcServer;
        }

        protected virtual IWampPubSubServer<TMessage> BuildPubSubServer(IWampFormatter<TMessage> formatter,
                                                                        IWampTopicContainerExtended<TMessage> topicContainer)
        {
            WampPubSubServer<TMessage> pubSubServer = new WampPubSubServer<TMessage>(topicContainer);
            return pubSubServer;
        }

        protected virtual IWampAuxiliaryServer BuildAuxiliaryServer(IWampFormatter<TMessage> formatter)
        {
            WampAuxiliaryServer auxiliaryServer = new WampAuxiliaryServer();
            return auxiliaryServer;
        }
    }
}