//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;

namespace SmartEssayChecker.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        public void LogCritical(Exception exception);
        public void LogError(Exception exception);
    }
}
