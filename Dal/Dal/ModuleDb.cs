using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
    ///<summary>
    ///A generated Data Access Layer class containing all stored procedures matching the pattern sp_Module*.
    ///</summary>
    public static class ModuleDb
    {
        #region Public Members

        ///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
        public static SqlDataReader SelectAll(string languageCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand(languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        public static SqlDataReader SelectAll(string connectionString, string languageCode)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand(languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectById(Guid id, string languageCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByIdCommand(id, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectById(string connectionString, Guid id, string languageCode)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByIdCommand(id, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserGroupId(Guid userGroupId, string languageCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserGroupIdCommand(userGroupId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserGroupId(string connectionString, Guid userGroupId, string languageCode)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserGroupIdCommand(userGroupId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectByUserId.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserId(Guid userId, string languageCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserIdCommand(userId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectByUserId.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserId(string connectionString, Guid userId, string languageCode)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserIdCommand(userId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserGroupIdAndModuleId(Guid userGroupId, Guid moduleId, string languageCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserGroupIdAndModuleIdCommand(userGroupId, moduleId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of UserGroup</param>
        public static SqlDataReader SelectByUserGroupIdAndModuleId(string connectionString, Guid userGroupId, Guid moduleId, string languageCode)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByUserGroupIdAndModuleIdCommand(userGroupId, moduleId, languageCode))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        #endregion

        #region Private Members


        ///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectAllCommand(string languageCode)
        {
            SqlCommand cmd = new SqlCommand("TSP_Module_SelectAll");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar);
            param.Value = languageCode;
            return cmd;
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByIdCommand(Guid id, string languageCode)
        {
            SqlCommand cmd = new SqlCommand("TSP_Module_SelectById");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            param.Value = id;
            param = cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar);
            param.Value = languageCode;
            return cmd;
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByUserGroupIdCommand(Guid userGroupId, string languageCode)
        {
            SqlCommand cmd = new SqlCommand("TSP_Module_SelectByUserGroupId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@UserGroupId", SqlDbType.UniqueIdentifier);
            param.Value = userGroupId;
            param = cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar);
            param.Value = languageCode;
            return cmd;
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByUserIdCommand(Guid userId, string languageCode)
        {
            SqlCommand cmd = new SqlCommand("TSP_Module_SelectByUserId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
            param.Value = userId;
            param = cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar);
            param.Value = languageCode;
            return cmd;
        }

        ///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
        ///<param name="id">The Id of UserGroup</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByUserGroupIdAndModuleIdCommand(Guid userGroupId, Guid moduleId, string languageCode)
        {
            SqlCommand cmd = new SqlCommand("TSP_Module_SelectByUserGroupIdAndModuleId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@UserGroupId", SqlDbType.UniqueIdentifier);
            param.Value = userGroupId;
            param = cmd.Parameters.Add("@ModuleId", SqlDbType.UniqueIdentifier);
            param.Value = moduleId;
            param = cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar);
            param.Value = languageCode;
            return cmd;
        }

        #endregion

        #region Internal Members

        internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(ModuleDb).FullName, e.Errors[0].Procedure));
        }

        #endregion
    }
}
