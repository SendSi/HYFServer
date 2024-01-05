using Grpc.Core;
using HYFServer;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace HYFServer.Services
{
    public class BagServiceLogic : BagService.BagServiceBase
    {

        private readonly ILogger<BagServiceLogic> _logger;
        public BagServiceLogic(ILogger<BagServiceLogic> logger)
        {
            _logger = logger;
        }

        public override async Task ListenBag(BagRequest request, IServerStreamWriter<BagResponse> responseStream, ServerCallContext context)
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
        public static void BagToClient(ServerCallContext context, BagResponse shopListen)
        {
            pushQueue.Enqueue(shopListen);
        }
        static ConcurrentQueue<BagResponse> pushQueue = new ConcurrentQueue<BagResponse>();



        public override Task<BagAllInfoResponse> BagAllInfo(BagAllInfoRequest request, ServerCallContext context)
        {
            BagAllInfoResponse res = new BagAllInfoResponse();
            res.AllItemInfo.Add(new ItemDto() { CfgId = 1, Sum = 1, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2, Sum = 51, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 3, Sum = 61, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 5, Sum = 101, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 58, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 59, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2401, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2402, Sum = 71, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 10001, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 40001, Sum = 51, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 30001, Sum = 11, Uid = "21" });

            return Task.FromResult(res);
        }

        public override Task<BagOneInfoResponse> BagOneInfo(BagOneInfoRequest request, ServerCallContext context)
        {
            return Task.FromResult(new BagOneInfoResponse()
            {
                ItemDto = new ItemDto() { CfgId = 1, Sum = 1, Uid = "21" }
            });
        }


        public override Task<BagUsingItemResponse> BagUsingItem(BagUsingItemRequest request, ServerCallContext context)
        {
            return Task.FromResult(new BagUsingItemResponse()
            {
                CfgId = 1,
                Sum = 1
            });
        }


        public static void RoleBagInfo(ServerCallContext context)
        {
            ItemDtos res = new ItemDtos();
            res.AllItemInfo.Add(new ItemDto() { CfgId = 1, Sum = 1, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2, Sum = 51, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 3, Sum = 61, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 5, Sum = 101, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 58, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 59, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2401, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2402, Sum = 71, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 10001, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 40001, Sum = 51, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 30001, Sum = 11, Uid = "21" });

            //PushServiceLogic.PushToClient(context, new PushRsp()
            //{
            //    ItemDots = res
            //});
        }

        public override async Task OpenBag(IAsyncStreamReader<OpenBagRequest> requestStream, IServerStreamWriter<OpenBagResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"总数:{initialItems.Count}");
            while (true)
            {
                if (initialItems.Count > 0)
                {   // 发送更新的背包信息给客户端
                    await responseStream.WriteAsync(new OpenBagResponse { Items = { initialItems } });
                    Console.WriteLine($"发送了 总数:{initialItems.Count}");
                    initialItems.Clear();
                }
            }      
        }


       static List<ItemDto> initialItems = new List<ItemDto>();
        public static void AddItemDto()
        {
            initialItems.Add(new ItemDto() { CfgId = 30002, Sum = 11, Uid = "21" });
            initialItems.Add(new ItemDto() { CfgId = 30003, Sum = 101, Uid = "21" });
            initialItems.Add(new ItemDto() { CfgId = 30001, Sum = 181, Uid = "21" });
            Console.WriteLine($"-->总数:{initialItems.Count}");
        }




    }


}
