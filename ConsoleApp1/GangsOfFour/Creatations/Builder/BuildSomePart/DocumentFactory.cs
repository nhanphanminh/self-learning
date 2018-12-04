using System;
using System.Collections.Generic;

namespace ConsoleApp1.GangsOfFour.Creatations.Builder.BuildSomePart
{
    public class DocumentFactory : IDocumentFactory
    {
        public void BuildDoc(IDocBuilder docBuilder, List<DocPart> docParts)
        {
            foreach (var docPart in docParts)
            {
                switch (docPart)
                {
                    case DocPart.Footer:
                        docBuilder.BuildFooter();
                        break;
                    case DocPart.Header:
                        docBuilder.BuildHeader();
                        break;
                    case DocPart.Body:
                        docBuilder.BuildBody();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
