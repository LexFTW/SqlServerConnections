using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using EntityFrameworkDatabaseFirst.Database_First;
using EntityFrameworkDatabaseFirst.LogUtility;
using EntityFrameworkDatabaseFirst.Properties;

namespace EntityFrameworkDatabaseFirst
{
    public class StudentDataAccess : IStudentDataAccess
    {

        private readonly LogginUtility logger = null;

        public StudentDataAccess()
        {
            logger = new LogginUtility();
        }

        public Student Create(Student student)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return student;
                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    logger.SetMessageError(dbUpdateConcurrencyException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(dbUpdateConcurrencyException.StackTrace);
                    throw;
                }
                catch (DbUpdateException dbUpdateException)
                {
                    logger.SetMessageError(dbUpdateException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(dbUpdateException.StackTrace);
                    throw;
                }
                catch (DbEntityValidationException dbEntityValidationException)
                {
                    logger.SetMessageError(dbEntityValidationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(dbEntityValidationException.StackTrace);
                    throw;
                }
                catch (NotSupportedException notSupportedException)
                {
                    logger.SetMessageError(notSupportedException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(notSupportedException.StackTrace);
                    throw;
                }
                catch (ObjectDisposedException objectDisposedException)
                {
                    logger.SetMessageError(objectDisposedException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(objectDisposedException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionCreate);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
            }
        }

        public Student Delete(Student student)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    db.Entry(student).State = EntityState.Deleted;
                    db.SaveChanges();
                    return student;
                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    logger.SetMessageError(dbUpdateConcurrencyException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(dbUpdateConcurrencyException.StackTrace);
                    throw;
                }
                catch (DbUpdateException dbUpdateException)
                {
                    logger.SetMessageError(dbUpdateException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(dbUpdateException.StackTrace);
                    throw;
                }
                catch (DbEntityValidationException dbEntityValidationException)
                {
                    logger.SetMessageError(dbEntityValidationException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(dbEntityValidationException.StackTrace);
                    throw;
                }
                catch (NotSupportedException notSupportedException)
                {
                    logger.SetMessageError(notSupportedException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(notSupportedException.StackTrace);
                    throw;
                }
                catch (ObjectDisposedException objectDisposedException)
                {
                    logger.SetMessageError(objectDisposedException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(objectDisposedException.StackTrace);
                    throw;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    logger.SetMessageError(invalidOperationException.Message, Resources.sqlExceptionDelete);
                    logger.StackTraceAboutError(invalidOperationException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read(string value)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(s => s.Name.Contains(value)
                    || s.Surname.Contains(value)).ToList();
                    return students;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionRead);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read(int value)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.Where(s => s.Age == value).ToList();
                    return students;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionRead);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public List<Student> Read()
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var students = db.Students.ToList();
                    return students;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionRead);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public Student ReadById(int id)
        {
            using (var db = new StudentContext())
            {
                try
                {
                    var student = db.Students.Find(id);
                    return student;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionRead);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }

        public Student Update(Student student)
        {
            var studentInDatabase = ReadById(student.StudentId);
            studentInDatabase.Name = student.Name;
            studentInDatabase.Surname = student.Surname;
            studentInDatabase.Age = student.Age;
            studentInDatabase.StudentGuid = student.StudentGuid;

            using (var db = new StudentContext())
            {
                try
                {
                    db.SaveChanges();
                    return studentInDatabase;
                }
                catch (ArgumentNullException argumentNullException)
                {
                    logger.SetMessageError(argumentNullException.Message, Resources.sqlExceptionUpdate);
                    logger.StackTraceAboutError(argumentNullException.StackTrace);
                    throw;
                }
            }
        }
    }
}
