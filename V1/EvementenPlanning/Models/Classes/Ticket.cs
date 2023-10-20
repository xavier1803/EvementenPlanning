using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EvementenPlanning.Models.Classes;

[Table("Ticket")]
public partial class Ticket
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("attendeeId")]
    public int? AttendeeId { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    [Column("eventId")]
    public int? EventId { get; set; }

    [ForeignKey("AttendeeId")]
    [InverseProperty("Tickets")]
    public virtual Attendee? Attendee { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("Tickets")]
    public virtual Event? Event { get; set; }
}
