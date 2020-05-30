using AngleSharp.Html.Dom;

namespace Rhymer
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
