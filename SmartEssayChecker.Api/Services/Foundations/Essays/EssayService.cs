//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================



using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Services.Foundations.Essays
{
    public partial class EssayService : IEssayService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public EssayService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Essay> AddEssayAsync(Essay essay) =>
        TryCatch(async () =>
        {
            ValidationOnAdd(essay);

            return await this.storageBroker.InsertEssayAsync(essay);
        });


        public IQueryable<Essay> RetrieveAllEssays() =>
            this.storageBroker.SelectAllEssays();


        public ValueTask<Essay> RetrieveEssayByIdAsync(Guid essayId) =>
        TryCatch(async () =>
        {
            ValidateEssayId(essayId);

            Essay essay = await this.storageBroker.SelectEssayByIdAsync(essayId);

            return essay;
        });

        public async ValueTask<Essay> RemoveEssayAsync(Guid essayId)
        {
            ValidateEssayId(essayId);

            Essay essay = await this.storageBroker.SelectEssayByIdAsync(essayId);


            return await this.storageBroker.DeleteEssayAsync(essay);
        }
    }
}
