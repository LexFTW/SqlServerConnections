using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperORM.Properties;
using log4net;

namespace DapperORM
{
    public class StudentDataAccess : IStudentDataAccess
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Student));

        public StudentDataAccess()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

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
                    logger.Error(Resources.sqlExceptionCreate);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public bool Delete(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.sqlDeleteById, student);
                    return true;
                }
                catch (Exception e)
                {
                    logger.Error(Resources.sqlExceptionDelete);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public List<Student> Read()
        {
            var list = new List<Student>();
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    list = connection.Query<Student>(Resources.SqlSelectAll).ToList();
                    return list;
                }
                catch (Exception e)
                {
                    logger.Error(Resources.sqlExceptionRead);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public List<Student> Read(string value)
        {
            var list = new List<Student>();
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    list = connection.Query<Student>(Resources.SqlSelectStrings, new {Name = "%" + value + "%", Surname = "%" + value + "%" }).ToList();
                    return list;
                }catch(Exception e)
                {
                    logger.Error(Resources.sqlExceptionRead);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public List<Student> Read(int value)
        {
            var list = new List<Student>();
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    list = connection.Query<Student>(Resources.sqlSelectInts, new { Age = value}).ToList();
                    return list;
                }
                catch (Exception e)
                {
                    logger.Error(Resources.sqlExceptionRead);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public Student ReadById(int id)
        {
            Student student = new Student();
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Open();
                    student = connection.QueryFirst<Student>(Resources.sqlSelectById, new { Id = id });
                    return student;
                }
                catch (Exception e)
                {
                    logger.Error(Resources.sqlExceptionRead);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }

        public bool Update(Student student)
        {
            using (var connection = new SqlConnection(Resources.SimpleConnection))
            {
                try
                {
                    connection.Execute(Resources.sqlUpdateQuery, student);
                    return true;
                }
                catch (Exception e)
                {
                    logger.Error(Resources.sqlExceptionUpdate);
                    logger.Error(e.Message);
                    throw;
                }
            }
        }
    }
}
