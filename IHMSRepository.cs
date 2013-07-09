using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSAPI
{
    public interface IHMSRepository
    {
        IEnumerable<HMS_LUContext> GetAll();
        HMS_LUContext Get(string UID);
        HMS_LUContext Add(HMS_LUContext msg);
        HMS_LUContext Remove(string UID);
        bool Update(HMS_LUContext msg);
    }
}
