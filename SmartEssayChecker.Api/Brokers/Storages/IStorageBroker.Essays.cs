//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;
using System;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertEssayAsync(Essay essay);
        ValueTask<User> SelectAllEssays();
        ValueTask<User> SelectEssayByIdAsync(Guid essayId);
        ValueTask<User> DeleteEssayAsync(Essay essay);
    }
}
