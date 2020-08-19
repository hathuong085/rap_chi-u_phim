using System.Data;
using System.Data.SqlClient;

namespace Cimena.DAL
{
    public class BaseRepository
    {
        protected IDbConnection conn;
        public BaseRepository()
        {
            string connectionString = @"Data Source=desktop-e754eje\sqlexpress;Initial Catalog=MovieDB;Integrated Security=True";
           // string connectionString = @"workstation id=databasecinemanpt.mssql.somee.com;packet size=4096;user id=CinemaNPT_SQLLogin_1;pwd=eqhaomi99y;data source=databasecinemanpt.mssql.somee.com;persist security info=False;initial catalog=databasecinemanpt";
            conn = new SqlConnection(connectionString);
        }
    }
}
