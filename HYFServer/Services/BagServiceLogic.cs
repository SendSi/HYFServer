using Grpc.Core;
using HYFServer;

namespace PyramidServer.Services
{
    public class BagServiceLogic : BagService.BagServiceBase
    {

        private readonly ILogger<BagServiceLogic> _logger;
        public BagServiceLogic(ILogger<BagServiceLogic> logger)
        {
            _logger = logger;
        }
        public override Task<BagAllInfoResponse> BagAllInfo(BagAllInfoRequest request, ServerCallContext context)
        {
            BagAllInfoResponse res=new BagAllInfoResponse();
            res.AllItemInfo.Add(new ItemDto() { CfgId = 1, Sum = 1, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2, Sum = 51, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 3, Sum = 61, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 5, Sum = 101, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 58, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 59, Sum = 81, Uid = "21" });
            res.AllItemInfo.Add(new ItemDto() { CfgId = 2401, Sum =81, Uid = "21" });
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
                ItemDto = new ItemDto() { CfgId = 1, Sum = 1,Uid="21" }
            }); 
        }


        public override Task<BagUsingItemResponse> BagUsingItem(BagUsingItemRequest request, ServerCallContext context)
        {
            return Task.FromResult(new BagUsingItemResponse()
            {
               CfgId = 1, Sum = 1
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

            PushServiceLogic.PushToClient(context, new PushRsp()
            {
                ItemDots = res
            }); 
        }


    }


}
