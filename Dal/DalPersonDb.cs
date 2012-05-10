using System;
using System.Data;
using System.Data.SqlClient;

namespace Britehouse.Dal
{
	///<summary>
	///A generated Data Access Layer class containing all stored procedures matching the pattern TSP_Person_*.
	///</summary>
	public static class PersonDb
	{
		#region Public Members

		///<summary>Delete a Person.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Delete.</remarks>
		///<param name="id">The ID of the Person.</param>
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

		///<summary>Delete a Person.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Delete.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The ID of the Person.</param>
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

		///<summary>Delete a Person.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Delete.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The ID of the Person.</param>
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

		///<summary>Attempts to insert a Person record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Insert.</remarks>
		///<param name="id">The ID for the new Person being inserted.</param>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Insert(ref Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
					if (cmd.Parameters["@Id"].Value != DBNull.Value)
						id = (Guid?)cmd.Parameters["@Id"].Value;
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Attempts to insert a Person record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Insert.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The ID for the new Person being inserted.</param>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Insert(string connectionString, ref Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildInsertCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
					if (cmd.Parameters["@Id"].Value != DBNull.Value)
						id = (Guid?)cmd.Parameters["@Id"].Value;
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Attempts to insert a Person record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Insert.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The ID for the new Person being inserted.</param>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Insert(SqlTransaction transaction, ref Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Insert limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildInsertCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
if (cmd.Parameters["@Id"].Value != DBNull.Value)
	id = (Guid?)cmd.Parameters["@Id"].Value;
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves all the records from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAll.</remarks>
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

		///<summary>Retrieves all the records from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAll.</remarks>
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

		///<summary>Selects Person records for a User in his UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAllLike.</remarks>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description">The Description of the Person.</param>
		///<param name="user_Id">The ID of the User attempting to select the Persons.</param>
		public static SqlDataReader SelectAllLike(string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, Guid? user_Id)
		{
			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @Description to a maximum length of 256.", "description");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAllLikeCommand(firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Selects Person records for a User in his UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAllLike.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description">The Description of the Person.</param>
		///<param name="user_Id">The ID of the User attempting to select the Persons.</param>
		public static SqlDataReader SelectAllLike(string connectionString, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_SelectAllLike limits parameter @Description to a maximum length of 256.", "description");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectAllLikeCommand(firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, user_Id))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByEmailAddress.</remarks>
		///<param name="emailAddress"></param>
		public static void SelectByEmailAddress(string emailAddress)
		{
			if ((emailAddress != null) && (emailAddress.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByEmailAddress limits parameter @EmailAddress to a maximum length of 255.", "emailAddress");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildSelectByEmailAddressCommand(emailAddress))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByEmailAddress.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="emailAddress"></param>
		public static void SelectByEmailAddress(string connectionString, string emailAddress)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((emailAddress != null) && (emailAddress.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByEmailAddress limits parameter @EmailAddress to a maximum length of 255.", "emailAddress");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildSelectByEmailAddressCommand(emailAddress))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByEmailAddress.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="emailAddress"></param>
		public static void SelectByEmailAddress(SqlTransaction transaction, string emailAddress)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((emailAddress != null) && (emailAddress.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByEmailAddress limits parameter @EmailAddress to a maximum length of 255.", "emailAddress");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByEmailAddressCommand(emailAddress))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectById.</remarks>
		///<param name="id">The Id of Person</param>
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

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectById.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of Person</param>
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

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByMobileNo.</remarks>
		///<param name="mobileNo"></param>
		public static SqlDataReader SelectByMobileNo(string mobileNo)
		{
			if ((mobileNo != null) && (mobileNo.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByMobileNo limits parameter @MobileNo to a maximum length of 20.", "mobileNo");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByMobileNoCommand(mobileNo))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByMobileNo.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="mobileNo"></param>
		public static SqlDataReader SelectByMobileNo(string connectionString, string mobileNo)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((mobileNo != null) && (mobileNo.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByMobileNo limits parameter @MobileNo to a maximum length of 20.", "mobileNo");
			SqlConnection connection = new SqlConnection(connectionString);
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByMobileNoCommand(mobileNo))
			{
				cmd.Connection = connection;
				connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			} // using SqlCommand
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByName.</remarks>
		///<param name="name"></param>
		public static void SelectByName(string name)
		{
			if ((name != null) && (name.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByName limits parameter @Name to a maximum length of 255.", "name");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildSelectByNameCommand(name))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByName.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="name"></param>
		public static void SelectByName(string connectionString, string name)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((name != null) && (name.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByName limits parameter @Name to a maximum length of 255.", "name");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildSelectByNameCommand(name))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByName.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="name"></param>
		public static void SelectByName(SqlTransaction transaction, string name)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((name != null) && (name.Length > 255))
				throw new ArgumentException("Stored procedure TSP_Person_SelectByName limits parameter @Name to a maximum length of 255.", "name");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildSelectByNameCommand(name))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByUserGroupId.</remarks>
		///<param name="userGroupId"></param>
		public static SqlDataReader SelectByUserGroupId(Guid? userGroupId)
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

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByUserGroupId.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="userGroupId"></param>
		public static SqlDataReader SelectByUserGroupId(string connectionString, Guid? userGroupId)
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

		///<summary>Attempts to update a Person record identified by Id.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Update.</remarks>
		///<param name="id">The Id of the Person record to update.</param>
		///<param name="firstName">The FirstName of the Person record to update.</param>
		///<param name="surname">The Surname of the Person record to update.</param>
		///<param name="emailAddress">The EmailAddress of the Person record to update.</param>
		///<param name="phoneHome">The PhoneHome of the Person record to update.</param>
		///<param name="phoneMobile">The PhoneMobile of the Person record to update.</param>
		///<param name="phoneOffice">The PhoneOffice of the Person record to update.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Update(Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildUpdateCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Attempts to update a Person record identified by Id.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Update.</remarks>
		///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
		///<param name="id">The Id of the Person record to update.</param>
		///<param name="firstName">The FirstName of the Person record to update.</param>
		///<param name="surname">The Surname of the Person record to update.</param>
		///<param name="emailAddress">The EmailAddress of the Person record to update.</param>
		///<param name="phoneHome">The PhoneHome of the Person record to update.</param>
		///<param name="phoneMobile">The PhoneMobile of the Person record to update.</param>
		///<param name="phoneOffice">The PhoneOffice of the Person record to update.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Update(string connectionString, Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.InfoMessage += InfoMessageHandler;
				using (SqlCommand cmd = BuildUpdateCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
				{
					cmd.Connection = connection;
					connection.Open();
					/*int rowsAffected = */cmd.ExecuteNonQuery();
				} // using SqlCommand
				connection.InfoMessage -= InfoMessageHandler;
			} // using SqlConnection
		}

		///<summary>Attempts to update a Person record identified by Id.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Update.</remarks>
		///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
		///<param name="id">The Id of the Person record to update.</param>
		///<param name="firstName">The FirstName of the Person record to update.</param>
		///<param name="surname">The Surname of the Person record to update.</param>
		///<param name="emailAddress">The EmailAddress of the Person record to update.</param>
		///<param name="phoneHome">The PhoneHome of the Person record to update.</param>
		///<param name="phoneMobile">The PhoneMobile of the Person record to update.</param>
		///<param name="phoneOffice">The PhoneOffice of the Person record to update.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		public static void Update(SqlTransaction transaction, Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			if (transaction == null)
				throw new ArgumentNullException("transaction");

			if ((firstName != null) && (firstName.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @FirstName to a maximum length of 128.", "firstName");
			if ((surname != null) && (surname.Length > 128))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Surname to a maximum length of 128.", "surname");
			if ((emailAddress != null) && (emailAddress.Length > 320))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @EmailAddress to a maximum length of 320.", "emailAddress");
			if ((phoneHome != null) && (phoneHome.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneHome to a maximum length of 20.", "phoneHome");
			if ((phoneMobile != null) && (phoneMobile.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneMobile to a maximum length of 20.", "phoneMobile");
			if ((phoneOffice != null) && (phoneOffice.Length > 20))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PhoneOffice to a maximum length of 20.", "phoneOffice");
			if ((description != null) && (description.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @Description to a maximum length of 256.", "description");
			if ((disabilityNote != null) && (disabilityNote.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @DisabilityNote to a maximum length of 256.", "disabilityNote");
			if ((preferredName != null) && (preferredName.Length > 256))
				throw new ArgumentException("Stored procedure TSP_Person_Update limits parameter @PreferredName to a maximum length of 256.", "preferredName");
			SqlConnection connection = transaction.Connection;
			connection.InfoMessage += InfoMessageHandler;
			using (SqlCommand cmd = BuildUpdateCommand(id, firstName, surname, emailAddress, phoneHome, phoneMobile, phoneOffice, description, gender, disability, disabilityNote, preferredName, statusId, user_Id))
			{
				cmd.Connection = connection;
				cmd.Transaction = transaction;
				/*int rowsAffected = */cmd.ExecuteNonQuery();
			} // using SqlCommand
			connection.InfoMessage -= InfoMessageHandler;
		}

		#endregion

		#region Private Members

		///<summary>Delete a Person.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Delete.</remarks>
		///<param name="id">The ID of the Person.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildDeleteCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_Delete");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Attempts to insert a Person record.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Insert.</remarks>
		///<param name="id">The ID for the new Person being inserted.</param>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildInsertCommand(Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_Insert");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Direction = ParameterDirection.InputOutput;
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 128);
			param.Value = firstName;
			param = cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 128);
			param.Value = surname;
			param = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 320);
			param.Value = emailAddress;
			param = cmd.Parameters.Add("@PhoneHome", SqlDbType.VarChar, 20);
			param.Value = phoneHome;
			param = cmd.Parameters.Add("@PhoneMobile", SqlDbType.VarChar, 20);
			param.Value = phoneMobile;
			param = cmd.Parameters.Add("@PhoneOffice", SqlDbType.VarChar, 20);
			param.Value = phoneOffice;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@Gender", SqlDbType.Int);
			param.Value = (gender.HasValue) ? (object)gender.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Disability", SqlDbType.Bit);
			param.Value = (disability.HasValue) ? (object)disability.Value : DBNull.Value;
			param = cmd.Parameters.Add("@DisabilityNote", SqlDbType.VarChar, 256);
			param.Value = disabilityNote;
			param = cmd.Parameters.Add("@PreferredName", SqlDbType.VarChar, 256);
			param.Value = preferredName;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves all the records from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAll.</remarks>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectAllCommand()
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectAll");
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		///<summary>Selects Person records for a User in his UserGroup.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectAllLike.</remarks>
		///<param name="firstName">The Firstname of the Person.</param>
		///<param name="surname">The Surname of the Person.</param>
		///<param name="emailAddress">The Emailaddress of the Person.</param>
		///<param name="phoneHome">The Home Phone Number of the Person.</param>
		///<param name="phoneMobile">The Mobile Phone Number of the Person.</param>
		///<param name="phoneOffice">The Office Phone Number of the Person.</param>
		///<param name="description">The Description of the Person.</param>
		///<param name="user_Id">The ID of the User attempting to select the Persons.</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectAllLikeCommand(string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectAllLike");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 128);
			param.Value = firstName;
			param = cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 128);
			param.Value = surname;
			param = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 320);
			param.Value = emailAddress;
			param = cmd.Parameters.Add("@PhoneHome", SqlDbType.VarChar, 20);
			param.Value = phoneHome;
			param = cmd.Parameters.Add("@PhoneMobile", SqlDbType.VarChar, 20);
			param.Value = phoneMobile;
			param = cmd.Parameters.Add("@PhoneOffice", SqlDbType.VarChar, 20);
			param.Value = phoneOffice;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByEmailAddress.</remarks>
		///<param name="emailAddress"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByEmailAddressCommand(string emailAddress)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectByEmailAddress");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 255);
			param.Value = emailAddress;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectById.</remarks>
		///<param name="id">The Id of Person</param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByIdCommand(Guid? id)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectById");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByMobileNo.</remarks>
		///<param name="mobileNo"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByMobileNoCommand(string mobileNo)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectByMobileNo");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 20);
			param.Value = mobileNo;
			return cmd;
		}

		///<summary></summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByName.</remarks>
		///<param name="name"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByNameCommand(string name)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectByName");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255);
			param.Value = name;
			return cmd;
		}

		///<summary>Retrieves a record from [dbo].[Person].</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_SelectByUserGroupId.</remarks>
		///<param name="userGroupId"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildSelectByUserGroupIdCommand(Guid? userGroupId)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_SelectByUserGroupId");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@UserGroupId", SqlDbType.UniqueIdentifier);
			param.Value = (userGroupId.HasValue) ? (object)userGroupId.Value : DBNull.Value;
			return cmd;
		}

		///<summary>Attempts to update a Person record identified by Id.</summary>
		///<remarks>This method maps directly onto the stored procedure TSP_Person_Update.</remarks>
		///<param name="id">The Id of the Person record to update.</param>
		///<param name="firstName">The FirstName of the Person record to update.</param>
		///<param name="surname">The Surname of the Person record to update.</param>
		///<param name="emailAddress">The EmailAddress of the Person record to update.</param>
		///<param name="phoneHome">The PhoneHome of the Person record to update.</param>
		///<param name="phoneMobile">The PhoneMobile of the Person record to update.</param>
		///<param name="phoneOffice">The PhoneOffice of the Person record to update.</param>
		///<param name="description"></param>
		///<param name="gender"></param>
		///<param name="disability"></param>
		///<param name="disabilityNote"></param>
		///<param name="preferredName"></param>
		///<param name="statusId"></param>
		///<param name="user_Id"></param>
		///<returns>A SqlCommand object with the parameters already bound.</returns>
		private static SqlCommand BuildUpdateCommand(Guid? id, string firstName, string surname, string emailAddress, string phoneHome, string phoneMobile, string phoneOffice, string description, int? gender, bool? disability, string disabilityNote, string preferredName, int? statusId, Guid? user_Id)
		{
			SqlCommand cmd = new SqlCommand("TSP_Person_Update");
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;
			param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
			param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
			param = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 128);
			param.Value = firstName;
			param = cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 128);
			param.Value = surname;
			param = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 320);
			param.Value = emailAddress;
			param = cmd.Parameters.Add("@PhoneHome", SqlDbType.VarChar, 20);
			param.Value = phoneHome;
			param = cmd.Parameters.Add("@PhoneMobile", SqlDbType.VarChar, 20);
			param.Value = phoneMobile;
			param = cmd.Parameters.Add("@PhoneOffice", SqlDbType.VarChar, 20);
			param.Value = phoneOffice;
			param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 256);
			param.Value = description;
			param = cmd.Parameters.Add("@Gender", SqlDbType.Int);
			param.Value = (gender.HasValue) ? (object)gender.Value : DBNull.Value;
			param = cmd.Parameters.Add("@Disability", SqlDbType.Bit);
			param.Value = (disability.HasValue) ? (object)disability.Value : DBNull.Value;
			param = cmd.Parameters.Add("@DisabilityNote", SqlDbType.VarChar, 256);
			param.Value = disabilityNote;
			param = cmd.Parameters.Add("@PreferredName", SqlDbType.VarChar, 256);
			param.Value = preferredName;
			param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
			param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
			param = cmd.Parameters.Add("@User_Id", SqlDbType.UniqueIdentifier);
			param.Value = (user_Id.HasValue) ? (object)user_Id.Value : DBNull.Value;
			return cmd;
		}

		#endregion

		#region Internal Members

		internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(PersonDb).FullName, e.Errors[0].Procedure));
		}

		#endregion
	}
}
