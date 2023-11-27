//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Microsoft.EntityFrameworkCore;
using SmartEssayChecker.Api.Models.Feedbacks;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public async ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback) =>
            await InsertAsync(feedback);

        public IQueryable<Feedback> SelectAllFeedbacks() =>
            SelectAll<Feedback>().AsQueryable();

        public async ValueTask<Feedback> SelectFeedbackById(Guid feedbackId) =>
            await SelectAsync<Feedback>(feedbackId);

        public async ValueTask<Feedback> DeleteFeedbackAsync(Feedback feedback) =>
            await DeleteAsync(feedback);
    }
}
