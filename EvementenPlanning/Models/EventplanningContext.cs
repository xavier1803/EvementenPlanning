using System;
using System.Collections.Generic;
using EvementenPlanning.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace EvementenPlanning.Models;

public partial class EventplanningContext : DbContext
{
    public EventplanningContext()
    {
    }

    public EventplanningContext(DbContextOptions<EventplanningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Eventplanning;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.Tickets).HasForeignKey(o => o.Id);
            entity.HasOne(d => d.Attendee).WithMany(p => p.Tickets).HasForeignKey(o => o.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
