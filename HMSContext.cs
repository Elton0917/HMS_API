using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSAPI
{
    public class HMS_LUContext
    {
        public string UID { get; set; }
        public string U_Login { get; set; }
        public string U_Passwd { get; set; }
        public string U_FirstName { get; set; }
        public string U_LastName { get; set; }
        public string U_Gender { get; set; }
        public string U_Phone { get; set; }
        public string U_Email { get; set; }
        public string U_Address { get; set; }
        public string U_NiceName { get; set; }
        public string U_BirthDay { get; set; }
    }
    public class HMS_ManageHealth
    {
        public string MHID { get; set; }
        public string UID { get; set; }
        public string HID { get; set; }
        public string H_Alert1 { get; set; }
        public string H_Alert2 { get; set; }
        public string H_Alert3 { get; set; }
    }
    public class HMS_Health_Item
    {
        public string HIID { get; set; }
        public string H_Name { get; set; }
        public string H_Comment { get; set; }
    }
    public class HMS_Group
    {
        public string GID { get; set; }
        public string UID { get; set; }
        public string G_Name { get; set; }
        public string G_Open { get; set; }
        public string HIID1 { get; set; }
        public string HIID2 { get; set; }
        public string HIID3 { get; set; }
        public string HIID4 { get; set; }
        public string HIID5 { get; set; }
    }
    public class HMS_Group_Member
    {
        public string GMID { get; set; }
        public string GID { get; set; }
        public string UID { get; set; }
        public string G_Role { get; set; }
    }
}