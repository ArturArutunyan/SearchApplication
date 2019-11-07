using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceParser.Interfaces.SearchServices
{
    public interface ISnippet
    {
        int Id { get; set; }
        string Title { get; set; }
        string Url { get; set; }
    }
}
