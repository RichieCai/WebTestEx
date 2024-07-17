using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Generally
{
    public class MsDBConn_Dapper
    {
        IDbConnection _conn = null;

        public MsDBConn_Dapper(IDbConnection conn)
        {
            _conn = conn;
        }
        public async Task<IEnumerable<T>> QueryData<T>(string sSqlCmd)
        {
            IEnumerable<T> tResult = null;
            try
            {
                using (_conn)
                {
                    _conn.Open();
                    tResult = await _conn.QueryAsync<T>(sSqlCmd, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return tResult;
        }
    }
}
