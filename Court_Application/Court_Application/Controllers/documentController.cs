using Court_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;

namespace Court_Application.Controllers
{
    public class documentController : Controller
    {
        public IActionResult Index()
        {

            return View(new Writ_Document());
        }
        [HttpPost]
        public IActionResult DownloadWritFile(Writ_Document document)
        {

            TextToWord(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\" + document.SelectedCategory + ".docx", ToDictionary<string>(document), "writ petition of " + document.First_petioner_Name);
            return NoContent();
        }
        [HttpPost]
        public IActionResult DownloadSuitFile(Suit_Document document)
        {

            //TextToWord(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\" + document.SelectedCategory + ".docx", ToDictionary<string>(document), "writ petition of " + document.First_petioner_Name);
            return NoContent();
        }
        public static void TextToWord(string pWordDoc, Dictionary<string, string> pDictionaryMerge, string fileName)
        {
            Object oMissing = System.Reflection.Missing.Value;


            Application oWord = new();
            Document oWordDoc;
            oWord.Visible = true;
            Object oTemplatePath = pWordDoc;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);


            foreach (Field myMergeField in oWordDoc.Fields)
            {
                Microsoft.Office.Interop.Word.Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf('\\');
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText[11..endMerge];
                    fieldName = fieldName.Trim();
                    foreach (var item in pDictionaryMerge)
                    {
                        if (fieldName == item.Key)
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(string.IsNullOrEmpty(item.Value) ? " " : item.Value);
                        }
                    }
                }
            }

            oWordDoc.SaveAs(@"C:\Users\Narendra Kundeti\Documents\" + fileName + ".docx");
            oWord.Application.Quit();
        }

        public static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary!;
        }
    }
}
