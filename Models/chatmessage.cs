﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SignalrD1.Models;

[Table("chatmessage")]
public partial class chatmessage
{
    [Key]
    public int id { get; set; }

    public string messagetxt { get; set; }

    [StringLength(150)]
    public string username { get; set; }
}