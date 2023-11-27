//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;
using System;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertFeedbackAsync(Feedback feedback);
        ValueTask<User> SelectAllFeedbackAsync();
        ValueTask<User> SelectFeedbackByIdAsync(Guid feedbackId);
        ValueTask<User> DeleteFeedbackAsync(Feedback feedback);
    }
}
