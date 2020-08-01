using System.Numerics;
using Lykke.Icon.Sdk.Transport.JsonRpc;

namespace IconCps.Blazor.Clients
{
    public class PRepInfoRpc
    {
        private readonly RpcObject _properties;

        public PRepInfoRpc(RpcObject properties)
        {
            _properties = properties;
        }

        public BigInteger GetTotalStaked()
        {
            return _properties.GetItem("totalStake")?.ToInteger() ?? 0;
        }

        public BigInteger GetTotalDelegated()
        {
            return _properties.GetItem("totalDelegated")?.ToInteger() ?? 0;
        }
    }
}