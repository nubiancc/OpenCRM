//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenCRM.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Case_Origin
    {
        public Case_Origin()
        {
            this.Cases = new HashSet<Cases>();
        }
    
        public int CaseOriginId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Cases> Cases { get; set; }
    }
}
