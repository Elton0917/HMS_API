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
    
    public partial class Manage_Health
    {
        public Manage_Health()
        {
            this.Record = new HashSet<Record>();
        }
    
        public string MHID { get; set; }
        public string UID { get; set; }
        public string HID { get; set; }
        public string H_Alert1 { get; set; }
        public string H_Alert2 { get; set; }
        public string H_Alert3 { get; set; }
    
        public virtual Health_Item Health_Item { get; set; }
        public virtual Login_User Login_User { get; set; }
        public virtual ICollection<Record> Record { get; set; }
    }
}
