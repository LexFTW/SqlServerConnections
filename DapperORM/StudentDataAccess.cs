using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperORM.LogUtility;
using DapperORM.Properties;

namespace DapperORM
{
    public class StudentDataAccess : IStudentDataAccess<Student>
    {
        private readonly LogginUtility logger = null;

        public StudentDataAccess()
        {
            logger = new LogginUtility();
        }

        public Student Create(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.SqlCreateQuery, student);
                    return student;
                }
                catch(SqlException sqlException) 
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public Student Delete(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.sqlDeleteById, student);
                    return student;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read()
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    var list = connection.Query<Student>(Resources.SqlSelectAll).ToList();
                    return list;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
                catch (ConfigurationErrorsException configurationErrorsException)
                {
                    logger.SetMessageError(configurationErrorsException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(configurationErrorsException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read(string value)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    var list = connection.Query<Student>(Resources.SqlSelectStrings, new {Name = "%" + value + "%", Surname = "%" + value + "%" }).ToList();
                    return list;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
                catch (ConfigurationErrorsException configurationErrorsException)
                {
                    logger.SetMessageError(configurationErrorsException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(configurationErrorsException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read(int value)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    var list = connection.Query<Student>(Resources.sqlSelectInts, new { Age = value}).ToList();
                    return list;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
                catch (ConfigurationErrorsException configurationErrorsException)
                {
                    logger.SetMessageError(configurationErrorsException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(configurationErrorsException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public Student ReadById(int id)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    var student = connection.QueryFirst<Student>(Resources.sqlSelectById, new { Id = id });
                    return student;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
                catch (ConfigurationErrorsException configurationErrorsException)
                {
                    logger.SetMessageError(configurationErrorsException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(configurationErrorsException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public Student Update(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.sqlUpdateQuery, student);
                    return student;
                }
                catch (SqlException sqlException)
                {
                    logger.SetMessageError(sqlException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(sqlException.StackTrace);
                    throw;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }
    }
}
