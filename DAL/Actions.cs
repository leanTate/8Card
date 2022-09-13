using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using BE.entites;
using BE.DTO;

namespace DAL
{
    public class Actions
    {
        public bool Transaction(transactionDto req) {
            try {
                ConectionDB connect = ConectionDB.Instance;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"UPDATE users set saldo+={req.amount} where cbu={req.destinatary}";
                sqlCmd.Connection = connect.sqlConnection;
                connect.OpenConnection();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = $"UPDATE users set saldo-={req.amount} where cbu={req.origin}";
                sqlCmd.ExecuteNonQuery();
                connect.CloseConnection();
                TransactionLogs(req);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        internal bool TransactionLogs(transactionDto req) {
            try
            {
                ConectionDB connect = ConectionDB.Instance;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into transactions(cbu_emisor,valor,cbu_receptor) values('{req.origin}',{req.amount},'{req.destinatary}')";
                sqlCmd.Connection = connect.sqlConnection;
                connect.OpenConnection();
                sqlCmd.ExecuteNonQuery();
                connect.CloseConnection();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
