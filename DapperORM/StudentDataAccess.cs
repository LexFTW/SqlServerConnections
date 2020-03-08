using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperORM.Properties;

namespace DapperORM
{
    public class StudentDataAccess : IStudentDataAccess
    {
        public bool Create(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.SqlCreateQuery, student);
                    return true;
                }catch(Exception e)
                {
                    // Logs
                    throw;
                }
            }
        }

        public bool Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read(string value)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read(int value)
        {
            throw new NotImplementedException();
        }

        public Student ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
