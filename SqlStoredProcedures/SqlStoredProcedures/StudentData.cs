using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SqlStoredProcedures
{
    class StudentData:IStudentData
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentData));
        SqlCommand commandSql;
        SqlDataReader dataReaderSql;
        public bool Create(string pName, string pSurname, string pBirth)
        {
            Student student = StudentDataUtility.AddStudent(pName, pSurname, pBirth);
            logger.Info(student.StudentGuid1 + "...." + student.StudentName);
            bool created = false;
            try
            {
                commandSql = new SqlCommand("InsertStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
                commandSql.Parameters.AddWithValue("@studentGuid", student.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", student.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", student.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", student.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", student.StudentAge);
                commandSql.ExecuteNonQuery();
                created = true;
            }
            catch (SqlException ex)
            {
                logger.Info("SQL Error" + ex.Message.ToString());
            }
          
            return created;
        }

        public bool Delete(int pId)
        {
            bool delete = false;
            try
            {
                commandSql = new SqlCommand("DeleteStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
                commandSql.Parameters.AddWithValue("@pId", pId);
                commandSql.ExecuteNonQuery();
                delete = true;
            }
            catch (Exception e)
            {
                logger.Info("no se borró" + e.ToString());
            }

            return delete;
        }

        public Student Read(int pId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int pId, string pName, string pSurname, string pBirth)
        {
            throw new NotImplementedException();
        }
    }
}
