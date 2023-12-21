//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Essay> Essays { get; set; }

        public async ValueTask<Essay> InsertEssayAsync(Essay essay) =>
            await InsertAsync(essay);

        public IQueryable<Essay> SelectAllEssays() =>
            SelectAll<Essay>().AsQueryable();

        public async ValueTask<Essay> SelectEssayByIdAsync(Guid essayId) =>
            await SelectAsync<Essay>(essayId);

        public async ValueTask<Essay> DeleteEssayAsync(Essay essay) =>
            await DeleteAsync(essay);
    }
}
