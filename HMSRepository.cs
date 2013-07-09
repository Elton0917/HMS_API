using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HMSAPI
{
    public class HMSRepository : IHMSRepository
    {
        #region GET Login_User
        public IEnumerable<HMS_LUContext> GetAll()
        {
            
            List<HMS_LUContext> HMSs = new List<HMS_LUContext>();
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Array.ForEach(db.Login_User.OrderBy(m => m.UID).ToArray(),
                    m => HMSs.Add(new HMS_LUContext { UID = m.UID, U_Login = m.U_Login, U_Passwd = m.U_Passwd, U_FirstName = m.U_FirstName, U_LastName = m.U_LastName, U_Gender = m.U_Gender, U_Phone = m.U_Phone, U_Email = m.U_Email, U_Address = m.U_Address, U_NiceName = m.U_NiceName, U_BirthDay = m.U_BirthDay.Value.ToString("yyyy/MM/dd") }));
            }
            return HMSs.AsEnumerable();
        }
        #endregion

        #region GET Login_User ID
        public HMS_LUContext Get(string UID)
        {
            HMS_LUContext HMS = GetAll().Where(m => m.UID == UID).FirstOrDefault();
            return HMS;
        }
        #endregion

        #region Add Login_User ID
        public HMS_LUContext Add(HMS_LUContext msg)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
            SqlCommand cmdtop1 = new SqlCommand("select TOP 1 UID from Login_User ORDER BY UID DESC", Conn);
            string newUID = null;
            Conn.Open();
            object obj = cmdtop1.ExecuteScalar();
            Conn.Close();
            if (obj != null)
            {
                Conn.Open();
                var dateNo = DateTime.Now.ToString("yy");
                var monthNo = DateTime.Now.ToString("MM");
                string dr = cmdtop1.ExecuteScalar().ToString();
                int drpluse = Convert.ToInt32(dr.Substring(5, 7));
                drpluse++;
                string UNO = drpluse.ToString();
                string showGF = UNO.PadLeft(7, '0');
                newUID = "H" + dateNo + monthNo+ showGF.ToString();
                Conn.Close();
            }
            else
            {
                newUID = "H13070000001";
            }
            Conn.Close();

            Login_User message = new Login_User { UID = newUID, U_Login = msg.U_Login, U_Passwd = msg.U_Passwd, U_BirthDay = Convert.ToDateTime(msg.U_BirthDay) };
            //doesn't have GP
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {

                db.Login_User.Add(message);
                db.SaveChanges();
                msg = new HMS_LUContext { UID = message.UID, U_Login = message.U_Login, U_Passwd = message.U_Passwd,U_FirstName = message.U_FirstName,U_LastName=message.U_LastName,U_Gender=message.U_Gender,U_Phone=message.U_Phone,U_Email = message.U_Email,U_Address = message.U_Address,U_NiceName=message.U_NiceName, U_BirthDay = message.U_BirthDay.Value.ToString("yyyy/MM/dd") };
            }
            return msg;
        }
        #endregion

        #region Remove Login_User ID
        public HMS_LUContext Remove(string UID)
        {
            HMS_LUContext message;
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Login_User m = db.Login_User.Where(c => c.UID == UID).FirstOrDefault();
                if (m == null)
                {
                    return null;
                }
                else
                {
                    message = new HMS_LUContext { UID = m.UID, U_BirthDay = m.U_BirthDay.Value.ToString("yyyy/MM/dd"), U_Login = m.U_Login, U_Passwd = m.U_Passwd };
                    db.Login_User.Remove(m);
                    db.SaveChanges();
                }
            }

            return message;
        }
        #endregion

        #region Update Login_User ID
        public bool Update(HMS_LUContext msg)
        {
            bool blResult = false;
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Login_User m = db.Login_User.Where(c => c.UID == msg.UID).FirstOrDefault();
                if (m == null)
                {
                    return blResult;
                }
                else
                {
                    m.U_Login = msg.U_Login;
                    m.U_Passwd = msg.U_Passwd;
                    m.U_FirstName = msg.U_FirstName;
                    m.U_LastName = msg.U_LastName;
                    //m.U_Gender = msg.U_Gender;
                    //m.U_Phone = msg.U_Phone;
                    //m.U_BirthDay = Convert.ToDateTime(msg.U_BirthDay);
                    db.SaveChanges();
                    blResult = true;
                }
            }
            return true;
        }
        #endregion
    }
}