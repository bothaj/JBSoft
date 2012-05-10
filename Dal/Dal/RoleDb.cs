using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern sp_Role*.
	///</summary>
	public static class RoleDb
	{
		#region Public Members

		///<summary>Deletes a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Delete.</remarks>
		///<param name="id">The Id of Role</param>
		public static void Delete(Guid? id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_DeleteCommand(id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Role</param>
		public static void Delete(string connectionString, Guid? id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_DeleteCommand(id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of Role</param>
		public static void Delete(SqlTransaction transaction, Guid? id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_DeleteCommand(id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Inserts a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Insert.</remarks>
		///<param name="id">The Id of Role</param>
		///<param name="description">The Description of Role</param>
		///<param name="isSystemRole">The IsSystemRole of Role</param>
		public static void Insert(Guid? id, string description, bool? isSystemRole)
		{
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Insert limits parameter @Description to a maximum length of 256.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(id, description, isSystemRole))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Role</param>
		///<param name="description">The Description of Role</param>
		///<param name="isSystemRole">The IsSystemRole of Role</param>
		public static void Insert(string connectionString, Guid? id, string description, bool? isSystemRole)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Insert limits parameter @Description to a maximum length of 256.", "description");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(id, description, isSystemRole))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of Role</param>
		///<param name="description">The Description of Role</param>
		///<param name="isSystemRole">The IsSystemRole of Role</param>
		public static void Insert(SqlTransaction transaction, Guid? id, string description, bool? isSystemRole)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Insert limits parameter @Description to a maximum length of 256.", "description");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_InsertCommand(id, description, isSystemRole))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectAll.</remarks>
		public static SqlDataReader SelectAll()
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectAllCommand())
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves all the records from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectAll.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		public static SqlDataReader SelectAll(string connectionString)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectAllCommand())
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectById.</remarks>
		///<param name="id">The Id of Role</param>
		public static SqlDataReader SelectById(Guid? id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Role</param>
		public static SqlDataReader SelectById(string connectionString, Guid? id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectByIdCommand(id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Updates a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Update.</remarks>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="isSystemRole"></param>
		public static void Update(Guid? id, string description, bool? isSystemRole)
		{
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Update limits parameter @Description to a maximum length of 256.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(id, description, isSystemRole))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="isSystemRole"></param>
		public static void Update(string connectionString, Guid? id, string description, bool? isSystemRole)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Update limits parameter @Description to a maximum length of 256.", "description");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(id, description, isSystemRole))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="isSystemRole"></param>
		public static void Update(SqlTransaction transaction, Guid? id, string description, bool? isSystemRole)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure sp_Role_Update limits parameter @Description to a maximum length of 256.", "description");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_UpdateCommand(id, description, isSystemRole))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Deletes a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Delete.</remarks>
		///<param name="id">The Id of Role</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_DeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Deletes a [dbo].[Role_Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Feature_Delete.</remarks>
		///<param name="role_Id">The Role_Id of Role_Feature</param>
		///<param name="feature_Id">The Feature_Id of Role_Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_Feature_DeleteCommand(Guid? role_Id, Guid? feature_Id)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Feature_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Role_Id", SqlDbType.UniqueIdentifier);
			param.Value = (role_Id.HasValue) ? (object)role_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Feature_Id", SqlDbType.UniqueIdentifier);
			param.Value = (feature_Id.HasValue) ? (object)feature_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[Role_Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Feature_Insert.</remarks>
		///<param name="role_Id">The Role_Id of Role_Feature</param>
		///<param name="feature_Id">The Feature_Id of Role_Feature</param>
		///<param name="statusId">The StatusId of Role_Feature</param>
		///<param name="createdUserId">The CreatedUserId of Role_Feature</param>
		///<param name="uTCCreatedDate">The UTCCreatedDate of Role_Feature</param>
		///<param name="modifiedUserId">The ModifiedUserId of Role_Feature</param>
		///<param name="uTCModifiedDate">The UTCModifiedDate of Role_Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_Feature_InsertCommand(Guid? role_Id, Guid? feature_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate, Guid? modifiedUserId, DateTime? uTCModifiedDate)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Feature_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Role_Id", SqlDbType.UniqueIdentifier);
			param.Value = (role_Id.HasValue) ? (object)role_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Feature_Id", SqlDbType.UniqueIdentifier);
			param.Value = (feature_Id.HasValue) ? (object)feature_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@CreatedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (createdUserId.HasValue) ? (object)createdUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCCreatedDate", SqlDbType.DateTime);
			param.Value = (uTCCreatedDate.HasValue) ? (object)uTCCreatedDate.Value : DBNull.Value;
			param = cmd.Parameters.Add("@ModifiedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (modifiedUserId.HasValue) ? (object)modifiedUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCModifiedDate", SqlDbType.DateTime);
			param.Value = (uTCModifiedDate.HasValue) ? (object)uTCModifiedDate.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Role_Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Feature_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_Feature_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Feature_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Role_Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Feature_SelectById.</remarks>
		///<param name="role_Id">The Role_Id of Role_Feature</param>
		///<param name="feature_Id">The Feature_Id of Role_Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_Feature_SelectByIdCommand(Guid? role_Id, Guid? feature_Id)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Feature_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Role_Id", SqlDbType.UniqueIdentifier);
			param.Value = (role_Id.HasValue) ? (object)role_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Feature_Id", SqlDbType.UniqueIdentifier);
			param.Value = (feature_Id.HasValue) ? (object)feature_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Updates a [dbo].[Role_Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Feature_Update.</remarks>
		///<param name="role_Id">The ID of the Role.</param>
		///<param name="feature_Id">The ID of the Feature.</param>
		///<param name="statusId"></param>
		///<param name="createdUserId"></param>
		///<param name="uTCCreatedDate"></param>
		///<param name="modifiedUserId"></param>
		///<param name="uTCModifiedDate"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_Feature_UpdateCommand(Guid? role_Id, Guid? feature_Id, int? statusId, Guid? createdUserId, DateTime? uTCCreatedDate, Guid? modifiedUserId, DateTime? uTCModifiedDate)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Feature_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Role_Id", SqlDbType.UniqueIdentifier);
			param.Value = (role_Id.HasValue) ? (object)role_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Feature_Id", SqlDbType.UniqueIdentifier);
			param.Value = (feature_Id.HasValue) ? (object)feature_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@CreatedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (createdUserId.HasValue) ? (object)createdUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCCreatedDate", SqlDbType.DateTime);
			param.Value = (uTCCreatedDate.HasValue) ? (object)uTCCreatedDate.Value : DBNull.Value;
			param = cmd.Parameters.Add("@ModifiedUserId", SqlDbType.UniqueIdentifier);
			param.Value = (modifiedUserId.HasValue) ? (object)modifiedUserId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@UTCModifiedDate", SqlDbType.DateTime);
			param.Value = (uTCModifiedDate.HasValue) ? (object)uTCModifiedDate.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Insert.</remarks>
		///<param name="id">The Id of Role</param>
		///<param name="description">The Description of Role</param>
		///<param name="isSystemRole">The IsSystemRole of Role</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_InsertCommand(Guid? id, string description, bool? isSystemRole)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@IsSystemRole", SqlDbType.Bit);
			param.Value = (isSystemRole.HasValue) ? (object)isSystemRole.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("sp_Role_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Role].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_SelectById.</remarks>
		///<param name="id">The Id of Role</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Updates a [dbo].[Role] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Role_Update.</remarks>
		///<param name="id"></param>
		///<param name="description"></param>
		///<param name="isSystemRole"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_UpdateCommand(Guid? id, string description, bool? isSystemRole)
		{
			SqlCommand cmd = new SqlCommand("sp_Role_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@IsSystemRole", SqlDbType.Bit);
			param.Value = (isSystemRole.HasValue) ? (object)isSystemRole.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(RoleDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
