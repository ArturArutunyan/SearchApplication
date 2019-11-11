
using ServiceParser.Interfaces.SearchServices;

namespace ServiceParser.Entities
{
    public class Snippet : ISnippet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
