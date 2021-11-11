using System.Data.SqlClient;
using Dapper;

namespace StoringSqlFilesInResources
{
    public class GetUserQuery
    {
        private string _query = SqlScripts.GetUserQuery;

        public async Task<User> Execute(int userId)
        {
            using (var connection = new SqlConnection("MyConnectionString"))
            {
                var user = await connection.QuerySingleAsync<User>(_query, new
                {
                    userId
                });

                return user;
            }
        }
    }
}