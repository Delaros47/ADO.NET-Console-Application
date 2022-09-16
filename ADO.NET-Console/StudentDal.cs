using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Console
{
    public class StudentDal
    {
        
        private SqlConnection _connection = new SqlConnection(@"Data Source=DESKTOP-4HHFM4J\DEVELOPER;Initial Catalog=StudentDb; Integrated Security=True;");

        private void CheckConnection()
        {
            if (_connection.State==ConnectionState.Closed)
            {
                _connection.Open();
            }
        }


        public List<Student> GetAll()
        {
            CheckConnection();

            SqlCommand command = new SqlCommand("SELECT * FROM Students",_connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Age = Convert.ToByte(reader["Age"]),
                    PhoneNumber = reader["PhoneNumber"].ToString()
                };
                students.Add(student);
            }

            reader.Close();
            _connection.Close();
            return students;

        }

        public DataTable GetAllByDataTable()
        {
            CheckConnection();

            SqlCommand command = new SqlCommand("SELECT * FROM Students",_connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            return dataTable;

        }

        public void Insert(Student student)
        {
            CheckConnection();

            SqlCommand command = new SqlCommand("INSERT INTO Students VALUES(@Name,@Surname,@Age,@PhoneNumber)",_connection);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Surname", student.Surname);
            command.Parameters.AddWithValue("@Age", student.Age);
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            var effectedRow = command.ExecuteNonQuery();
            if (effectedRow > 0)
            {
                Console.WriteLine($"{student.Name} has successfully inserted into our database");
            }
            _connection.Close();

        }

        public void Update(Student student)
        {
            CheckConnection();

            SqlCommand command = new SqlCommand("UPDATE Students SET Name=@Name,Surname=@Surname,Age=@Age,PhoneNumber=@PhoneNumber WHERE StudentId=@StudentId",_connection);
            command.Parameters.AddWithValue("@StudentId", student.StudentId);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Surname", student.Surname);
            command.Parameters.AddWithValue("@Age", student.Age);
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            var effectedRow = command.ExecuteNonQuery();
            if (effectedRow>0)
            {
                Console.WriteLine($"{student.Name} has successfully updated into our database");
            }
            _connection.Close();

        }

        public void Delete(int studentId)
        {
            
            var deletedName = GetAll().Where(x => x.StudentId == studentId).SingleOrDefault().Name;

            CheckConnection();

            SqlCommand command = new SqlCommand("DELETE FROM Students WHERE StudentId=@StudentId",_connection);
            command.Parameters.AddWithValue("@StudentId", studentId);
            var effectedRow = command.ExecuteNonQuery();
            if (effectedRow>0)
            {
                Console.WriteLine($"{deletedName} has successfully deleted from our database");
            }
            _connection.Close();

        }


        
        


    }
}
