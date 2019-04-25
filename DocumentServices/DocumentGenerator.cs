using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentServices
{
    public class DocumentGenerator
    {
        public MemoryStream GenerateImage(string htmlPath)
        {
            var html = new HTMLDocument(htmlPath);
            using (var renderer = new HtmlRenderer())
            {
                ImageRenderingOptions options = new ImageRenderingOptions();
                options.Format = ImageFormat.Jpeg;
                MemoryStream imageStream = new MemoryStream();
                using (ImageDevice ImageDevice = new ImageDevice(options, imageStream))
                {

                    renderer.Render(ImageDevice, html);
                    return imageStream;
                }
            }
        }

        public MemoryStream GenerateImageFromWord(Stream template, string parragraf)
        {
            Document doc = new Document(template);
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.Font.Border.Color = Color.Green;
            builder.Font.Border.LineWidth = 2.5;
            builder.Font.Border.LineStyle = LineStyle.DashDotStroker;
            builder.Writeln(parragraf);
            ImageRenderingOptions options = new ImageRenderingOptions();
            options.Format = ImageFormat.Jpeg;
            MemoryStream imageStream = new MemoryStream();
            using (ImageDevice ImageDevice = new ImageDevice(options, imageStream))
            {
                doc.Save(imageStream, SaveFormat.Jpeg);
                return imageStream;
            }
        }
    }
}
