using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EvementenPlanning.Models.Classes;

[Table("Event")]
public partial class Event
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("date", TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column("time")]
    public int? Time { get; set; }

    [Column("location")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("cost")]
    public int? Cost { get; set; }

    [Column("maxAttendees")]
    public int? MaxAttendees { get; set; }

    [Column("text")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Text { get; set; }

    [Column("image")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Image { get; set; }

    [Column("category")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Category { get; set; }

    [InverseProperty("Event")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
