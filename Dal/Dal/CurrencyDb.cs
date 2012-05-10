using System;
using System.Data;
using System.Data.SqlClient;

namespace JBSoft.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern TSP_Currency*.
	///</summary>
	public static class CurrencyDb
	{
		#region Public Members

		///<summary>Deletes a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Delete.</remarks>
		///<param name="code">The Code of Currency</param>
		public static void Delete(string code)
		{
			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Delete limits parameter @Code to a maximum length of 5.", "code");
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

		///<summary>Deletes a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Currency</param>
		public static void Delete(string connectionString, string code)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Delete limits parameter @Code to a maximum length of 5.", "code");
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

		///<summary>Deletes a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code">The Code of Currency</param>
		public static void Delete(SqlTransaction transaction, string code)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Delete limits parameter @Code to a maximum length of 5.", "code");
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

		///<summary>Inserts a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Insert.</remarks>
		///<param name="code">The Code of Currency</param>
		///<param name="name">The Name of Currency</param>
		///<param name="supported">The Supported of Currency</param>
		public static void Insert(string code, string name, bool? supported)
		{
			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Name to a maximum length of 50.", "name");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(code, name, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Currency</param>
		///<param name="name">The Name of Currency</param>
		///<param name="supported">The Supported of Currency</param>
		public static void Insert(string connectionString, string code, string name, bool? supported)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Name to a maximum length of 50.", "name");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_InsertCommand(code, name, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Inserts a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code">The Code of Currency</param>
		///<param name="name">The Name of Currency</param>
		///<param name="supported">The Supported of Currency</param>
		public static void Insert(SqlTransaction transaction, string code, string name, bool? supported)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Insert limits parameter @Name to a maximum length of 50.", "name");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_InsertCommand(code, name, supported))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectAll.</remarks>
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

		///<summary>Retrieves all the records from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectAll.</remarks>
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

		///<summary>Retrieves a record from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectById.</remarks>
		///<param name="code">The Code of Currency</param>
		public static SqlDataReader SelectById(string code)
		{
			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_SelectById limits parameter @Code to a maximum length of 5.", "code");
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

		///<summary>Retrieves a record from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code">The Code of Currency</param>
		public static SqlDataReader SelectById(string connectionString, string code)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_SelectById limits parameter @Code to a maximum length of 5.", "code");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_SelectByIdCommand(code))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Updates a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Update.</remarks>
		///<param name="code"></param>
		///<param name="name"></param>
		///<param name="supported"></param>
		public static void Update(string code, string name, bool? supported)
		{
			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Name to a maximum length of 50.", "name");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(code, name, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="code"></param>
		///<param name="name"></param>
		///<param name="supported"></param>
		public static void Update(string connectionString, string code, string name, bool? supported)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Name to a maximum length of 50.", "name");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = Build_UpdateCommand(code, name, supported))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Updates a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="code"></param>
		///<param name="name"></param>
		///<param name="supported"></param>
		public static void Update(SqlTransaction transaction, string code, string name, bool? supported)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((code != null) && (code.Length > 5))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Code to a maximum length of 5.", "code");
			if ((name != null) && (name.Length > 50))
				throw new ArgumentException("Stored procedure TSP_Currency_Update limits parameter @Name to a maximum length of 50.", "name");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = Build_UpdateCommand(code, name, supported))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Deletes a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Delete.</remarks>
		///<param name="code">The Code of Currency</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_DeleteCommand(string code)
		{
			SqlCommand cmd = new SqlCommand("TSP_Currency_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 5);
			param.Value = code;
			return cmd;
		}

		///<summary>Inserts a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Insert.</remarks>
		///<param name="code">The Code of Currency</param>
		///<param name="name">The Name of Currency</param>
		///<param name="supported">The Supported of Currency</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_InsertCommand(string code, string name, bool? supported)
		{
			SqlCommand cmd = new SqlCommand("TSP_Currency_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 5);
			param.Value = code;
			param = cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
			param.Value = name;
			param = cmd.Parameters.Add("@Supported", SqlDbType.Bit);
			param.Value = (supported.HasValue) ? (object)supported.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("TSP_Currency_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Currency].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_SelectById.</remarks>
		///<param name="code">The Code of Currency</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_SelectByIdCommand(string code)
		{
			SqlCommand cmd = new SqlCommand("TSP_Currency_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 5);
			param.Value = code;
			return cmd;
		}

		///<summary>Updates a [dbo].[Currency] record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Currency_Update.</remarks>
		///<param name="code"></param>
		///<param name="name"></param>
		///<param name="supported"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand Build_UpdateCommand(string code, string name, bool? supported)
		{
			SqlCommand cmd = new SqlCommand("TSP_Currency_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 5);
			param.Value = code;
			param = cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
			param.Value = name;
			param = cmd.Parameters.Add("@Supported", SqlDbType.Bit);
			param.Value = (supported.HasValue) ? (object)supported.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(CurrencyDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
