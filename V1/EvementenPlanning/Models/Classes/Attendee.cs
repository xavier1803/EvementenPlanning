using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvementenPlanning.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace EvementenPlanning.Models;

[Table("Attendee")]
public partial class Attendee
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

    [InverseProperty("Attendee")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
