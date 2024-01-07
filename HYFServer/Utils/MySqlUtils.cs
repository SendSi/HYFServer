using MySql.Data.MySqlClient;
namespace HYFServer.Utils
{
    public class MySqlUtils : Singleton<MySqlUtils>
    {
        const string connectionString = "Server=localhost;Database=hyf;Uid=root;Pwd=123456;";
        public void OpenMySql()//测试
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// 查询 一个参数的
        /// </summary>
        /// <param name="query">查询sql</param>
        public List<Dictionary<string, object>> QuerySQL_1(string query, string key1, object value1)
        {
            var result = new List<Dictionary<string, object>>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                //string query = "SELECT * FROM `bag` where roleId=@roleId"; // 使用参数化查询以防止 SQL 注入
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue(key1, value1);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dic = new Dictionary<string, object>();      // 遍历所有字段
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i); // 获取列名
                                object columnValue = reader.GetValue(i); // 获取列值
                                dic[columnName] = columnValue;
                            }
                            result.Add(dic);
                        }
                    }
                }
            }
            Console.WriteLine($"-查询MySQL---{query}--{key1}---{value1}-----查询结果:{result.Count}条");
            return result;
        }


    }
}
