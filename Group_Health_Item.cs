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
    
    public partial class Group_Health_Item
    {
        public string GHIID { get; set; }
        public string GID { get; set; }
        public string HIID { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Health_Item Health_Item { get; set; }
    }
}
