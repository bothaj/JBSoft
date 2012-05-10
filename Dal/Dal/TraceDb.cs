using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal.Dal
{
    /// <summary>
    /// This class is used to access the Trace table on any project. Used for performace tracing.
    /// </summary>
    public static class TraceDb
    {
        #region Public Members

        ///<summary>Insert a PerformanceTest record.</summary>
        ///<remarks>This method maps directly onto the stored procedure MZ_PerformanceTrace_Insert.</remarks>
        ///<param name="methodName">The name of the method called.</param>
        ///<param name="parameters">the parameters of the method.</param>
        ///<param name="executionTime">the execution time of the method call.</param>
        ///<param name="returnValue">the return value of the method call.</param>
        ///<param name="collectionCount">the return count of the collection.</param>
        ///<param name="user_Id">The user id of the logged in user.</param>
        public static void Insert(string methodName, object parameters, int? executionTime, string returnValue, int? collectionCount, Guid? user_Id)
        {
            if ((methodName != null) && (methodName.Length > 256))
                throw new ArgumentException("Stored procedure T_Trace_Insert limits parameter @MethodName to a maximum length of 256.", "methodName");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertCommand(methodName, parameters, executionTime, returnValue, collectionCount, user_Id))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Insert a PerformanceTest record.</summary>
        ///<remarks>This method maps directly onto the stored procedure MZ_PerformanceTrace_Insert.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="methodName">The name of the method called.</param>
        ///<param name="parameters">the parameters of the method.</param>
        ///<param name="executionTime">the execution time of the method call.</param>
        ///<param name="returnValue">the return value of the method call.</param>
        ///<param name="collectionCount">the return count of the collection.</param>
        ///<param name="user_Id">The user id of the logged in user.</param>
        public static void Insert(string connectionString, string methodName, object parameters, int? executionTime, string returnValue, int? collectionCount, Guid? user_Id)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            if ((methodName != null) && (methodName.Length > 256))
                throw new ArgumentException("Stored procedure T_Trace_Insert limits parameter @MethodName to a maximum length of 256.", "methodName");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertCommand(methodName, parameters, executionTime, returnValue, collectionCount, user_Id))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Insert a PerformanceTest record.</summary>
        ///<remarks>This method maps directly onto the stored procedure MZ_PerformanceTrace_Insert.</remarks>
        ///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
        ///<param name="methodName">The name of the method called.</param>
        ///<param name="parameters">the parameters of the method.</param>
        ///<param name="executionTime">the execution time of the method call.</param>
        ///<param name="returnValue">the return value of the method call.</param>
        ///<param name="collectionCount">the return count of the collection.</param>
        ///<param name="user_Id">The user id of the logged in user.</param>
        public static void Insert(SqlTransaction transaction, string methodName, object parameters, int? executionTime, string returnValue, int? collectionCount, Guid? user_Id)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            if ((methodName != null) && (methodName.Length > 256))
                throw new ArgumentException("Stored procedure T_Trace_Insert limits parameter @MethodName to a maximum length of 256.", "methodName");
            SqlConnection connection = transaction.Connection;
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildInsertCommand(methodName, parameters, executionTime, returnValue, collectionCount, user_Id))
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                /*int rowsAffected = */
                cmd.ExecuteNonQuery();
            } // using SqlCommand
            connection.InfoMessage -= InfoMessageHandler;
        }

        #endregion

        #region Private Members

        ///<summary>Insert a PerformanceTest record.</summary>
        ///<remarks>This method maps directly onto the stored procedure MZ_PerformanceTrace_Insert.</remarks>
        ///<param name="methodName">The name of the method called.</param>
        ///<param name="parameters">the parameters of the method.</param>
        ///<param name="executionTime">the execution time of the method call.</param>
        ///<param name="returnValue">the return value of the method call.</param>
        ///<param name="collectionCount">the return count of the collection.</param>
        ///<param name="user_Id">The user id of the logged in user.</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildInsertCommand(string methodName, object parameters, int? executionTime, string returnValue, int? collectionCount, Guid? user_Id)
        {
            SqlCommand cmd = new SqlCommand("T_Trace_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@MethodName", SqlDbType.VarChar, 256);
            param.Value = methodName;
            param = cmd.Parameters.Add("@Parameters", SqlDbType.Xml);
            param.Value = parameters;
            param = cmd.Parameters.Add("@ExecutionTime", SqlDbType.Int);
            param.Value = (executionTime.HasValue) ? (object)executionTime.Value : DBNull.Value;
            param = cmd.Parameters.Add("@ReturnValue", SqlDbType.VarChar);
            param.Value = returnValue;
            param = cmd.Parameters.Add("@CollectionCount", SqlDbType.Int);
            param.Value = (collectionCount.HasValue) ? (object)collectionCount.Value : DBNull.Value;
            param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
            param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
            return cmd;
        }

        #endregion

        #region Internal Members

        internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(TraceDb).FullName, e.Errors[0].Procedure));
        }

        #endregion
    }
}
