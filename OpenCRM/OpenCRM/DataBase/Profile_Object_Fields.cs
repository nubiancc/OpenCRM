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
    
    public partial class Profile_Object_Fields
    {
        public int ProfileObjectFieldsId { get; set; }
        public Nullable<int> ProfileObjectId { get; set; }
        public Nullable<int> ObjectFieldsId { get; set; }
        public Nullable<bool> Read { get; set; }
        public Nullable<bool> Modify { get; set; }
        public Nullable<bool> Create { get; set; }
    
        public virtual Object_Fields Object_Fields { get; set; }
        public virtual Profile_Object Profile_Object { get; set; }
    }
}
