using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Plataforma
{

    public class SqlHelper
    {


        //Private DBConnectionString As String = "Data Source=lenin-lt\sqlexpress;Initial Catalog=asamblea;user id=sa;password=pkm;persist security info=True; packet size=4096"
        //Private DBConnectionString As String = "Data Source=lenin-lt\sqlexpress;Initial Catalog=CCESQL;Integrated Security=SSPI;Persist Security Info=False;packet size=4096"
        //Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AG-2007;Data Source=lenin-lt\sqlexpress

        private string DBConnectionString = "";

        private string strSQLError;
        protected string ConnectionString
        {
            get { return DBConnectionString; }
            set { DBConnectionString = value; }
        }

        protected string LastError
        {
            get { return strSQLError; }
        }


        protected SqlHelper(string DataBaseName, string DataBaseServer, string DataBaseUser, string DataBasePassword)
        {
            DBConnectionString = "Data Source=" + DataBaseServer + ";Initial Catalog=" + DataBaseName + ";user id=" + DataBaseUser + ";password=" + DataBasePassword + ";persist security info=True; packet size=4096";
            //DBConnectionString = "Data Source=CLAUDIO-PC\\SRVWSQLVS;Initial Catalog=bb;Integrated Security=SSPI;";
            
        }

        protected SqlHelper(string ConnectionString)
        {
            DBConnectionString = ConnectionString;
        }

        protected SqlHelper()
        {
            //DBConnectionString = "Data Source=CLAUDIO-PC\\SRVWSQLVS;Initial Catalog=bb;Integrated Security=SSPI;";
        }

        public bool TestConnection()
        {
            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);

                ConnectionSQL.Open();
                ConnectionSQL.Close();
                return true;
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                return false;
            }
        }

        protected bool SQLExecuteNonQuery(string strSQLStatement)
        {
            try
            {
                SqlCommand CommandSQL = new SqlCommand(strSQLStatement);
                return SQLExecuteNonQuery(CommandSQL);
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                return false;
            }
        }

        protected bool SQLExecuteNonQuery(System.Data.SqlClient.SqlCommand CommandSQL)
        {
            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);


                CommandSQL.Connection = ConnectionSQL;
                ConnectionSQL.Open();
                CommandSQL.ExecuteNonQuery();
                ConnectionSQL.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected System.Data.DataSet GetDataSet(string strSQLStatement)
        {
            SqlCommand CommandSQL = new SqlCommand(strSQLStatement);
            return GetDataSet(CommandSQL);
        }

        protected System.Data.DataSet GetDataSet(System.Data.SqlClient.SqlCommand CommandSQL)
        {
            System.Data.DataSet dsSelectStatement = new System.Data.DataSet();

            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);

                System.Data.SqlClient.SqlDataAdapter daSelectStatement;

                CommandSQL.Connection = ConnectionSQL;
                ConnectionSQL.Open();
                daSelectStatement = new System.Data.SqlClient.SqlDataAdapter(CommandSQL);
                daSelectStatement.Fill(dsSelectStatement);
                daSelectStatement.Dispose();
                ConnectionSQL.Close();

                return dsSelectStatement;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                //System.Windows.Forms.MessageBox.Show("Error:" & ex.Message)
            }
            catch (SystemException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                //System.Windows.Forms.MessageBox.Show("Error:" & ex.Message)
            }
            return dsSelectStatement;
        }

        protected System.Data.DataSet GetDataSetSP(string strSQLStatement)
        {
            SqlCommand CommandSQL = new SqlCommand(strSQLStatement);
            return GetDataSetSP(CommandSQL);
        }

        protected System.Data.DataSet GetDataSetSP(System.Data.SqlClient.SqlCommand CommandSQL)
        {

            SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);

            System.Data.SqlClient.SqlDataAdapter daSelectStatement = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.DataSet dsSelectStatement = new System.Data.DataSet();
            try
            {
                CommandSQL.Connection = ConnectionSQL;
                ConnectionSQL.Open();
                daSelectStatement = new System.Data.SqlClient.SqlDataAdapter(CommandSQL);
                daSelectStatement.Fill(dsSelectStatement);
                daSelectStatement.Dispose();
                ConnectionSQL.Close();

            }
            catch (SqlException ex)
            {
                Console.Write("Exception: " + ex.Message);
                EventLog log = new EventLog();
                log.Source = ".NET Runtime";
                log.WriteEntry(ex.Message);

                Debug.WriteLine("ERROR!" + ex.Message);
            }

            return dsSelectStatement;

        }

        protected object SQLExecuteScalar(System.Data.SqlClient.SqlCommand CommandSQL)
        {
            object ReturnObject = null;
            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);


                CommandSQL.Connection = ConnectionSQL;
                ConnectionSQL.Open();
                ReturnObject = CommandSQL.ExecuteScalar();
                ConnectionSQL.Close();


            }
            catch (SystemException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                //System.Windows.Forms.MessageBox.Show("Error:" & ex.Message)
            }
            return ReturnObject;
        }

        protected SqlDataReader SQLExecuteReader(System.Data.SqlClient.SqlCommand CommandSQL, System.Data.CommandBehavior CmdBehavior = System.Data.CommandBehavior.Default)
        {
            SqlDataReader DataReaderSQL = null;
            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);

                CommandSQL.Connection = ConnectionSQL;
                ConnectionSQL.Open();
                DataReaderSQL = CommandSQL.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (SystemException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                //System.Windows.Forms.MessageBox.Show("Error:" & ex.Message)
            }

            return DataReaderSQL;

        }

        protected System.Data.SqlClient.SqlDataAdapter GetDataAdapter(string strSQLStatement)
        {
            System.Data.SqlClient.SqlDataAdapter daSelectStatement = null;
            try
            {
                SqlConnection ConnectionSQL = new SqlConnection(DBConnectionString);

                daSelectStatement = new System.Data.SqlClient.SqlDataAdapter(strSQLStatement, ConnectionSQL);

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: " & ex.Message & vbCrLf & ex.StackTrace)
                //System.Windows.Forms.MessageBox.Show("Error:" & ex.Message)
            }
            return daSelectStatement;

        }

    }
}
