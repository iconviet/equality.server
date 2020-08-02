using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Lykke.Icon.Sdk;
using Lykke.Icon.Sdk.Data;
using Lykke.Icon.Sdk.Transport.Http;

namespace Icon_Cps.Client.Remote
{
    public class IconServiceClient : IconService
    {
        public IconServiceClient() : base(
            new HttpProvider(new HttpClient(),
                "https://ctz.solidwallet.io/api/v3"))
        {
        }

        public Task<PRepResponse> GetPRep(string address)
        {
            return GetPRep(new Address(address));
        }

        public Task<BigInteger> GetBalance(string address)
        {
            return GetBalance(new Address(address));
        }

        public Task<List<ScoreApi>> GetScoreApi(string address)
        {
            return GetScoreApi(new Address(address));
        }

        public async Task<IissInfoResponse> GetIissInfo()
        {
            var item = await CallAsync(new Call.Builder()
                .Method("getIISSInfo")
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new IissInfoResponse(item.ToObject());
        }

        public async Task<PRepInfoResponse> GetPRepInfo()
        {
            var item = await CallAsync(new Call.Builder()
                .Method("getPReps")
                .Params(new { endRanking = "1" })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new PRepInfoResponse(item.ToObject());
        }

        public async Task<PRepResponse> GetPRep(Address address)
        {
            var item = await CallAsync(new Call.Builder()
                .Method("getPRep")
                .Params(new { address })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new PRepResponse(item.ToObject());
        }

        public async Task<List<PRepResponse>> GetPReps()
        {
            var item = await CallAsync(new Call.Builder()
                .Method("getPReps")
                .Params(new { endRanking = "200" })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return item.ToObject().GetItem("preps").ToArray().Select(x => new PRepResponse(x.ToObject())).ToList();
        }
    }
}