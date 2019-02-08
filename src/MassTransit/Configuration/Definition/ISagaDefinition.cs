// Copyright 2007-2019 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.Definition
{
    using System;
    using Saga;


    public interface ISagaDefinition
    {
        /// <summary>
        /// The saga type
        /// </summary>
        Type SagaType { get; }

        /// <summary>
        /// Return the endpoint name for the consumer, using the specified formatter if necessary.
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns></returns>
        string GetEndpointName(IEndpointNameFormatter formatter);
    }


    public interface ISagaDefinition<TSaga> :
        ISagaDefinition
        where TSaga : class, ISaga
    {
        /// <summary>
        /// Configure the consumer on the receive endpoint
        /// </summary>
        /// <param name="endpointConfigurator">The receive endpoint configurator for the consumer</param>
        /// <param name="sagaConfigurator">The consumer configurator</param>
        void Configure(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<TSaga> sagaConfigurator);
    }
}
