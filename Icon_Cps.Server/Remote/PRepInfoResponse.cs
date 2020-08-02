using System.Numerics;
using Lykke.Icon.Sdk.Transport.JsonRpc;

namespace Icon_Cps.Server.Remote
{
    public class PRepInfoResponse
    {
        private readonly RpcObject _properties;

        public PRepInfoResponse(RpcObject properties)
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