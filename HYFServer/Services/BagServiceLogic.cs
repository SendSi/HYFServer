using Google.Protobuf.Collections;
using Grpc.Core;
using HYFServer.Utils;
using System.Collections.Concurrent;


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
                while (pushQueue.TryDequeue(out var bagListen))
                {
                    await responseStream.WriteAsync(bagListen);
                }
            }
            await Task.CompletedTask;
        }
        static ConcurrentQueue<BagResponse> pushQueue = new ConcurrentQueue<BagResponse>();


        public static void BagToClient(ServerCallContext context, BagResponse bagListen)
        {
            pushQueue.Enqueue(bagListen);
        }


        public static void AddItemDto(int idValue)
        {
            BagResponse bagResponse = new BagResponse();
            bagResponse.ItemInfos = new ItemDtos();
            var res = RoleHasBagData(idValue);

            bagResponse.ItemInfos.ItemInfos.Add(res);
            pushQueue.Enqueue(bagResponse);
        }

        static RepeatedField<ItemDto> RoleHasBagData(int roleId)
        {
            RepeatedField<ItemDto> res = new RepeatedField<ItemDto>();
            var listDic = MySqlUtils.Instance.QuerySQL_1("SELECT * FROM bag where roleId=@roleId", "@roleId", roleId);
            for (int i = 0; i < listDic.Count; i++)
            {
                ItemDto itemDto = new ItemDto(); // 创建新的 ItemDto 对象
                foreach (var dic in listDic[i])
                {
                    if (dic.Key == "cfgId") { itemDto.CfgId = (int)dic.Value; } // 根据列名将值赋给相应的属性
                    else if (dic.Key == "sum") { itemDto.Sum = (int)dic.Value; }
                    else if (dic.Key == "uid") { itemDto.Uid = (string)dic.Value; }
                }
                res.Add(itemDto);
            }
            return res;
        }


        public static void OpenSetValue()
        {
            BagResponse bagResponse = new BagResponse();
            bagResponse.TestValue = 5;
            pushQueue.Enqueue(bagResponse);
        }
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
            OpenSetValue();
            return Task.FromResult(new BagUsingItemResponse()
            {
                CfgId = 1,
                Sum = 1
            });
        }

        public override Task<OpenBagResponse> OpenBag(OpenBagRequest request, ServerCallContext context)
        {
            Metadata md = context.RequestHeaders;
            int roleId = 0;
            string nickName = string.Empty;
            foreach (var item in md)
            {
                if (item.Key == "roleid") { roleId = int.Parse(item.Value); }
                if (item.Key == "nickname") { nickName = item.Value.ToString(); }
            }
            Console.WriteLine($"根据账号 去mysql查询数据-->>>:roleId:{roleId}  nickName:{nickName}");

            //给的伪查询结果
            OpenBagResponse res = new OpenBagResponse();
            res.Items.Add(new ItemDto() { CfgId = 1, Sum = 1, Uid = "21" });
            res.Items.Add(new ItemDto() { CfgId = 2, Sum = 1, Uid = "21" });
            res.Items.Add(new ItemDto() { CfgId = 3, Sum = 1, Uid = "21" });
            return Task.FromResult(res);
        }








    }


}
