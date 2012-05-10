using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern TSP_User_*.
	///</summary>
	public static class UserDb
	{
		#region Public Members

		///<summary>Authenticate a username and password hash against the User table and return details about the user.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Authenticate.</remarks>
		///<param name="username">The Username of the user attempting to log in.</param>
		///<param name="passwordHash">The Password HASH of the user attempting to log in</param>
		///<param name="id">The Id of the User attempting to log in.</param>
		///<param name="userGroup_Id">The UserGroup_Id of the User attempting to log in.</param>
		public static void Authenticate(string username, byte[] passwordHash, ref Guid? id, ref Guid? userGroup_Id)
		{
			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildAuthenticateCommand(username, passwordHash, id, userGroup_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
					if (cmd.Parameters["@Id"].Value != DBNull.Value)
						id = (Guid?)cmd.Parameters["@Id"].Value;
					if (cmd.Parameters["@UserGroup_Id"].Value != DBNull.Value)
						userGroup_Id = (Guid?)cmd.Parameters["@UserGroup_Id"].Value;
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Authenticate a username and password hash against the User table and return details about the user.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Authenticate.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="username">The Username of the user attempting to log in.</param>
		///<param name="passwordHash">The Password HASH of the user attempting to log in</param>
		///<param name="id">The Id of the User attempting to log in.</param>
		///<param name="userGroup_Id">The UserGroup_Id of the User attempting to log in.</param>
		public static void Authenticate(string connectionString, string username, byte[] passwordHash, ref Guid? id, ref Guid? userGroup_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildAuthenticateCommand(username, passwordHash, id, userGroup_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
					if (cmd.Parameters["@Id"].Value != DBNull.Value)
						id = (Guid?)cmd.Parameters["@Id"].Value;
					if (cmd.Parameters["@UserGroup_Id"].Value != DBNull.Value)
						userGroup_Id = (Guid?)cmd.Parameters["@UserGroup_Id"].Value;
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Authenticate a username and password hash against the User table and return details about the user.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Authenticate.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="username">The Username of the user attempting to log in.</param>
		///<param name="passwordHash">The Password HASH of the user attempting to log in</param>
		///<param name="id">The Id of the User attempting to log in.</param>
		///<param name="userGroup_Id">The UserGroup_Id of the User attempting to log in.</param>
		public static void Authenticate(SqlTransaction transaction, string username, byte[] passwordHash, ref Guid? id, ref Guid? userGroup_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Authenticate limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildAuthenticateCommand(username, passwordHash, id, userGroup_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
if (cmd.Parameters["@Id"].Value != DBNull.Value)
	id = (Guid?)cmd.Parameters["@Id"].Value;
if (cmd.Parameters["@UserGroup_Id"].Value != DBNull.Value)
	userGroup_Id = (Guid?)cmd.Parameters["@UserGroup_Id"].Value;
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Deletes a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Delete.</remarks>
		///<param name="id">The Id of User</param>
		public static void Delete(Guid? id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildDeleteCommand(id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of User</param>
		public static void Delete(string connectionString, Guid? id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildDeleteCommand(id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of User</param>
		public static void Delete(SqlTransaction transaction, Guid? id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildDeleteCommand(id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Inserts a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Insert.</remarks>
		///<param name="id">The Id of User</param>
		///<param name="username">The Username of User</param>
		///<param name="passwordHash">The PasswordHash of User</param>
		///<param name="passwordHint">The PasswordHint of User</param>
		///<param name="language_Code">The Language_Code of User</param>
		///<param name="description">The Description of User</param>
		///<param name="userGroup_Id">The UserGroup_Id of User</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void Insert(Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Description to a maximum length of 512.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id, statusId, createdUserId, uTCCreatedDate))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of User</param>
		///<param name="username">The Username of User</param>
		///<param name="passwordHash">The PasswordHash of User</param>
		///<param name="passwordHint">The PasswordHint of User</param>
		///<param name="language_Code">The Language_Code of User</param>
		///<param name="description">The Description of User</param>
		///<param name="userGroup_Id">The UserGroup_Id of User</param>
		///<param name="picture">The Picture of User</param>
		///<param name="backOfficeUser">The BackOfficeUser of User</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void Insert(string connectionString, Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Description to a maximum length of 512.", "description");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id, statusId, createdUserId, uTCCreatedDate))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of User</param>
		///<param name="username">The Username of User</param>
		///<param name="passwordHash">The PasswordHash of User</param>
		///<param name="passwordHint">The PasswordHint of User</param>
		///<param name="language_Code">The Language_Code of User</param>
		///<param name="description">The Description of User</param>
		///<param name="userGroup_Id">The UserGroup_Id of User</param>
		///<param name="picture">The Picture of User</param>
		///<param name="backOfficeUser">The BackOfficeUser of User</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void Insert(SqlTransaction transaction, Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Insert limits parameter @Description to a maximum length of 512.", "description");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildInsertCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id, statusId, createdUserId, uTCCreatedDate))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retreives all admin users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAdminUsers.</remarks>
		///<param name="adminUserGroupId">The admin user group id.</param>
		public static SqlDataReader SelectAdminUsers(Guid? adminUserGroupId)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAdminUsersCommand(adminUserGroupId))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retreives all admin users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAdminUsers.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="adminUserGroupId">The admin user group id.</param>
		public static SqlDataReader SelectAdminUsers(string connectionString, Guid? adminUserGroupId)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAdminUsersCommand(adminUserGroupId))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves all the records from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAll.</remarks>
        public static SqlDataReader SelectAll()
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand())
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves all the records from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAll.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		public static SqlDataReader SelectAll(string connectionString)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand())
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

        public static SqlDataReader Search(string name, string email, string username)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSearchCommand(name, email, username))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader Search(string name, string email, string username, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSearchCommand(name, email, username))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader SelectByUserGroupId(Guid userGroupId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectByUserGroupIdCommand(userGroupId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader SelectBySubEventId(Guid? userGroupId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectBySubEventIdCommand(userGroupId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader SelectByGroupingId(Guid? userGroupId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectByGroupingIdCommand(userGroupId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader SelectByAttendeeGuestTypeId(int? attendeeTypeId, int? guestTypeId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectByAttendeeGuestTypeIdCommand(attendeeTypeId, guestTypeId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retreives all admin users.</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAdminUsers.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="adminUserGroupId">The admin user group id.</param>
        public static SqlDataReader SelectByUserGroupId(string connectionString, Guid userGroupId)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectByUserGroupIdCommand(userGroupId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static SqlDataReader SelectBySubEventGroupId(Guid? subEvent, Guid? groupingId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;

            using (SqlCommand cmd = BuildSelectBySubEventGroupIdCommand(subEvent, groupingId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

		///<summary>Retrieve all back office users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectBackOfficeById.</remarks>
		///<param name="id">The id of the user.</param>
		public static SqlDataReader SelectBackOfficeById(Guid? id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectBackOfficeByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieve all back office users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectBackOfficeById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The id of the user.</param>
		public static SqlDataReader SelectBackOfficeById(string connectionString, Guid? id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectBackOfficeByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
		///<param name="id">The Id of User</param>
		public static SqlDataReader SelectById(Guid? id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of User</param>
		public static SqlDataReader SelectById(string connectionString, Guid? id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

        ///<summary>Retrieves a record from [dbo].[User].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
        ///<param name="id">The Id of User</param>
        public static SqlDataReader SelectLikeId(string id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectLikeIdCommand(id))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[User].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of User</param>
        public static SqlDataReader SelectLikeId(string connectionString, string id)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectLikeIdCommand(id))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

		///<summary>Select a User by Username (This method should only be called to authenticate a User on Login!).</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectByUsername.</remarks>
		///<param name="username">The Username of the User to Select.</param>
		public static SqlDataReader SelectByUsername(string username)
		{
			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_SelectByUsername limits parameter @Username to a maximum length of 256.", "username");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByUsernameCommand(username))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Select a User by Username (This method should only be called to authenticate a User on Login!).</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectByUsername.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="username">The Username of the User to Select.</param>
		public static SqlDataReader SelectByUsername(string connectionString, string username)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_SelectByUsername limits parameter @Username to a maximum length of 256.", "username");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByUsernameCommand(username))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Updates a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Update.</remarks>
		///<param name="id"></param>
		///<param name="username"></param>
		///<param name="passwordHash"></param>
		///<param name="passwordHint"></param>
		///<param name="language_Code"></param>
		///<param name="description"></param>
		///<param name="userGroup_Id"></param>
		///<param name="picture"></param>
		public static void Update(Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id)
		{
			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Description to a maximum length of 512.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildUpdateCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id"></param>
		///<param name="username"></param>
		///<param name="passwordHash"></param>
		///<param name="passwordHint"></param>
		///<param name="language_Code"></param>
		///<param name="description"></param>
		///<param name="userGroup_Id"></param>
		///<param name="picture"></param>
		public static void Update(string connectionString, Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, string picture)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Description to a maximum length of 512.", "description");
			if ((picture != null) && (picture.Length > 1024))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Picture to a maximum length of 1024.", "picture");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildUpdateCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id"></param>
		///<param name="username"></param>
		///<param name="passwordHash"></param>
		///<param name="passwordHint"></param>
		///<param name="language_Code"></param>
		///<param name="description"></param>
		///<param name="userGroup_Id"></param>
		///<param name="picture"></param>
		public static void Update(SqlTransaction transaction, Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, string picture)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((username != null) && (username.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Username to a maximum length of 256.", "username");
			if ((passwordHash != null) && (passwordHash.Length > 64))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHash to a maximum length of 64.", "passwordHash");
			if ((passwordHint != null) && (passwordHint.Length > 256))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @PasswordHint to a maximum length of 256.", "passwordHint");
			if ((language_Code != null) && (language_Code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Language_Code to a maximum length of 2.", "language_Code");
			if ((description != null) && (description.Length > 512))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Description to a maximum length of 512.", "description");
			if ((picture != null) && (picture.Length > 1024))
				throw new ArgumentException("Stored procedure TSP_User_Update limits parameter @Picture to a maximum length of 1024.", "picture");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildUpdateCommand(id, username, passwordHash, passwordHint, language_Code, description, userGroup_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Authenticate a username and password hash against the User table and return details about the user.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Authenticate.</remarks>
		///<param name="username">The Username of the user attempting to log in.</param>
		///<param name="passwordHash">The Password HASH of the user attempting to log in</param>
		///<param name="id">The Id of the User attempting to log in.</param>
		///<param name="userGroup_Id">The UserGroup_Id of the User attempting to log in.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildAuthenticateCommand(string username, byte[] passwordHash, Guid? id, Guid? userGroup_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_Authenticate");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 256);
			param.Value = username;
			param = cmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 64);
			param.Value = passwordHash;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Direction = ParameterDirection.InputOutput;
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Direction = ParameterDirection.InputOutput;
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Deletes a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Delete.</remarks>
		///<param name="id">The Id of User</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildDeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Insert.</remarks>
		///<param name="id">The Id of User</param>
		///<param name="username">The Username of User</param>
		///<param name="passwordHash">The PasswordHash of User</param>
		///<param name="passwordHint">The PasswordHint of User</param>
		///<param name="language_Code">The Language_Code of User</param>
		///<param name="description">The Description of User</param>
		///<param name="userGroup_Id">The UserGroup_Id of User</param>
		///<param name="picture">The Picture of User</param>
		///<param name="backOfficeUser">The BackOfficeUser of User</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildInsertCommand(Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 256);
			param.Value = username;
			param = cmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 64);
			param.Value = passwordHash;
			param = cmd.Parameters.Add("@PasswordHint", SqlDbType.NVarChar, 256);
			param.Value = passwordHint;
			param = cmd.Parameters.Add("@Language_Code", SqlDbType.Char, 2);
			param.Value = language_Code;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 512);
			param.Value = description;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@CreatedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (createdUserId.HasValue) ? (object)createdUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCCreatedDate", SqlDbType.DateTime);
			param.Value = (uTCCreatedDate.HasValue) ? (object)uTCCreatedDate.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retreives all admin users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAdminUsers.</remarks>
		///<param name="adminUserGroupId">The admin user group id.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectAdminUsersCommand(Guid? adminUserGroupId)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_SelectAdminUsers");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@AdminUserGroupId", SqlDbType.UniqueIdentifier);
			param.Value = (adminUserGroupId.HasValue) ? (object)adminUserGroupId.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("TSP_User_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;


			return cmd;
		}

        ///<summary>Retrieves all the records from [dbo].[User].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_Search.</remarks>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSearchCommand(string name, string email, string username)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_Search");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            param.Value = name;
            param = cmd.Parameters.Add("@Email", SqlDbType.VarChar);
            param.Value = email;
            param = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
            param.Value = username;

            return cmd;
        }

		///<summary>Retrieve all back office users.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectBackOfficeById.</remarks>
		///<param name="id">The id of the user.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectBackOfficeByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_SelectBackOfficeById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[User].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
		///<param name="id">The Id of User</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            var test = id.ToString();
			//param.Value = (id.HasValue) ? id.ToString() : DBNull.Value;
            param.Value = id;
			return cmd;


		}

        ///<summary>Retrieves a record from [dbo].[User].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
        ///<param name="id">The Id of User</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectLikeIdCommand(string id)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectLikeId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            param.Value = id;
            return cmd;
        }

        ///<summary>Retrieves a record from [dbo].[User].</summary>
        ///<remarks>This method maps directly onto the stored procedure TSP_User_SelectById.</remarks>
        ///<param name="id">The Id of User</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByUserGroupIdCommand(Guid usergroupid)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectByUserGroupId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@UserGroupId", SqlDbType.UniqueIdentifier);
            param.Value = usergroupid;

            return cmd;
        }

        private static SqlCommand BuildSelectBySubEventIdCommand(Guid? usergroupid)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectBySubEventId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@SubEventId", SqlDbType.UniqueIdentifier);
            param.Value = usergroupid;

            return cmd;
        }

        private static SqlCommand BuildSelectByGroupingIdCommand(Guid? usergroupid)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectByGroupingId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@GroupingId", SqlDbType.UniqueIdentifier);
            param.Value = usergroupid;

            return cmd;
        }

        private static SqlCommand BuildSelectByAttendeeGuestTypeIdCommand(int? attendeeTypeId, int? guestTypeId)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectByAttendeeGuestTypeId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@AttendeeTypeId", SqlDbType.Int);
            param.Value = (attendeeTypeId.HasValue) ? (object)attendeeTypeId.Value : DBNull.Value;
            param = cmd.Parameters.Add("@GuestTypeId", SqlDbType.Int);
            param.Value = (guestTypeId.HasValue) ? (object)guestTypeId.Value : DBNull.Value;

            return cmd;
        }

        private static SqlCommand BuildSelectBySubEventGroupIdCommand(Guid? subEventid, Guid? groupid)
        {
            SqlCommand cmd = new SqlCommand("TSP_User_SelectBySubEventGroupId");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@SubEventId", SqlDbType.UniqueIdentifier);
            param.Value = (subEventid.HasValue) ? (object)subEventid.Value : DBNull.Value;
            param = cmd.Parameters.Add("@GroupingId", SqlDbType.UniqueIdentifier);
            param.Value = (groupid.HasValue) ? (object)groupid.Value : DBNull.Value;

            return cmd;
        }

		///<summary>Select a User by Username (This method should only be called to authenticate a User on Login!).</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_SelectByUsername.</remarks>
		///<param name="username">The Username of the User to Select.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByUsernameCommand(string username)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_SelectByUsername");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 256);
			param.Value = username;
			return cmd;
		}

		///<summary>Updates a [dbo].[User] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_User_Update.</remarks>
		///<param name="id"></param>
		///<param name="username"></param>
		///<param name="passwordHash"></param>
		///<param name="passwordHint"></param>
		///<param name="language_Code"></param>
		///<param name="description"></param>
		///<param name="userGroup_Id"></param>
		///<param name="picture"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildUpdateCommand(Guid? id, string username, byte[] passwordHash, string passwordHint, string language_Code, string description, Guid? userGroup_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_User_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 256);
			param.Value = username;
			param = cmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 64);
			param.Value = passwordHash;
			param = cmd.Parameters.Add("@PasswordHint", SqlDbType.NVarChar, 256);
			param.Value = passwordHint;
			param = cmd.Parameters.Add("@Language_Code", SqlDbType.Char, 2);
			param.Value = language_Code;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 512);
			param.Value = description;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(UserDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
