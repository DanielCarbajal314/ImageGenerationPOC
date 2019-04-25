using DocumentServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentGenerator documentGenerator = new DocumentGenerator();
            using (var memoryString = documentGenerator.GenerateImage(@"https://docs.aspose.com/display/htmlnet/Load+HTML+Document+Asynchronously"))
            {
                using (FileStream file = new FileStream("page.jpg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    memoryString.WriteTo(file);
                }
            }
        }
    } 
}
