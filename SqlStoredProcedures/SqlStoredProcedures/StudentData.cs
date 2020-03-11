using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace SqlStoredProcedures
{
    public class StudentData:IStudentData
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentData));
      
        
        public Student Create(Student student)
        {
          student = StudentDataUtility.AddStudent(student.StudentName, student.StudentSurname, student.AgeOfBirth.ToString());
            logger.Info(student.StudentGuid1 + "...." + student.StudentName);
           
            try
            {
                SqlCommand commandSql = new SqlCommand("InsertStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
                commandSql.Parameters.AddWithValue("@studentGuid", student.StudentGuid1);
                commandSql.Parameters.AddWithValue("@studentName", student.StudentName);
                commandSql.Parameters.AddWithValue("@studentSurname", student.StudentSurname);
                commandSql.Parameters.AddWithValue("@studentBirthday", student.AgeOfBirth);
                commandSql.Parameters.AddWithValue("@studentAge", student.StudentAge);
                commandSql.ExecuteNonQuery();
              
            }
            catch (ArgumentNullException exception)
            {
                logger.Error("no se insertó:    " + exception);
                throw;
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

        public bool Delete(int pId)
        {
            bool delete = false;
            try
            {
                SqlCommand commandSql = new SqlCommand("DeleteStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
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

        public  Student Read(int pId)
        {
            Student student = new Student();
            try
            {
                SqlCommand commandSql = new SqlCommand("SelectStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
                commandSql.Parameters.AddWithValue("@pId", pId);
                commandSql.ExecuteNonQuery();
              SqlDataReader dataReaderSql = commandSql.ExecuteReader();
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
        { bool updated = false;
            
            Student studentNew = StudentDataUtility.AddStudent(student.StudentName, student.StudentSurname, student.AgeOfBirth.ToString());
            try
            {
                SqlCommand commandSql = new SqlCommand("UpdateStudent", ConnectionUtility.OpenConnection());
                commandSql.CommandType = CommandType.StoredProcedure;
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
    }
}
