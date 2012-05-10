using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern TSP_UserGroup_*.
	///</summary>
	public static class UserGroupDb
	{
		#region Public Members

		///<summary>Deletes a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Delete.</remarks>
		///<param name="id">The Id of UserGroup</param>
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

		///<summary>Deletes a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of UserGroup</param>
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

		///<summary>Deletes a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of UserGroup</param>
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

		///<summary>Delete a Module from a Usergroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_DeleteModule.</remarks>
		///<param name="userGroup_Id">The UserGroup the module should be removed from.</param>
		///<param name="module_Id">The Module to remove.</param>
		///<param name="user_Id">The ID of the User performing the action.</param>
		public static void DeleteModule(Guid? userGroup_Id, Guid? module_Id, Guid? user_Id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildDeleteModuleCommand(userGroup_Id, module_Id, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Delete a Module from a Usergroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_DeleteModule.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="userGroup_Id">The UserGroup the module should be removed from.</param>
		///<param name="module_Id">The Module to remove.</param>
		///<param name="user_Id">The ID of the User performing the action.</param>
		public static void DeleteModule(string connectionString, Guid? userGroup_Id, Guid? module_Id, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildDeleteModuleCommand(userGroup_Id, module_Id, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Delete a Module from a Usergroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_DeleteModule.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="userGroup_Id">The UserGroup the module should be removed from.</param>
		///<param name="module_Id">The Module to remove.</param>
		///<param name="user_Id">The ID of the User performing the action.</param>
		public static void DeleteModule(SqlTransaction transaction, Guid? userGroup_Id, Guid? module_Id, Guid? user_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildDeleteModuleCommand(userGroup_Id, module_Id, user_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Inserts a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Insert.</remarks>
		///<param name="id">The Id of UserGroup</param>
		///<param name="description">The Description of UserGroup</param>
		///<param name="currency_Code">The Currency_Code of UserGroup</param>
		public static void Insert(Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertCommand(id, description, currency_Code, backOfficeGroup))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of UserGroup</param>
		///<param name="description">The Description of UserGroup</param>
		///<param name="currency_Code">The Currency_Code of UserGroup</param>
        public static void Insert(string connectionString, Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertCommand(id, description, currency_Code, backOfficeGroup))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of UserGroup</param>
		///<param name="description">The Description of UserGroup</param>
		///<param name="currency_Code">The Currency_Code of UserGroup</param>
        public static void Insert(SqlTransaction transaction, Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Insert limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildInsertCommand(id, description, currency_Code, backOfficeGroup))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Insert a security group Module association.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_InsertModule.</remarks>
		///<param name="userGroup_Id">The Id of the UserGroup.</param>
		///<param name="module_Id">The Id of the Module.</param>
		///<param name="user_Id">The ID of the User Calling the Stored Proc</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void InsertModule(Guid? userGroup_Id, Guid? module_Id, Guid? user_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertModuleCommand(userGroup_Id, module_Id, user_Id, statusId, createdUserId, uTCCreatedDate))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Insert a security group Module association.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_InsertModule.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="userGroup_Id">The Id of the UserGroup.</param>
		///<param name="module_Id">The Id of the Module.</param>
		///<param name="user_Id">The ID of the User Calling the Stored Proc</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void InsertModule(string connectionString, Guid? userGroup_Id, Guid? module_Id, Guid? user_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertModuleCommand(userGroup_Id, module_Id, user_Id, statusId, createdUserId, uTCCreatedDate))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Insert a security group Module association.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_InsertModule.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="userGroup_Id">The Id of the UserGroup.</param>
		///<param name="module_Id">The Id of the Module.</param>
		///<param name="user_Id">The ID of the User Calling the Stored Proc</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		public static void InsertModule(SqlTransaction transaction, Guid? userGroup_Id, Guid? module_Id, Guid? user_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildInsertModuleCommand(userGroup_Id, module_Id, user_Id, statusId, createdUserId, uTCCreatedDate))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
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

		///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
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

		///<summary>Retrieve all UserGroup records that a User.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAllLike.</remarks>
		///<param name="description">A Description pattern to retrieve.</param>
		///<param name="user_Id">The ID of the User.</param>
		public static SqlDataReader SelectAllLike(string description, Guid? user_Id)
		{
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_SelectAllLike limits parameter @Description to a maximum length of 256.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAllLikeCommand(description, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieve all UserGroup records that a User.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAllLike.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="description">A Description pattern to retrieve.</param>
		///<param name="user_Id">The ID of the User.</param>
		public static SqlDataReader SelectAllLike(string connectionString, string description, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_SelectAllLike limits parameter @Description to a maximum length of 256.", "description");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAllLikeCommand(description, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieve all Module records assigned to the User's UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAssignedModules.</remarks>
		///<param name="userGroup_Id">The ID of the UserGroup.</param>
		///<param name="user_Id">The ID of the User.</param>
		public static SqlDataReader SelectAssignedModules(Guid? userGroup_Id, Guid? user_Id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAssignedModulesCommand(userGroup_Id, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieve all Module records assigned to the User's UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAssignedModules.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="userGroup_Id">The ID of the UserGroup.</param>
		///<param name="user_Id">The ID of the User.</param>
		public static SqlDataReader SelectAssignedModules(string connectionString, Guid? userGroup_Id, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAssignedModulesCommand(userGroup_Id, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
		///<param name="id">The Id of UserGroup</param>
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

		///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of UserGroup</param>
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

		///<summary>Updates a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Update.</remarks>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="currency_Code"></param>
        public static void Update(Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildUpdateCommand(id, description, currency_Code, backOfficeGroup))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="currency_Code"></param>
        public static void Update(string connectionString, Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildUpdateCommand(id, description, currency_Code, backOfficeGroup))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="currency_Code"></param>
        public static void Update(SqlTransaction transaction, Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((currency_Code != null) && (currency_Code.Length > 3))
				throw new ArgumentException("Stored procedure TSP_UserGroup_Update limits parameter @Currency_Code to a maximum length of 3.", "currency_Code");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildUpdateCommand(id, description, currency_Code, backOfficeGroup))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Deletes a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Delete.</remarks>
		///<param name="id">The Id of UserGroup</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildDeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Delete a Module from a Usergroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_DeleteModule.</remarks>
		///<param name="userGroup_Id">The UserGroup the module should be removed from.</param>
		///<param name="module_Id">The Module to remove.</param>
		///<param name="user_Id">The ID of the User performing the action.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildDeleteModuleCommand(Guid? userGroup_Id, Guid? module_Id, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_DeleteModule");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Module_Id", SqlDbType.UniqueIdentifier);
			param.Value = (module_Id.HasValue) ? (object)module_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Insert.</remarks>
		///<param name="id">The Id of UserGroup</param>
		///<param name="description">The Description of UserGroup</param>
		///<param name="currency_Code">The Currency_Code of UserGroup</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildInsertCommand(Guid? id, string description, string currency_Code, bool backOffice)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@Currency_Code", SqlDbType.Char, 3);
			param.Value = currency_Code;
            param = cmd.Parameters.Add("@BackOffice", SqlDbType.Bit);
            param.Value = backOffice;
			return cmd;
		}

		///<summary>Insert a security group Module association.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_InsertModule.</remarks>
		///<param name="userGroup_Id">The Id of the UserGroup.</param>
		///<param name="module_Id">The Id of the Module.</param>
		///<param name="user_Id">The ID of the User Calling the Stored Proc</param>
		///<param name="statusId">The status flag.</param>
		///<param name="createdUserId">The Audit table CreatedUserId.</param>
		///<param name="uTCCreatedDate">The Audit table UTCCreatedDate.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildInsertModuleCommand(Guid? userGroup_Id, Guid? module_Id, Guid? user_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_InsertModule");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Module_Id", SqlDbType.UniqueIdentifier);
			param.Value = (module_Id.HasValue) ? (object)module_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@CreatedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (createdUserId.HasValue) ? (object)createdUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCCreatedDate", SqlDbType.DateTime);
			param.Value = (uTCCreatedDate.HasValue) ? (object)uTCCreatedDate.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;


			return cmd;
		}

		///<summary>Retrieve all UserGroup records that a User.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAllLike.</remarks>
		///<param name="description">A Description pattern to retrieve.</param>
		///<param name="user_Id">The ID of the User.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectAllLikeCommand(string description, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_SelectAllLike");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieve all Module records assigned to the User's UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectAssignedModules.</remarks>
		///<param name="userGroup_Id">The ID of the UserGroup.</param>
		///<param name="user_Id">The ID of the User.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectAssignedModulesCommand(Guid? userGroup_Id, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_SelectAssignedModules");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@UserGroup_Id", SqlDbType.UniqueIdentifier);
			param.Value = (userGroup_Id.HasValue) ? (object)userGroup_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[UserGroup].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_SelectById.</remarks>
		///<param name="id">The Id of UserGroup</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Updates a [dbo].[UserGroup] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_UserGroup_Update.</remarks>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="currency_Code"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildUpdateCommand(Guid? id, string description, string currency_Code, bool backOfficeGroup)
		{
			SqlCommand cmd = new SqlCommand("TSP_UserGroup_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@Currency_Code", SqlDbType.Char, 3);
			param.Value = currency_Code;
            param = cmd.Parameters.Add("@BackOffice", SqlDbType.Bit);
            param.Value = backOfficeGroup;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(UserGroupDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
