using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStoredProcedures
{
    public interface IStudentData
    {
        bool Create(Student student);
        Student Read(int pId);
        bool Update(Student student);
        bool Delete(int pId);
    }
}
