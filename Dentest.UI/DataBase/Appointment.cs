//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dentest.UI.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int ID { get; set; }
        public int DOCTORID { get; set; }
        public int PATIENTID { get; set; }
        public System.DateTime DATE { get; set; }
        public int HOUR { get; set; }
        public decimal PRICE { get; set; }
        public bool ISCAME { get; set; }
        public bool ISPAID { get; set; }
        public string TYPE { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
