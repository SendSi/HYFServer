using Grpc.Core;
using HYFServer.Utils;
using System.Collections.Concurrent;

namespace HYFServer.Services
{
    public class LoginServiceLogic : LoginService.LoginServiceBase
    {
        public override async Task ListenLogin(LoginRequest request, IServerStreamWriter<LoginResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                while (pushQueue.TryDequeue(out var loginListen))
                {
                    await responseStream.WriteAsync(loginListen);
                }
            }
            await Task.CompletedTask;
        }
        public static void BagToClient(ServerCallContext context, LoginResponse loginListen)
        {
            pushQueue.Enqueue(loginListen);
        }
        static ConcurrentQueue<LoginResponse> pushQueue = new ConcurrentQueue<LoginResponse>();



        const string connectionString = "Server=localhost;Database=pyramid;Uid=root;Pwd=123456;";
        public override Task<LoginRsp> LoginIn(LoginReq request, ServerCallContext context)
        {
            var rsp = RoleSQLHasNickName(request.NickName);
            if (rsp != null && rsp.Id > 0)
            {
                BagServiceLogic.AddItemDto(rsp.Id);
            }
            return Task.FromResult(rsp);
        }

        LoginRsp RoleSQLHasNickName(string nickName)
        {
            LoginRsp rsp = new LoginRsp();
            var listDic = MySqlUtils.Instance.QuerySQL_1("SELECT * FROM role WHERE  nickname = @nickName", "@nickName", nickName);
            for (int i = 0; i < listDic.Count; i++)
            {
                foreach (var dic in listDic[i])
                {
                    if (dic.Key == "id") { rsp.Id = (int)dic.Value; } // 根据列名将值赋给相应的属性
                    else if (dic.Key == "nickname") { rsp.NickName = dic.Value.ToString(); }
                }
            }
            return rsp;
        }

        public override Task<LogoutRsp> Logout(LogoutReq request, ServerCallContext context)
        {
            return Task.FromResult(new LogoutRsp());
        }
    }
}
