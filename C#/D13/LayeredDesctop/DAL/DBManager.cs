



using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace DAL
{
    public class DBManager
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sqlDA;
        DataTable Dtable;

        public DBManager()
        {
            try
            {
                
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PubCS"].ConnectionString);

                // establish connection
                cmd = new SqlCommand();
                cmd.Connection = conn;
                // specify command type 
                cmd.CommandType = CommandType.StoredProcedure;

                sqlDA = new SqlDataAdapter(cmd);
                Dtable = new DataTable();
            }
            catch
            {
                //
                Debug.WriteLine("can't access DB");
            }
           
        }

        // will implement 3 types of Method that return diffrenet data type // int , object , DataTable 


        // @params => stored Procedure [from Business Layer]
        public int ExecuteNonQuery(string sp)
        {
            try
            {
                cmd.Parameters.Clear(); 
                cmd.CommandText = sp;

                if(conn.State != ConnectionState.Open)
                    conn.Open();
                
                return cmd.ExecuteNonQuery() ;

            }
            catch
            {
                return -1;
            }
            finally { 
                conn.Close();
            }
        }

        // using in update or delete or insert
        public int ExecuteNonQuery(string sp , Dictionary<string, object> ParmLst)
        {
            try
            {
                cmd.Parameters.Clear();
                foreach (var param in ParmLst)
                {
                    Debug.WriteLine(param.Value , param.Key);
                     cmd.Parameters.Add( new SqlParameter( param.Key, param.Value));
                }
                
                cmd.CommandText = sp;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                return cmd.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public object ExecuteScalar(string sp)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sp;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                return cmd.ExecuteScalar();

            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ExecuteDataTable(string sp)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sp;

                sqlDA.Fill(Dtable);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                return Dtable;

            }
            catch
            {
                return new DataTable();
            }
            finally
            {
                conn.Close();
            }
        }

    }

}