using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyContacts.Services
{
    public class ContactsRepository : IContactsRepository
    {
        private string connectionString = "Data Source=.; Initial Catalog=Phonebook; Integrated Security=true";
       

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
               SqlConnection connection = new SqlConnection(connectionString);

               
            try 
            {
                string query = "Insert Into MyNumbers (Name,Family,Mobile,Email,Age,Address) Values (@Name,@Family,@Mobile,@Email,@Age,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
               
            
            
        }

        public bool Update(int cId, string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update MyNumbers set Name=@name,Family=@family,Mobile=@mobile,Email=@email,Age=@age,Address=@address where CID=@cId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cId", cId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Delete(int cId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From MyNumbers where CID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", cId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyNumbers";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int cID)
        {
            string query = "Select * From MyNumbers where CID="+cID;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

       
    }
}
