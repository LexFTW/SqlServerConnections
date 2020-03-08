using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SqlQuerys
{
    class StudentData : IStudentData
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentData));
        SqlCommand commandSql;
        SqlDataReader dataReaderSql;
        public bool Create(string pName, string pSurname, string pBirth)
        {
           Student student= StudentDataUtility.AddStudent(pName, pSurname, pBirth);
            bool created = false;
            try
            {
                commandSql = new SqlCommand("insert into Student(StudentGuid,Name,Surname,Birthday,Age) values ('" +student.StuidetnGuid1+ "','" + student.StudentName + "','" + student.StudentSurname + "','" + student.AgeOfBirth + "','"+student.StudentAge+ "')", ConnectionUtility.OpenConnection());
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
                commandSql = new SqlCommand("delete from Libros where Codigo=" + pId, ConnectionUtility.OpenConnection());
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
                commandSql = new SqlCommand("select * from Student where StudentId=" + pId, ConnectionUtility.OpenConnection());
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

        public bool Update(int pId)
        {
            bool updated = false;
            Student student = Read(pId);
            try
            {
                commandSql = new SqlCommand("update Student set StudentGuid='"+student.StuidetnGuid1 +"',Name='" + student.StudentName + "',Surname='" + student.StudentSurname + "',Birthday='" + student.AgeOfBirth+"',Age='"+ student.StudentAge +"' where StudentId= " + pId, ConnectionUtility.OpenConnection());
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
