using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepApi.Services.DTO.Response;

namespace WepApi.Services
{
    public class QuestionaryService
    {
        public List<QuestionNode> GenerateTestQuestionary()
        {
            List<QuestionNode> questionList = new List<QuestionNode>();
            QuestionNode simpleQuestion = new QuestionNode()
            {
                Question = "Do you like Chili ?",
                Answer = "Nope"
            };
            questionList.Add(simpleQuestion);
            QuestionNode nestedQuestions = new QuestionNode()
            {
                Question = "Do you like Game of Thrones ?",
                Answer = "Nope",
                SubQuestionNode = new QuestionNode() {
                    Question = "Are you sure?",
                    Answer = "Yes!",
                    SubQuestionNode = new QuestionNode()
                    {
                        Question = "Really?",
                        Answer = "Yes!!"
                    }
                }
            };
            questionList.Add(nestedQuestions);
            return questionList;
        }
    }
}