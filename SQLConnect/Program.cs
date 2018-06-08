using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SQLConnect {
	class Program {
		static List<User> users = new List<User>();

		void Run() {
			User user = new User();
			user.Fname = "Jake";
			user.Lname = "Shake";
			user.Position = "BW";
			user.Salary = 190000;
			user.PlayerNumb = 21;
			user.yearsplayed = 5;
			user.Id = 5;
			update(user);
		}

		static void Main(string[] args) {
			(new Program()).Run();
		}
		void update(User user) {
			string connStr = @"server=STUDENT04\SQLEXPRESS;database=SqlTutorial;Trusted_connection=true";

			SqlConnection connection = new SqlConnection(connStr); connection.Open();

			if (connection.State != ConnectionState.Open) {
				throw new ApplicationException("Connection did not open");
			}
			string sql = "update players  " +
				"set FirstName = @fname, LastName = @lname, Position = @pos, number = @numb, yearsinsport = @year, Salary = @salary where ID = @ID";
		
			SqlCommand sqlcommand = new SqlCommand(sql, connection);
			sqlcommand.Parameters.Add(new SqlParameter("@ID",user.Id ));
			sqlcommand.Parameters.Add(new SqlParameter("@fname", user.Fname));
			sqlcommand.Parameters.Add(new SqlParameter("@lname", user.Lname));
			sqlcommand.Parameters.Add(new SqlParameter("@pos", user.Position));
			sqlcommand.Parameters.Add(new SqlParameter("@numb", user.PlayerNumb));
			sqlcommand.Parameters.Add(new SqlParameter("@year", user.yearsplayed));
			sqlcommand.Parameters.Add(new SqlParameter("@salary", user.Salary));

			int recsaffected = sqlcommand.ExecuteNonQuery();
			if (recsaffected != 1) {
				Debug.WriteLine("Insert failed");
				connection.Close();

			}

		}


		void insert(User user) {
			string connStr = @"server=STUDENT04\SQLEXPRESS;database=SqlTutorial;Trusted_connection=true";

			SqlConnection connection = new SqlConnection(connStr); connection.Open();

			if (connection.State != ConnectionState.Open) {
				throw new ApplicationException("Connection did not open");
			}
			string sql = "Insert into players (FirstName, LastName, Position, number, yearsinsport, Salary)" +
				"Values (@fname, @lname, @pos, @numb, @year, @salary)";
			SqlCommand sqlcommand = new SqlCommand(sql, connection);
			sqlcommand.Parameters.Add(new SqlParameter("@fname",user.Fname));
			sqlcommand.Parameters.Add(new SqlParameter("@lname", user.Lname));
			sqlcommand.Parameters.Add(new SqlParameter("@pos", user.Position));
			sqlcommand.Parameters.Add(new SqlParameter("@numb", user.PlayerNumb));
			sqlcommand.Parameters.Add(new SqlParameter("@year", user.yearsplayed));
			sqlcommand.Parameters.Add(new SqlParameter("@salary", user.Salary));

			int recsaffected = sqlcommand.ExecuteNonQuery();
			if(recsaffected != 1) {
				Debug.WriteLine("Insert failed");
				connection.Close();

			}

		}
		void select() { 

			string connStr = @"server=STUDENT04\SQLEXPRESS;database=SqlTutorial;Trusted_connection=true";

			SqlConnection connection = new SqlConnection(connStr);

			connection.Open();

			if (connection.State != ConnectionState.Open) {
				throw new ApplicationException("Connection did not open");
			}
			

			string sql = "select * from players";
			SqlCommand sqlcommand = new SqlCommand(sql, connection);
			SqlDataReader read = sqlcommand.ExecuteReader();

			IDataReader records = read;

			

			while (read.Read()) {
				int id = read.GetInt32(read.GetOrdinal("ID"));
				string Fname = read.GetString(read.GetOrdinal("FirstName"));
				string Lname = read.GetString(read.GetOrdinal("LastName"));
				string position = read.GetString(read.GetOrdinal("Position"));
				decimal salary = read.GetDecimal(read.GetOrdinal("Salary"));
				//decimal Doesnotexist = read.GetDecimal(read.GetOrdinal("Nothing"));

				User user = new User();
				user.Id = id; user.Lname = Lname; user.Salary = salary; user.Fname = Fname; user.Position = position;
				users.Add(user);

			

				//Debug.WriteLine($"{id} {Fname} {Lname} {position} {salary}" );
			}



			connection.Close();
		} 
	}
}
