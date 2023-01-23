using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace ADODotNetRelations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data source=DESKTOP-FH244E0\\SQLEXPRESS; Database=User; Integrated Security=SSPI;";
            SqlConnection connection = new SqlConnection(connectionString);
            var sqlcommand = new SqlCommand("select * from UserInfo", connection);
            connection.Open();
            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));

                }
            }
            ////Insert Operation
            string InsertQuery = "INSERT INTO UserInfo(Id, Name) VALUES(@Id,@Name)";
            SqlCommand Insertcommad = new SqlCommand(InsertQuery, connection);
            Insertcommad.Parameters.AddWithValue("@Id", 3);
            Insertcommad.Parameters.AddWithValue("@Name", "Nayab");
            int recordsadded = Insertcommad.ExecuteNonQuery();
            Console.WriteLine($"{recordsadded} no of records added");

           // Update Operation
            string UpdateQuery = "UPDATE UserInfo SET Name=@Name WHERE Id=@Id";
            SqlCommand Updatecommad = new SqlCommand(UpdateQuery, connection);
            Updatecommad.Parameters.AddWithValue("@Name", "Laiba");
            Updatecommad.Parameters.AddWithValue("@Id", 3);
            int recordupdated = Updatecommad.ExecuteNonQuery();
            Console.WriteLine($"{recordupdated} no of records Updated");

            //Delete Operation
            string Deletequery = "DELETE FROM  UserInfo WHERE Id=@Id";
            SqlCommand Deletecommad = new SqlCommand(Deletequery, connection);
            Deletecommad.Parameters.AddWithValue("@Id", 3);
            int recorddeleted = Deletecommad.ExecuteNonQuery();
            Console.WriteLine($"{recorddeleted} no of records Deleted");
            Console.WriteLine("Program ends here");
        }
    }
}