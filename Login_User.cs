//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Login_User
    {
        public Login_User()
        {
            this.Group = new HashSet<Group>();
            this.Manage_Health = new HashSet<Manage_Health>();
            this.Record = new HashSet<Record>();
            this.Remind = new HashSet<Remind>();
        }
    
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
        public Nullable<System.DateTime> U_BirthDay { get; set; }
    
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<Manage_Health> Manage_Health { get; set; }
        public virtual ICollection<Record> Record { get; set; }
        public virtual ICollection<Remind> Remind { get; set; }
    }
}