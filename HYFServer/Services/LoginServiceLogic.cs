using Grpc.Core;
using MySql.Data.MySqlClient;
using HYFServer;
using System.Collections.Concurrent;

namespace HYFServer.Services
{
    public class LoginServiceLogic : LoginService.LoginServiceBase
    {
        public override async Task ListenLogin(LoginRequest request, IServerStreamWriter<LoginResponse> responseStream, ServerCallContext context)
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
        public static void BagToClient(ServerCallContext context, LoginResponse shopListen)
        {
            pushQueue.Enqueue(shopListen);
        }
        static ConcurrentQueue<LoginResponse> pushQueue = new ConcurrentQueue<LoginResponse>();



        const string connectionString = "Server=localhost;Database=hyf;Uid=root;Pwd=123456;";
        public override Task<ResultRsp> Login(LoginReq request, ServerCallContext context)
        {
            var isExist = RoleSQLQuery(request.NickName);
            if (isExist)
            {
                BagServiceLogic.RoleBagInfo(context);
                BagServiceLogic.AddItemDto();
            }
            // Task.Yield();
            return Task.FromResult(new ResultRsp()
            {
                State=(isExist?1:0)
            });

        }

        bool RoleSQLQuery(string nickName)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("-------------open mysql-----------------");
                // 使用参数化查询以防止 SQL 注入
                string query = "SELECT * FROM role WHERE  nickname = @nickName";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nickName", nickName);
                    //cmd.Parameters.AddWithValue("@pwd", pwd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override Task<LogoutRsp> Logout(LogoutReq request, ServerCallContext context)
        {
            return Task.FromResult(new LogoutRsp());
        }
    }
}
