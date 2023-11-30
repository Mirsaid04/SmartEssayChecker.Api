//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback);
        IQueryable<Feedback> SelectAllFeedbackAsync();
        ValueTask<Feedback> SelectFeedbackByIdAsync(Guid feedbackId);
        ValueTask<Feedback> DeleteFeedbackAsync(Feedback feedback);
    }
}
