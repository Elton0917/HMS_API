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

     public interface IHMS_MHRepository
     { 
         IEnumerable<HMS_ManageHealth> GetMH();
         HMS_ManageHealth Get(string UID);
         HMS_ManageHealth Add(HMS_ManageHealth msg);
         HMS_ManageHealth Remove(string UID,string MHID);
         bool Update(HMS_ManageHealth msg);
     }
     public interface IHMS_HIRepository
     {
         IEnumerable<HMS_Health_Item> GetHI();
         HMS_Health_Item Get(string HIID);
     }
     public interface IHMS_GPRepository
     {
         IEnumerable<HMS_Group> GetGP();
         HMS_Group Get(string GID);
         //HMS_Group Remove(string GID);
         //bool Update(HMS_Group msg);
     }
        
}
