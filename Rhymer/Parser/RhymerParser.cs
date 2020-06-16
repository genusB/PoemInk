using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhymer.Parser
{
    public class RhymerParser : IParser<RhymesByCategory>
    {
        public RhymesByCategory Parse(IHtmlDocument document)
        {
            
            var content = new RhymesByCategory();

            List<string> allRhymes = document.QuerySelectorAll("a")
                                                          .Where(item => item.ClassName != null && item.ClassName.Contains("btn"))
                                                          .Select(item => item.TextContent)
                                                          .ToList<string>();


            List<string> rhymesTitles = document.QuerySelectorAll("h5")
                                                          .Where(item => item.ClassName != null && item.ClassName.Contains("text-success pt-2"))
                                                          .Select(item => item.TextContent)
                                                          .ToList<string>();

            int rhymesCounter = 0;
            rhymesTitles.ForEach(title =>
            {
                int numberPiece = Int32.Parse(title.Substring(0, title.IndexOf(" ")));

                List<string> rhymesContent = allRhymes.GetRange(rhymesCounter, numberPiece);

                rhymesCounter += numberPiece;
                content.AllRhymes.Add(title, rhymesContent);
            }); 
           
            return content;
        }
    }
}
