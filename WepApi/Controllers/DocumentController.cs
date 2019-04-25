using DocumentServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WepApi.Services;
using WepApi.Services.DTO.Response;

namespace WepApi.Controllers
{
    public class DocumentController : ApiController
    {
        private DocumentGenerator documentGenerator = new DocumentGenerator();
        private QuestionaryService questionaryService = new QuestionaryService();

        [HttpGet]
        public HttpResponseMessage GetCssAndHTMLBasedImage()
        {
            MemoryStream memoryStream = this.documentGenerator.GenerateImage(@"http://localhost:53269/questionary");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(memoryStream.ToArray())
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "questionaryFromHtml.jpg"
            };
            return response;
        }


        [HttpGet]
        public HttpResponseMessage GetMsWordBasedImage()
        {
            MemoryStream memoryStream = this.documentGenerator.GenerateImageFromWord(new MemoryStream(Resources.FileResources.Template),this.GenerateParragrath());
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(memoryStream.ToArray())
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "questionaryFromWord.jpeg"
            };
            return response;
        }

        private string GenerateParragrath()
        {
            var nodes = this.questionaryService.GenerateTestQuestionary();
            return string.Join("\n", nodes.Select(x => this.renderParragraftRecursively(x, 1)));
        }

        private string renderParragraftRecursively(QuestionNode questionNode, int dept)
        {
            if (questionNode == null) return "";

            string initialTab = new String('\t', dept);
            string nextTab  = new String('\t', dept+1);
            return $"{initialTab}{questionNode.Question}\n" +
                   $"{nextTab}{questionNode.Answer}\n" +
                   this.renderParragraftRecursively(questionNode.SubQuestionNode,dept+2);
        }

    }
}
