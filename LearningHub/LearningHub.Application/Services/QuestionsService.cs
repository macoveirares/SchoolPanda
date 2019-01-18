using LearningHub.Application.DTO;
using LearningHub.Data.Infrastructure;
using LearningHub.Domain.Entities;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningHub.Application.Services
{
    public interface IQuestionsService
    {
        void AddQuestion(string question, int userId, int type, int addressedTo);
        void AddAnswer();
        List<QuestionDto> GetQuestions(int userId, int type);
        void GetPrivateQuestions();
        void AnswerQuestion(int Id, string answer, int type, int profId);
        List<QuestionDto> GetPrivatequestionsForProf(int addressedTo);
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
            var questionEntity = new Questions()
            {
                Question = question,
                UserId = userId,
                Type = type,
                AddressedToUserId = addressedTo
            };
            _questionsRepository.Insert(questionEntity);
            _unitOfWork.Save();
        }

        public void AnswerQuestion(int Id, string answer, int type, int profId)
        {
            var questionEntity = _questionsRepository.GetById(Id);
            if (questionEntity == null) return;

            questionEntity.Answer = answer;
            questionEntity.Type = type;
            questionEntity.AddressedToUserId = profId;
            _questionsRepository.Update(questionEntity);
            _unitOfWork.Save();
        }

        public void GetPrivateQuestions()
        {

        }

        public List<QuestionDto> GetPrivatequestionsForProf(int addressedTo)
        {
            var entities = _questionsRepository.Query(a => a.AddressedToUserId == addressedTo);
            var result = new List<QuestionDto>();
            foreach (var item in entities)
            {
                result.Add((QuestionDto)new QuestionDto().InjectFrom(item));
            }
            return result;
        }

        public List<QuestionDto> GetQuestions(int userId, int type)
        {
            var entities = new List<Questions>();
            if (userId == 0 && type == 1)
            {
               entities = _questionsRepository.Query(a => a.Type == type).ToList();
            }
            else if(userId != 0)
            {
                entities = _questionsRepository.Query(a => a.UserId == userId && a.Type == type).ToList();
            }

            var result = new List<QuestionDto>();
            foreach (var item in entities)
            {
                result.Add((QuestionDto)new QuestionDto().InjectFrom(item));
            }
            return result;
        }


    }
}