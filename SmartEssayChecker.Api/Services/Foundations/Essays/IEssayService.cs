using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Services.Foundations.Essays
{
    public interface IEssayService
    {
        ///  /// <exception cref="Models.Essays.Exceptions.EssayValidationException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyValidationException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayServiceException"></exception>
        public ValueTask<Essay> AddEssayAsync(Essay essay);
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayServiceException"></exception>     
        public IQueryable<Essay> RetrieveAllEssays();
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayServiceException"></exception> 
        public ValueTask<Essay> RetrieveEssayByIdAsync(Guid essayId);
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyValidationException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayServiceException"></exception>
        public ValueTask<Essay> RemoveEssayAsync(Guid essay);
        /// <exception cref="Models.Essays.Exceptions.EssayValidationException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyValidationException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayDependencyException"></exception>
        /// <exception cref="Models.Essays.Exceptions.EssayServiceException"></exception>
    }
}
