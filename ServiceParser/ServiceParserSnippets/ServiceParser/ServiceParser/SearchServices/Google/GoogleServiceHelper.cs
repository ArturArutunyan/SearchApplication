using ServiceParser.Interfaces;
using ServiceParser.SearchServices.Google.Snippets;
using System.Collections.Generic;

namespace ServiceParser.SearchServices.Google
{
    public class GoogleServiceHelper : ServiceHelper
    {
        public GoogleServiceHelper()
        {
            _snippets.AddRange(new List<ISnippetContainer>
            {
                new GoogleSimpleSnippet()
            });
        }
    }
}
