using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.OracleClient;



namespace ZIT.ThreeField.Utility
{
    public class DB120Helpcle
    {
        private static string strConns = SysParameters.DBConnectStringRemote;


        public static bool IsConnected()
        {
            bool bret = false;
            using (OracleConnection oc = new OracleConnection(strConns))
            {
                try
                {
                    oc.Open();
                    if (oc.State == ConnectionState.Open)
                    {
                        bret = true;
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(oe.Message);
                }
            }
            return bret;
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(strConns))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OracleException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(strConns))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    //try
                    //{
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}
                    //catch (OracleException E)
                    //{
                    //    throw new Exception(E.Message);
                    //}
                }
            }
        }

        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(strConns))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static bool ExecuteSqlTranResult(ArrayList SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(strConns))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return true;
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    return false;
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果(object)
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns></returns>
        public static object GetSingle(string sql)
        {
            using (OracleConnection conn = new OracleConnection(strConns))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        conn.Close();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value))) { return null; } else { return obj; }
                    }
                    catch (OracleException ex)
                    {
                        conn.Close();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }

        /// <summary>
        /// 执行查询语句， 返回DataSet
        /// </summary>
        /// <param name="sql">Sql查询语句</param>
        /// <returns></returns>
        public static DataSet Query(string sql)
        {
            using (OracleConnection conn = new OracleConnection(strConns))
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    OracleDataAdapter dapter = new OracleDataAdapter(sql, conn);
                    dapter.Fill(ds);
                }
                catch (OracleException ex)
                {
                    conn.Close();
                    throw new Exception(ex.ToString());
                }
                return ds;
            }
        }

        //查询
        public static DataTable GetRecord(string sql)
        {
            DataTable dt = new DataTable();
            try
            {

                using (OracleConnection sqlConn = new OracleConnection(strConns))
                {
                    sqlConn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    OracleDataAdapter oDA = new OracleDataAdapter(cmd);
                    oDA.Fill(dt);
                    sqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
