using System;
using System.Data.SqlClient;
using log4net;
using SqlQuerys.Properties;

namespace SqlQuerys
{
    public class StudentData : IStudentData
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentData));

        
        public Student Create(Student student)
        {
            student= StudentDataUtility.AddStudent(student.StudentName, student.StudentSurname, student.AgeOfBirth.ToString());
            logger.Info(student.StudentGuid1 + "...." + student.StudentName);
           
            try
            {
                SqlCommand commandSql = new SqlCommand(Resources.SqlInsert, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@studentGuid", student.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", student.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", student.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", student.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", student.StudentAge);
                commandSql.ExecuteNonQuery();
                logger.Info("Insertado");
            }
            catch (InvalidCastException exception)
            {
                logger.Error("no se insertó:    "+ exception);
                throw;
            }
            catch (SqlException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (System.IO.IOException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (ObjectDisposedException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (InvalidOperationException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            
            return student;
        }


        public bool Delete(int pId)
        {
            bool delete = false;
            try
            {
                SqlCommand commandSql = new SqlCommand(Resources.SqlDelete, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@pId", pId);
                commandSql.ExecuteNonQuery();
                delete = true;
            }
            catch (InvalidCastException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (SqlException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (System.IO.IOException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (ObjectDisposedException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (InvalidOperationException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }

            return delete;
        }
        public Student Read(int pId)
        {
            Student student = new Student();
            try
            {
                SqlCommand commandSql = new SqlCommand(Resources.SqlSelect, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@pId", pId); 
                commandSql.ExecuteNonQuery();
        SqlDataReader dataReaderSql = null;
                dataReaderSql = commandSql.ExecuteReader();
                while (dataReaderSql.Read())
                {
                    student = new Student(Convert.ToInt32(dataReaderSql["StudentId"]), Guid.Parse(dataReaderSql["StudentGuid"].ToString()), dataReaderSql["Name"].ToString(), dataReaderSql["Surname"].ToString(), Convert.ToDateTime(dataReaderSql["Birthday"]), Convert.ToInt32(dataReaderSql["Age"]));
                    logger.Info(student.StudentId + " " + student.StudentName + " " + student.AgeOfBirth);
                }
                dataReaderSql.Close();
            }
            catch (InvalidCastException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (SqlException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (System.IO.IOException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (ObjectDisposedException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (InvalidOperationException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            return student;
        }
       

        public Student Update(Student student)
        {
            
             student = Read(student.StudentId);
            Student studentNew = StudentDataUtility.AddStudent(student.StudentName, student.StudentSurname, student.AgeOfBirth.ToString());
            try
            {
                SqlCommand commandSql = new SqlCommand(Resources.SqlUpdate, ConnectionUtility.OpenConnection());
                commandSql.Parameters.AddWithValue("@pId", student.StudentId);
                commandSql.Parameters.AddWithValue("@studentGuid", studentNew.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", studentNew.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", studentNew.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", studentNew.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", studentNew.StudentAge);
                commandSql.ExecuteNonQuery();
                logger.Info("Update");
              
            }
            catch (InvalidCastException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (SqlException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (System.IO.IOException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (ObjectDisposedException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }
            catch (InvalidOperationException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
            }

            return student;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
            return base.Equals(obj);    
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}
