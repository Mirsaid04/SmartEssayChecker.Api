using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Services.Foundations.Essays
{
    public interface IEssayService
    {
        public ValueTask<Essay> AddEssayAsync(Essay essay);
        public IQueryable<Essay> RetrieveAllEssays();
        public ValueTask<Essay> RetrieveEssayByIdAsync(Guid essayId);
        public ValueTask<Essay> RemoveEssayAsync(Guid essay);
    }
}
