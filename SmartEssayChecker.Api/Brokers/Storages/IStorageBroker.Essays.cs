//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Essay> InsertEssayAsync(Essay essay);
        IQueryable<Essay> SelectAllEssays();
        ValueTask<Essay>SelectEssayByIdAsync(Guid essayId);
        ValueTask<Essay> DeleteEssayAsync(Essay essay);
    }
}
