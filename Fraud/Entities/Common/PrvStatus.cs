﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fraud.Entities.Common
{
    [Table("tblPrvStatus", Schema = "cmn")]
    public partial class PrvStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}