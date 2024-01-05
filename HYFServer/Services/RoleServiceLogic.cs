using Grpc.Core;
using MySql.Data.MySqlClient;
using HYFServer;
using System.Collections.Concurrent;

namespace HYFServer.Services
{
    public class RoleServiceLogic : RoleService.RoleServiceBase
    {
        const string connectionString = "Server=localhost;Database=hyf;Uid=root;Pwd=123456;";
        private readonly ILogger<RoleServiceLogic> _logger;
        public RoleServiceLogic(ILogger<RoleServiceLogic> logger)
        {
            _logger = logger;
        }

        public override async Task ListenRole(RoleRequest request, IServerStreamWriter<RoleResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                while (pushQueue.TryDequeue(out var roleListen))
                {
                    await responseStream.WriteAsync(roleListen);
                }
            }
            await Task.CompletedTask;
        }
        public static void RoleToClient(ServerCallContext context, RoleResponse roleListen)
        {
            pushQueue.Enqueue(roleListen);
        }
        static ConcurrentQueue<RoleResponse> pushQueue = new ConcurrentQueue<RoleResponse>();

        public override Task<RoleInfoResponse> RoleInfo(RoleInfoRequest request, ServerCallContext context)
        {
            var state = DataSQL(request.Uid) ? 1 : 0;
            if (state == 1)
            {
                //BagServiceLogic.RoleBagInfo(context);
            }

            return Task.FromResult(new RoleInfoResponse
            {
                Info = new RoleInfo()
                {
                    Age = 1,
                    Uid = "fd",
                    Gender = 1,
                    Lv = 10,
                    Nickname = "名字"
                }
            });
        }

        public override Task<RoleUpLvResponse> RoleUpLv(RoleUpLvRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RoleUpLvResponse
            {
                Info = new RoleInfo()
                {
                    Age = 1,
                    Uid = "fd",
                    Gender = 1,
                    Lv = 100,
                    Nickname = "名字"
                }
            });
        }

        public override Task<RoleAddVipResponse> RoleAddVip(RoleAddVipRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RoleAddVipResponse
            {
                Info = new RoleInfo()
                {
                    Age = 1,
                    Uid = "fd",
                    Gender = 1,
                    Lv = 100,
                    Nickname = "vip啦....."
                }
            });
        }


        //暂不校验密码了
        bool DataSQL(string account)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("-------------open mysql-----------------");
                // 使用参数化查询以防止 SQL 注入
                string query = "SELECT * FROM role WHERE  account = @account";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@account", account);
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
    }


}
