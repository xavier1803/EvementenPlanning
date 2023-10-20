using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EvementenPlanning.Models.Classes;

[Table("Organizer")]
public partial class Organizer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("firstName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("lastName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("phone")]
    public int? Phone { get; set; }

    [Column("organizationIndustry")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OrganizationIndustry { get; set; }
}
