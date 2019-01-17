using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Application.Services
{
    public interface IQuestionsService
    {
        void AddQuestions();
        void AddAnswer();
        void GetQuestions();
        void GetPrivateQuestions();
    }

    class QuestionsService : IQuestionsService
    {
        public void AddAnswer()
        {
            throw new NotImplementedException();
        }

        public void AddQuestions()
        {
            throw new NotImplementedException();
        }

        public void GetPrivateQuestions()
        {
            throw new NotImplementedException();
        }

        public void GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}