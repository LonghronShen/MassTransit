// Copyright 2007-2015 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.AzureServiceBusTransport
{
    using System;
    using Microsoft.ServiceBus.Messaging;
    using Util;


    public class MessageSessionAsyncHandlerFactory :
        IMessageSessionAsyncHandlerFactory
    {
        readonly ISessionReceiver _receiver;
        readonly ITaskSupervisor _supervisor;

        public MessageSessionAsyncHandlerFactory(ITaskSupervisor supervisor, ISessionReceiver receiver)
        {
            _supervisor = supervisor;
            _receiver = receiver;
        }

        public IMessageSessionAsyncHandler CreateInstance(MessageSession session, BrokeredMessage message)
        {
            return new MessageSessionAsyncHandler(_supervisor, _receiver, session, message);
        }

        public void DisposeInstance(IMessageSessionAsyncHandler handler)
        {
            var disposable = handler as IDisposable;
            disposable?.Dispose();
        }
    }
}