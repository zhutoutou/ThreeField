using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using ZIT.LOG;
using System.Data.OracleClient;
using ZIT.ThreeField.Model;

namespace ZIT.ThreeField.Utility
{
    /// <summary>
    /// 120库DB120Help
    /// </summary>
    public class DB120Help
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string strConns = SysParameters.DBConnectStringLocal;

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
        /// 查询一个记录
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static int OperationRecord(string sqlstr)
        {
            int intFlag = 0;
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConns))
                {
                    sqlConn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlstr;
                    intFlag = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return intFlag;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("OperationRecord", ex);
                return -1;
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
        public static DataTable Query(string sql)
        {
            using (OracleConnection conn = new OracleConnection(strConns))
            {
                DataTable ds = new DataTable();
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

        //20151211 修改人:朱星汉 修改内容:添加ExecuteSql的重载方法 
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

                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
        }

        //20151211 修改人:朱星汉 修改内容:添加ExecuteSql的重载方法 
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
