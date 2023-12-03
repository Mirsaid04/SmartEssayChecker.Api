//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Essay> InsertEssayAsync(Essay essay);
        IQueryable<Essay> SelectAllEssays();
        ValueTask<Essay> SelectEssayByIdAsync(Guid essayId);
        ValueTask<Essay> DeleteEssayAsync(Essay essay);
    }
}
