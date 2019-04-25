using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi.Services.DTO.Response
{
    public class QuestionNode
    {
        public string Question  { get; set; }
        public string Answer { get; set; }
        public QuestionNode SubQuestionNode { get; set; } = null;
    }
}