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

            Login_User message = new Login_User { UID = newUID, U_Login = msg.U_Login, U_Passwd = msg.U_Passwd, U_FirstName = msg.U_FirstName, U_LastName = msg.U_LastName, U_Gender = msg.U_Gender, U_Phone = msg.U_Phone, U_Email = msg.U_Email, U_Address = msg.U_Address, U_NiceName = msg.U_NiceName, U_BirthDay = Convert.ToDateTime(msg.U_BirthDay) };
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

    public class HMS_MHRepository : IHMS_MHRepository
    {
        #region GET User MH
        public IEnumerable<HMS_ManageHealth> GetMH()
        {

            List<HMS_ManageHealth> MH = new List<HMS_ManageHealth>();
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Array.ForEach(db.Manage_Health.OrderBy(m => m.UID).ToArray(),
                    m => MH.Add(new HMS_ManageHealth { MHID = m.MHID, UID = m.UID, HID = m.HID, H_Alert1 = m.H_Alert1, H_Alert2 = m.H_Alert2, H_Alert3 = m.H_Alert3 }));
            }
            return MH.AsEnumerable();
        }
        #endregion
        #region GET MH for UID
        public HMS_ManageHealth Get(string UID)
        {
            HMS_ManageHealth HMS = GetMH().Where(m => m.UID == UID).FirstOrDefault();
            return HMS;
        }
        #endregion
        #region Add Login_User ID
        public HMS_ManageHealth Add(HMS_ManageHealth msg)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
            SqlCommand cmdtop1 = new SqlCommand("select TOP 1 MHID from Manage_Health ORDER BY MHID DESC", Conn);
            string newMHID = null;
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
                newMHID = "MH" + dateNo + monthNo + showGF.ToString();
                Conn.Close();
            }
            else
            {
                newMHID = "MH13070000001";
            }
            Conn.Close();

            Manage_Health message = new Manage_Health { MHID = newMHID, UID = msg.UID, HID = msg.HID, H_Alert1 = msg.H_Alert1, H_Alert2 = msg.H_Alert2, H_Alert3 = msg.H_Alert3 };
            //doesn't have GP
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {

                db.Manage_Health.Add(message);
                db.SaveChanges();
                msg = new HMS_ManageHealth { MHID = newMHID, UID = message.UID, HID = message.HID, H_Alert1 = message.H_Alert1, H_Alert2 = message.H_Alert2, H_Alert3 = message.H_Alert3 };
            }
            return msg;
        }
        #endregion
        #region Remove Login_User ID
        public HMS_ManageHealth Remove(string UID, string MHID)
        {
            HMS_ManageHealth message;
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Manage_Health m = db.Manage_Health.Where(c => c.UID == UID).Where(c => c.MHID == MHID).FirstOrDefault();
                if (m == null)
                {
                    return null;
                }
                else
                {
                    message = new HMS_ManageHealth { UID = m.UID,MHID = m.MHID };
                    db.Manage_Health.Remove(m);
                    db.SaveChanges();
                }
            }

            return message;
        }
        #endregion
        #region Update Login_User ID
        public bool Update(HMS_ManageHealth msg)
        {
            bool blResult = false;
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Manage_Health m = db.Manage_Health.Where(c => c.UID == msg.UID).Where(c => c.MHID == msg.MHID).FirstOrDefault();
                if (m == null)
                {
                    return blResult;
                }
                else
                {
                    m.H_Alert1 = msg.H_Alert1;
                    m.H_Alert2 = msg.H_Alert2;
                    m.H_Alert3 = msg.H_Alert3;
                    db.SaveChanges();
                    blResult = true;
                }
            }
            return true;
        }
        #endregion
    }

    public class HMS_HIRepository : IHMS_HIRepository
    {
        #region GET Health Item
        public IEnumerable<HMS_Health_Item> GetHI()
        {

            List<HMS_Health_Item> HI = new List<HMS_Health_Item>();
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Array.ForEach(db.Health_Item.OrderBy(m => m.HIID).ToArray(),
                    m => HI.Add(new HMS_Health_Item { HIID = m.HIID, H_Name = m.H_Name, H_Comment = m.H_Comment }));
            }
            return HI.AsEnumerable();
        }
        #endregion
        #region GET One Health Item
        public HMS_Health_Item Get(string HIID)
        {
            HMS_Health_Item HMS = GetHI().Where(m => m.HIID == HIID).FirstOrDefault();
            return HMS;
        }
        #endregion
    }

    public class HMS_GPRepository : IHMS_GPRepository
    {
        #region GET Health Item
        public IEnumerable<HMS_Group> GetGP()
        {
            List<HMS_Group> GP = new List<HMS_Group>();
            using (HealthManageSystemEntities db = new HealthManageSystemEntities())
            {
                Array.ForEach(db.Group.OrderBy(m => m.GID).ToArray(),
                    m => GP.Add(new HMS_Group { GID = m.GID, UID = m.UID ,G_Name = m.G_Name,G_Open=m.G_Open}));
            }
            return GP.AsEnumerable();
        }
        #endregion
        #region GET One Health Item
        public HMS_Group Get(string GP)
        {
            HMS_Group HMS = GetGP().Where(m => m.GID == GP).FirstOrDefault();
            return HMS;
        }
        #endregion
    }
}