using System.Collections.Generic;
using Equality.Client.Objects;
using Equality.Client.Remote;

namespace Equality.Client.Models
{
    public class TokenListPageModel : PageModelBase
    {
        public List<Token> Tokens { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public TokenListPageModel()
        {
            Tokens = new List<Token>
            {
                new()
                {
                    Name = "Token 1",
                    Symbol = 100000,
                    Description = 40000
                },
                new()
                {
                    Name = "Token 2",
                    Symbol = 100000,
                    Description = 40000
                },
                new()
                {
                    Name = "Token 3",
                    Symbol = 100000,
                    Description = 40000
                }
            };
        }
    }
}