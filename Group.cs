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
    
    public partial class Group
    {
        public Group()
        {
            this.Group_Member = new HashSet<Group_Member>();
            this.Record = new HashSet<Record>();
        }
    
        public string GID { get; set; }
        public string UID { get; set; }
        public string G_Name { get; set; }
        public string G_Open { get; set; }
        public string HIID3 { get; set; }
        public string HIID4 { get; set; }
        public string HIID5 { get; set; }
        public string HIID1 { get; set; }
        public string HIID2 { get; set; }
    
        public virtual Login_User Login_User { get; set; }
        public virtual ICollection<Group_Member> Group_Member { get; set; }
        public virtual ICollection<Record> Record { get; set; }
    }
}
