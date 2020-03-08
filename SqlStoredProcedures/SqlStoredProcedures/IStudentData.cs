using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStoredProcedures
{
    interface IStudentData
    {
        bool Create(string pName, string pSurname, string pBirth);
        Student Read(int pId);
        bool Update(int pId, string pName, string pSurname, string pBirth);
        bool Delete(int pId);
    }
}
