using Grpc.Core;
using HYFServer;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace HYFServer.Services
{
    public class ShopServiceLogic : ShopService.ShopServiceBase
    {

        private readonly ILogger<ShopServiceLogic> _logger;
        public ShopServiceLogic(ILogger<ShopServiceLogic> logger)
        {
            _logger = logger;
        }
        static ConcurrentQueue<ShopResponse> pushQueue = new ConcurrentQueue<ShopResponse>();

        public override async Task ListenShop(ShopRequest request, IServerStreamWriter<ShopResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                while (pushQueue.TryDequeue(out var shopListen))
                {
                    await responseStream.WriteAsync(shopListen);
                }
            }
            await Task.CompletedTask;
        }

        public static void ShopToClient(ServerCallContext context, ShopResponse shopListen)
        {
            pushQueue.Enqueue(shopListen);
        }

        public override Task<ShopStateResponse> ShopState(ShopStateRequest request, ServerCallContext context)
        {
            Console.WriteLine($"请求了:{request.CfgId},将返回true");

            var sc = new ShopStateResponse { CfgId=request.CfgId,State=true};
            return Task.FromResult(sc);
        }


    }


}
