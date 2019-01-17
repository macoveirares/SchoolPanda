using LearningHub.Data.Infrastructure;
using LearningHub.Domain.Entities;
using System;

namespace LearningHub.Application.Services
{
    public interface IQuestionsService
    {
        void AddQuestion(string question, int userId, int type, int addressedTo);
        void AddAnswer();
        void GetQuestions();
        void GetPrivateQuestions();
    }

    class QuestionsService : IQuestionsService
    {
        private readonly IRepository<Questions> _questionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsService(IRepository<Questions> questionsRepository, IUnitOfWork unitOfWork)
        {
            _questionsRepository = questionsRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddAnswer()
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(string question, int userId, int type, int addressedTo)
        {
            var questionEntity = new Questions() {
                Question = question,
                UserId = userId,
                Type = type,
                AddressedToUserId = addressedTo
            };
            _questionsRepository.Insert(questionEntity);
            _unitOfWork.Save();
        }

        public void GetPrivateQuestions()
        {

        }

        public void GetPrivatequestionsForProf()
        {

        }

        public void GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}