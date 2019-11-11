using ServiceParserSnippets.Interfaces.SearchServices;
using ServiceParserSnippets.SearchServices.Google.Snippets;
using System.Collections.Generic;

namespace ServiceParserSnippets.SearchServices.Google
{
    public class GoogleServiceHelper : ServiceHelper
    {
        public GoogleServiceHelper()
        {
            _snippets.AddRange(new List<ISnippetContainer>
            {
                new GoogleSimpleSnippet(),
                new GoogleImages()
            });
        }
    }
}
