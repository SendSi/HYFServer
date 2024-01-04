using System.Collections.Concurrent;
using Grpc.Core;
using HYFServer;

namespace PyramidServer.Services
{
    public class PushServiceLogic : PushService.PushServiceBase
    {
        static ConcurrentDictionary<string, PushServiceLogic> clientPushDic = new ConcurrentDictionary<string, PushServiceLogic>();
        ConcurrentQueue<PushRsp> pushQueue = new ConcurrentQueue<PushRsp>();

        public override async Task ServerPush(PushReq request, IServerStreamWriter<PushRsp> responseStream, ServerCallContext context)
        {
            clientPushDic.TryAdd(context.Peer, this);
            {
                while (!context.CancellationToken.IsCancellationRequested)
                {
                    while (pushQueue.TryDequeue(out var pushRsp))
                    {
                        await responseStream.WriteAsync(pushRsp);
                    }
                }
            }
            clientPushDic.TryRemove(context.Peer, out var _);

            await Task.CompletedTask;
        }

        void EnqueuePush(PushRsp pushRsp)
        {
            pushQueue.Enqueue(pushRsp);
        }

        public static void PushToClient(ServerCallContext context, PushRsp pushRsp)
        {
            if (clientPushDic.TryGetValue(context.Peer, out var client))
            {
                client.EnqueuePush(pushRsp);
            }
        }
    }
}
