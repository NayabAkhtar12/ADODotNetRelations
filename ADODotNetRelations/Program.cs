using System.Data.SqlClient;

//using SqlComman System.Data.SqlClient.SqlCommand;
//using SqlConnection = System.Data.SqlClient.SqlConnection;
//using SqlDataReader = System.Data.SqlClient.SqlDataReader;

namespace ADODotNetRelations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = "Data source=DESKTOP-FH244E0\\SQLEXPRESS;";
            SqlConnection connection = new SqlConnection(connectionstring);
            var sqlcommand = new SqlCommand("select * from Customers", connection);
            connection.Open();
            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));

                }
            }
          //Insert Operation
            string InsertCustomerQuery = "INSERT INTO Customers (CustomerID, CustomerName) VALUES(@CustomerID,@CustomerName)";
            SqlCommand Insertcommad = new SqlCommand(InsertCustomerQuery,connection);
            Insertcommad.Parameters.AddWithValue("@CustomerID", 3);
            Insertcommad.Parameters.AddWithValue("@CustomerName", "Nayab");
            int recordsadded=Insertcommad.ExecuteNonQuery();
            Console.WriteLine($"{recordsadded} no of records added");

            //Update Operation
            string UpdateQuery = "UPDATE Customers SET CustomerName=@CustomerName WHERE CustomerID=@CustomerID";
            SqlCommand Updatecommad = new SqlCommand(UpdateQuery, connection);
            Updatecommad.Parameters.AddWithValue("@CustomerName", "AYESHA");
            Updatecommad.Parameters.AddWithValue("@CustomerID", 3);
            int recordupdated = Updatecommad.ExecuteNonQuery();
            Console.WriteLine($"{recordupdated} no of records Updated");

            //Delete Operation
            string Deletequery = "DELETE FROM  Customers WHERE CustomerID=@CustomerID";
            SqlCommand Deletecommad = new SqlCommand(Deletequery, connection);
            Deletecommad.Parameters.AddWithValue("@CustomerID", 3);
            int recorddeleted = Deletecommad.ExecuteNonQuery();
            Console.WriteLine($"{recorddeleted} no of records Deleted");
            Console.WriteLine("Program ends here");
        }
    }
}