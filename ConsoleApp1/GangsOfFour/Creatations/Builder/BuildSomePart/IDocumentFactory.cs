using System.Collections.Generic;

namespace ConsoleApp1.GangsOfFour.Creatations.Builder.BuildSomePart
{
    public enum DocPart
    {
        Footer,
        Header,
        Body
    }

    public interface IDocumentFactory
    {
        void BuildDoc(IDocBuilder docBuilder, List<DocPart> docParts);
    }
}
