using System.Numerics;
using Lykke.Icon.Sdk.Transport.JsonRpc;

namespace IconIcps.Client.Remote
{
    public class IissInfoResponse
    {
        private readonly RpcObject _properties;

        public IissInfoResponse(RpcObject properties)
        {
            _properties = properties;
        }

        public BigInteger GetBlockHeight()
        {
            return _properties.GetItem("blockHeight")?.ToInteger() ?? 0;
        }

        public BigInteger GetNextPRepTerm()
        {
            return _properties.GetItem("nextPRepTerm")?.ToInteger() ?? 0;
        }

        public BigInteger GetIRep()
        {
            var variable = _properties.GetItem("variable");
            return variable?.ToObject().GetItem("irep")?.ToInteger() ?? 0;
        }

        public BigInteger GetRRep()
        {
            var variable = _properties.GetItem("variable");
            return variable?.ToObject().GetItem("rrep")?.ToInteger() ?? 0;
        }

        public BigInteger GetNextCalculation()
        {
            return _properties.GetItem("nextCalculation")?.ToInteger() ?? 0;
        }
    }
}