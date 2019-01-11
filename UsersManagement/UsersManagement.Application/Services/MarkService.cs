using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.Application.DTO;
using UsersManagement.Data.Infrastructure;
using UsersManagement.Domain.Entities;

namespace UsersManagement.Application.Services
{
    public interface IMarkService
    {
        void AddMark(MarkDTO mark);
        bool DeleteMark(int markId);
        bool UpdateMark(MarkDTO mark);
        MarkDTO GetMarkById(int markId);
        List<MarkDTO> GetUserMarks(int userId);
    }
    public class MarkService : IMarkService
    {
        private readonly IRepository<Mark> markRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public MarkService(IRepository<Mark> markRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.markRepository = markRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddMark(MarkDTO mark)
        {
            markRepository.Insert((Mark)new Mark().InjectFrom(mark));
            unitOfWork.Save();
        }

        public bool DeleteMark(int markId)
        {
            var markToDelete = markRepository.Query(x => x.Id == markId).FirstOrDefault();
            if (markToDelete != null)
            {
                markRepository.Delete(markToDelete);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool UpdateMark(MarkDTO mark)
        {
            var markToUpdate = markRepository.Query(x => x.Id == mark.Id).FirstOrDefault();
            if (markToUpdate != null)
            {
                markToUpdate.InjectFrom(mark);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public MarkDTO GetMarkById(int markId)
        {
            var markToFind = markRepository.Query(x => x.Id == markId).FirstOrDefault();
            if (markToFind != null)
            {
                return (MarkDTO)new MarkDTO().InjectFrom(markToFind);
            }
            return new MarkDTO();
        }

        public List<MarkDTO> GetUserMarks(int userId)
        {
            var user = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            return user.Marks.Select(x => (MarkDTO)new MarkDTO().InjectFrom(x)).ToList();
        }
    }
}
