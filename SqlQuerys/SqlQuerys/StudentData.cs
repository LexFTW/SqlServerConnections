using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SqlQuerys.Properties;

namespace SqlQuerys
{
   public class StudentData : IStudentData
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentData));
        SqlCommand commandSql;
        SqlDataReader dataReaderSql;
        public bool Create(string pName, string pSurname, string pBirth)
        {
           Student student= StudentDataUtility.AddStudent(pName, pSurname, pBirth);
            logger.Info(student.StudentGuid1 + "...." + student.StudentName);
            bool created = false;
            try
            {
                commandSql = new SqlCommand(Resources.SqlInsert, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@studentGuid", student.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", student.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", student.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", student.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", student.StudentAge);
                commandSql.ExecuteNonQuery();
                logger.Info("Insertado");
                created = true;
              
            }
            catch (Exception exception)
            {
                logger.Info("no se insertó:    "+ exception.ToString());
            }
            return created;
        }


        public bool Delete(int pId)
        {
            bool delete = false;
            try
            {
                commandSql = new SqlCommand(Resources.SqlDelete, ConnectionUtility.OpenConnection());
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
            Student student = new Student();
            try
            {
                commandSql = new SqlCommand(Resources.SqlSelect, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@pId", pId); 
                commandSql.ExecuteNonQuery();
                dataReaderSql = commandSql.ExecuteReader();
                while (dataReaderSql.Read())
                {
                    student = new Student(Convert.ToInt32(dataReaderSql["StudentId"]), Guid.Parse(dataReaderSql["StudentGuid"].ToString()), dataReaderSql["Name"].ToString(), dataReaderSql["Surname"].ToString(), Convert.ToDateTime(dataReaderSql["Birthday"]), Convert.ToInt32(dataReaderSql["Age"]));
                    logger.Info(student.StudentId + " " + student.StudentName + " " + student.AgeOfBirth);
                }
                dataReaderSql.Close();
            }
            catch (Exception ex)
            {
                logger.Info("No se pudo realizar la consulta" + ex.ToString());
            }
            return student;
        }

        public bool Update(int pId, string pName, string pSurname, string pBirth)
        {
            bool updated = false;
            Student student = Read(pId);
            Student studentNew = StudentDataUtility.AddStudent(pName, pSurname, pBirth);
            try
            {
                commandSql = new SqlCommand(Resources.SqlUpdate, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@pId", pId);
                commandSql.Parameters.AddWithValue("@studentGuid", studentNew.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", studentNew.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", studentNew.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", studentNew.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", studentNew.StudentAge);
                commandSql.ExecuteNonQuery();
                logger.Info("Update");
                updated = true;
            }
            catch (Exception e)
            {
                logger.Info("no se insertó" + e.ToString());
            }

            return updated;
        }
    }
}
