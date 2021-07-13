using System.Collections.Generic;
using Equality.Client.Objects;

namespace Equality.Client.Models
{
    public class PoolListViewModel : ViewModelBase
    {
        public bool IsLoaded { get; set; }

        public List<Pool> Pools { get; set; }

        public PoolListViewModel()
        {
            Pools = new List<Pool>
            {
                new()
                {
                    Name = "ICD-USDT",
                    Liquidity = 123456789,
                    Volume24H = 15678989,
                    Change24H = 0.036
                },
                new()
                {
                    Name = "ICD-bnUSD",
                    Liquidity = 23456789,
                    Volume24H = 5678989,
                    Change24H = 0.12
                },
                new()
                {
                    Name = "USDT-USDC",
                    Liquidity = 23456789,
                    Volume24H = 5678989,
                    Change24H = 0.12
                },
                new()
                {
                    Name = "ICD-USDC",
                    Liquidity = 23456789,
                    Volume24H = 5678989,
                    Change24H = 0.12
                },
                new()
                {
                    Name = "USDT-bnUSD",
                    Liquidity = 23456789,
                    Volume24H = 5678989,
                    Change24H = 0.12
                }
            };
        }
    }
}