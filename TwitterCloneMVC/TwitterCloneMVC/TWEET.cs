//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterCloneMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TWEET
    {
        [Key]
        public int tweet_id { get; set; }
        [DisplayName("Username")]
        public string user_id { get; set; }
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
        [DefaultValue(DataType.DateTime)]
        public System.DateTime created { get; set; } = System.DateTime.Now;
    
        public virtual Person Person { get; set; }
    }
}
