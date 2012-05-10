using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern sp_Feature*.
	///</summary>
	public static class FeatureDb
	{
		#region Public Members

		///<summary>Deletes a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Delete.</remarks>
		///<param name="id">The Id of Feature</param>
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

		///<summary>Deletes a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Feature</param>
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

		///<summary>Deletes a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of Feature</param>
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

		///<summary>Inserts a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Insert.</remarks>
		///<param name="id">The Id of Feature</param>
		///<param name="module_Id">The Module_Id of Feature</param>
		///<param name="description_Id">The Description_Id of Feature</param>
		///<param name="featureSection_Id">The FeatureSection_Id of Feature</param>
		public static void Insert(Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(id, module_Id, description_Id, featureSection_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Feature</param>
		///<param name="module_Id">The Module_Id of Feature</param>
		///<param name="description_Id">The Description_Id of Feature</param>
		///<param name="featureSection_Id">The FeatureSection_Id of Feature</param>
		public static void Insert(string connectionString, Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(id, module_Id, description_Id, featureSection_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of Feature</param>
		///<param name="module_Id">The Module_Id of Feature</param>
		///<param name="description_Id">The Description_Id of Feature</param>
		///<param name="featureSection_Id">The FeatureSection_Id of Feature</param>
		public static void Insert(SqlTransaction transaction, Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_InsertCommand(id, module_Id, description_Id, featureSection_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectAll.</remarks>
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

		///<summary>Retrieves all the records from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectAll.</remarks>
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

		///<summary>Retrieves a record from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectById.</remarks>
		///<param name="id">The Id of Feature</param>
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

		///<summary>Retrieves a record from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Feature</param>
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

		///<summary>Updates a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Update.</remarks>
		///<param name="id"></param>
		///<param name="module_Id"></param>
		///<param name="description_Id"></param>
		///<param name="featureSection_Id"></param>
		public static void Update(Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(id, module_Id, description_Id, featureSection_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id"></param>
		///<param name="module_Id"></param>
		///<param name="description_Id"></param>
		///<param name="featureSection_Id"></param>
		public static void Update(string connectionString, Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(id, module_Id, description_Id, featureSection_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id"></param>
		///<param name="module_Id"></param>
		///<param name="description_Id"></param>
		///<param name="featureSection_Id"></param>
		public static void Update(SqlTransaction transaction, Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_UpdateCommand(id, module_Id, description_Id, featureSection_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Deletes a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Delete.</remarks>
		///<param name="id">The Id of Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_DeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_Feature_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Insert.</remarks>
		///<param name="id">The Id of Feature</param>
		///<param name="module_Id">The Module_Id of Feature</param>
		///<param name="description_Id">The Description_Id of Feature</param>
		///<param name="featureSection_Id">The FeatureSection_Id of Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_InsertCommand(Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			SqlCommand cmd = new SqlCommand("sp_Feature_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Module_Id", SqlDbType.UniqueIdentifier);
			param.Value = (module_Id.HasValue) ? (object)module_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@FeatureSection_Id", SqlDbType.UniqueIdentifier);
			param.Value = (featureSection_Id.HasValue) ? (object)featureSection_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("sp_Feature_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Feature].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_SelectById.</remarks>
		///<param name="id">The Id of Feature</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_Feature_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Updates a [dbo].[Feature] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_Feature_Update.</remarks>
		///<param name="id"></param>
		///<param name="module_Id"></param>
		///<param name="description_Id"></param>
		///<param name="featureSection_Id"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_UpdateCommand(Guid? id, Guid? module_Id, Guid? description_Id, Guid? featureSection_Id)
		{
			SqlCommand cmd = new SqlCommand("sp_Feature_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Module_Id", SqlDbType.UniqueIdentifier);
			param.Value = (module_Id.HasValue) ? (object)module_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@FeatureSection_Id", SqlDbType.UniqueIdentifier);
			param.Value = (featureSection_Id.HasValue) ? (object)featureSection_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Deletes a [dbo].[FeatureSection] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_FeatureSection_Delete.</remarks>
		///<param name="id">The Id of FeatureSection</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSection_DeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_FeatureSection_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Inserts a [dbo].[FeatureSection] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_FeatureSection_Insert.</remarks>
		///<param name="id">The Id of FeatureSection</param>
		///<param name="description_Id">The Description_Id of FeatureSection</param>
		///<param name="imageUrl">The ImageUrl of FeatureSection</param>
		///<param name="sortOrder">The SortOrder of FeatureSection</param>
		///<param name="statusId">The StatusId of FeatureSection</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSection_InsertCommand(Guid? id, Guid? description_Id, string imageUrl, int? sortOrder, int? statusId)
		{
			SqlCommand cmd = new SqlCommand("sp_FeatureSection_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar, 250);
			param.Value = imageUrl;
			param = cmd.Parameters.Add("@SortOrder", SqlDbType.Int);
			param.Value = (sortOrder.HasValue) ? (object)sortOrder.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[FeatureSection].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_FeatureSection_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSection_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("sp_FeatureSection_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[FeatureSection].</summary>
		///<remarks>This method maps directly onto the stored procedure sp_FeatureSection_SelectById.</remarks>
		///<param name="id">The Id of FeatureSection</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSection_SelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("sp_FeatureSection_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Updates a [dbo].[FeatureSection] record.</summary>
		///<remarks>This method maps directly onto the stored procedure sp_FeatureSection_Update.</remarks>
		///<param name="id"></param>
		///<param name="description_Id"></param>
		///<param name="imageUrl">The image url.</param>
		///<param name="sortOrder">The sort order.</param>
		///<param name="statusId"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSection_UpdateCommand(Guid? id, Guid? description_Id, string imageUrl, int? sortOrder, int? statusId)
		{
			SqlCommand cmd = new SqlCommand("sp_FeatureSection_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar, 250);
			param.Value = imageUrl;
			param = cmd.Parameters.Add("@SortOrder", SqlDbType.Int);
			param.Value = (sortOrder.HasValue) ? (object)sortOrder.Value : DBNull.Value;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(FeatureDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
