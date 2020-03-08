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


        public bool Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
