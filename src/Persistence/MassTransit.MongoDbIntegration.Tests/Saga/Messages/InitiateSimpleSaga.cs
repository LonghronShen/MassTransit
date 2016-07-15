﻿namespace MassTransit.MongoDbIntegration.Tests.Saga
{
    using System;
    using MassTransit;


    public class InitiateSimpleSaga : CorrelatedBy<Guid>
    {
        public InitiateSimpleSaga()
        {
        }

        public InitiateSimpleSaga(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }

        public string Name { get; set; }
    }
}