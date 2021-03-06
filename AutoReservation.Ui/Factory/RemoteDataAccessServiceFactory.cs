﻿using System.ServiceModel;
using AutoReservation.Common.Interfaces;
using Moq;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            var bind = new NetTcpBinding();
            var addr = new EndpointAddress("net.tcp://localhost:7876/AutoReservationService");
            var factory = new ChannelFactory<IAutoReservationService>(bind, addr);

            return factory.CreateChannel();
        }
    }
}
