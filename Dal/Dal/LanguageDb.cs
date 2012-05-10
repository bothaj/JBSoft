using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern TSP_Language*.
	///</summary>
	public static class LanguageDb
	{
		#region Public Members

		///<summary>Deletes a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Delete.</remarks>
		///<param name="code">The Code of Language</param>
		public static void Delete(string code)
		{
			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Delete limits parameter @Code to a maximum length of 2.", "code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_DeleteCommand(code))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Language</param>
		public static void Delete(string connectionString, string code)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Delete limits parameter @Code to a maximum length of 2.", "code");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_DeleteCommand(code))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Deletes a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code">The Code of Language</param>
		public static void Delete(SqlTransaction transaction, string code)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Delete limits parameter @Code to a maximum length of 2.", "code");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_DeleteCommand(code))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Inserts a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Insert.</remarks>
		///<param name="code">The Code of Language</param>
		///<param name="description_Id">The Description_Id of Language</param>
		///<param name="supported">The Supported of Language</param>
		public static void Insert(string code, Guid? description_Id, bool? supported)
		{
			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Insert limits parameter @Code to a maximum length of 2.", "code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(code, description_Id, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Language</param>
		///<param name="description_Id">The Description_Id of Language</param>
		///<param name="supported">The Supported of Language</param>
		public static void Insert(string connectionString, string code, Guid? description_Id, bool? supported)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Insert limits parameter @Code to a maximum length of 2.", "code");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(code, description_Id, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code">The Code of Language</param>
		///<param name="description_Id">The Description_Id of Language</param>
		///<param name="supported">The Supported of Language</param>
		public static void Insert(SqlTransaction transaction, string code, Guid? description_Id, bool? supported)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Insert limits parameter @Code to a maximum length of 2.", "code");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_InsertCommand(code, description_Id, supported))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectAll.</remarks>
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

		///<summary>Retrieves all the records from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectAll.</remarks>
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

		///<summary>Retrieves a record from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectById.</remarks>
		///<param name="code">The Code of Language</param>
		public static SqlDataReader SelectById(string code)
		{
			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_SelectById limits parameter @Code to a maximum length of 2.", "code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectByIdCommand(code))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Language</param>
		public static SqlDataReader SelectById(string connectionString, string code)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_SelectById limits parameter @Code to a maximum length of 2.", "code");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectByIdCommand(code))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Updates a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Update.</remarks>
		///<param name="code"></param>
		///<param name="description_Id"></param>
		///<param name="supported"></param>
		public static void Update(string code, Guid? description_Id, bool? supported)
		{
			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Update limits parameter @Code to a maximum length of 2.", "code");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(code, description_Id, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code"></param>
		///<param name="description_Id"></param>
		///<param name="supported"></param>
		public static void Update(string connectionString, string code, Guid? description_Id, bool? supported)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Update limits parameter @Code to a maximum length of 2.", "code");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(code, description_Id, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code"></param>
		///<param name="description_Id"></param>
		///<param name="supported"></param>
		public static void Update(SqlTransaction transaction, string code, Guid? description_Id, bool? supported)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 2))
				throw new ArgumentException("Stored procedure TSP_Language_Update limits parameter @Code to a maximum length of 2.", "code");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_UpdateCommand(code, description_Id, supported))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Deletes a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Delete.</remarks>
		///<param name="code">The Code of Language</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_DeleteCommand(string code)
		{
			SqlCommand cmd = new SqlCommand("TSP_Language_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.Char, 2);
			param.Value = code;
			return cmd;
		}

		///<summary>Inserts a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Insert.</remarks>
		///<param name="code">The Code of Language</param>
		///<param name="description_Id">The Description_Id of Language</param>
		///<param name="supported">The Supported of Language</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_InsertCommand(string code, Guid? description_Id, bool? supported)
		{
			SqlCommand cmd = new SqlCommand("TSP_Language_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.Char, 2);
			param.Value = code;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Supported", SqlDbType.Bit);
			param.Value = (supported.HasValue) ? (object)supported.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("TSP_Language_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Language].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_SelectById.</remarks>
		///<param name="code">The Code of Language</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectByIdCommand(string code)
		{
			SqlCommand cmd = new SqlCommand("TSP_Language_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.Char, 2);
			param.Value = code;
			return cmd;
		}

		///<summary>Updates a [dbo].[Language] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Language_Update.</remarks>
		///<param name="code"></param>
		///<param name="description_Id"></param>
		///<param name="supported"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_UpdateCommand(string code, Guid? description_Id, bool? supported)
		{
			SqlCommand cmd = new SqlCommand("TSP_Language_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.Char, 2);
			param.Value = code;
			param = cmd.Parameters.Add("@Description_Id", SqlDbType.UniqueIdentifier);
			param.Value = (description_Id.HasValue) ? (object)description_Id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Supported", SqlDbType.Bit);
			param.Value = (supported.HasValue) ? (object)supported.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(LanguageDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
