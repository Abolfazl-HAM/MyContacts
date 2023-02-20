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
        public bool Delete(int cId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
                SqlConnection connection = new SqlConnection(connectionString);

                string query = "Insert Into MyNumbers (Name,Family,Mobile,Email,Age,Address) Value (@Name,@Family,@Mobile,@Email,@Age,@Address)";
                SqlCommand command=new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            
            
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
            throw new NotImplementedException();
        }

        public bool Update(int cId, string name, string family, string mobile, string email, int age, string address)
        {
            throw new NotImplementedException();
        }
    }
}
