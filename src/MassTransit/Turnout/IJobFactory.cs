﻿// Copyright 2007-2015 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.Turnout
{
    using System.Threading.Tasks;
    using Pipeline;


    public interface IJobFactory<TInput>
        where TInput : class
    {
        /// <summary>
        /// Executes the activity context by passing it to the activity factory, which creates the activity
        /// and then invokes the next pipe with the combined activity context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        Task Execute(JobContext<TInput> context, IPipe<JobContext<TInput>> next);
    }


    public interface IJobFactory<TInput, TResult>
        where TInput : class
        where TResult : class
    {
        /// <summary>
        /// Execute the job, invoking next with the result of the job once it completed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        Task Execute(JobContext<TInput, TResult> context, IPipe<JobResultContext<TInput, TResult>> next);
    }
}