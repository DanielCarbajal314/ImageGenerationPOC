using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WepApi.Services;
using WepApi.Services.DTO.Response;

namespace WepApi.Controllers
{
    public class QuestionaryController : Controller
    {
        // GET: Questionary
        public ActionResult Index()
        {
            QuestionaryService questionaryService = new QuestionaryService();
            return View(questionaryService.GenerateTestQuestionary());
        }

        public ActionResult RenderQuestion(QuestionNode questionNode)
        {
            return PartialView(questionNode);
        }
    }
}