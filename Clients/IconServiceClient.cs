using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using Lykke.Icon.Sdk;
using Lykke.Icon.Sdk.Data;
using Lykke.Icon.Sdk.Transport.Http;

namespace IconCps.Blazor.Clients
{
    public class IconServiceClient : IIconService
    {
        protected IconService IconService;

        public IconServiceClient(double timeout = 30)
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };
            const string url = "https://ctz.solidwallet.io/api/v3";
            IconService = new IconService(new HttpProvider(client, url));
        }

        public Task<Block> GetLastBlock()
        {
            return IconService.GetLastBlock();
        }

        public Task<Block> GetBlock(Bytes hash)
        {
            return IconService.GetBlock(hash);
        }

        public Task<BigInteger> GetTotalSupply()
        {
            return IconService.GetTotalSupply();
        }

        public Task<T> CallAsync<T>(Call<T> call)
        {
            return IconService.CallAsync(call);
        }

        public Task<PRepRpc> GetPRep(string address)
        {
            return GetPRep(new Address(address));
        }

        public Task<Block> GetBlock(BigInteger height)
        {
            return IconService.GetBlock(height);
        }

        public Task<BigInteger> GetBalance(string address)
        {
            return GetBalance(new Address(address));
        }

        public Task<BigInteger> GetBalance(Address address)
        {
            return IconService.GetBalance(address);
        }

        public Task<List<ScoreApi>> GetScoreApi(string address)
        {
            return GetScoreApi(new Address(address));
        }

        public Task<List<ScoreApi>> GetScoreApi(Address address)
        {
            return IconService.GetScoreApi(address);
        }

        public Task<ConfirmedTransaction> GetTransaction(Bytes hash)
        {
            return IconService.GetTransaction(hash);
        }

        public Task<TransactionResult> GetTransactionResult(Bytes hash)
        {
            return IconService.GetTransactionResult(hash);
        }

        public Task<Bytes> SendTransaction(SignedTransaction transaction)
        {
            return IconService.SendTransaction(transaction);
        }

        public async Task<IissInfoRpc> GetIissInfo()
        {
            var response = await CallAsync(new Call.Builder()
                .Method("getIISSInfo")
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new IissInfoRpc(response.ToObject());
        }

        public async Task<PRepInfoRpc> GetPRepInfo()
        {
            var response = await CallAsync(new Call.Builder()
                .Method("getPReps")
                .Params(new { endRanking = "1" })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new PRepInfoRpc(response.ToObject());
        }

        public async Task<PRepRpc> GetPRep(Address address)
        {
            var response = await CallAsync(new Call.Builder()
                .Method("getPRep")
                .Params(new { address })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return new PRepRpc(response.ToObject());
        }

        public async Task<List<PRepRpc>> GetPReps()
        {
            var response = await CallAsync(new Call.Builder()
                .Method("getPReps")
                .Params(new { endRanking = "200" })
                .To(new Address("cx0000000000000000000000000000000000000000"))
                .Build());
            return response.ToObject().GetItem("preps").ToArray().Select(x => new PRepRpc(x.ToObject())).ToList();
        }
    }
}