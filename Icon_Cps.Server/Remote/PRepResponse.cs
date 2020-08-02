using System.Numerics;
using Lykke.Icon.Sdk.Data;
using Lykke.Icon.Sdk.Transport.JsonRpc;

namespace Icon_Cps.Server.Remote
{
    public class PRepResponse
    {
        private readonly RpcObject _properties;

        public PRepResponse(RpcObject properties)
        {
            _properties = properties;
        }

        public string GetName()
        {
            return _properties.GetItem("name")?.ToString();
        }

        public string GetCity()
        {
            return _properties.GetItem("city")?.ToString();
        }

        public string GetCountry()
        {
            return _properties.GetItem("country")?.ToString();
        }

        public string GetDetails()
        {
            return _properties.GetItem("details")?.ToString();
        }

        public Address GetAddress()
        {
            return _properties.GetItem("address")?.ToAddress();
        }

        public BigInteger GetIrep()
        {
            return _properties.GetItem("irep")?.ToInteger() ?? 0;
        }

        public BigInteger GetStake()
        {
            return _properties.GetItem("stake")?.ToInteger() ?? 0;
        }

        public string GetP2PEndpoint()
        {
            return _properties.GetItem("p2pEndpoint")?.ToString();
        }

        public BigInteger GetDelegated()
        {
            return _properties.GetItem("delegated")?.ToInteger() ?? 0;
        }

        public BigInteger GetTotalBlocks()
        {
            return _properties.GetItem("totalBlocks")?.ToInteger() ?? 0;
        }

        public BigInteger GetValidatedBlocks()
        {
            return _properties.GetItem("validatedBlocks")?.ToInteger() ?? 0;
        }

        public BigInteger GetUnvalidatedSequenceBlocks()
        {
            return _properties.GetItem("unvalidatedSequenceBlocks")?.ToInteger() ?? 0;
        }
    }
}