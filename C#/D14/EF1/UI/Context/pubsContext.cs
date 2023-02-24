﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Context;

public partial class pubsContext : DbContext
{
    public pubsContext()
    {
    }

    public pubsContext(DbContextOptions<pubsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-RM9R44Q;Initial Catalog=pubs;Integrated Security=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PubId).HasName("UPKCL_pubind");

            entity.Property(e => e.PubId).IsFixedLength();
            entity.Property(e => e.Country).HasDefaultValueSql("('USA')");
            entity.Property(e => e.State).IsFixedLength();
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("UPKCL_titleidind");

            entity.Property(e => e.PubId).IsFixedLength();
            entity.Property(e => e.Pubdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('UNDECIDED')")
                .IsFixedLength();

            entity.HasOne(d => d.Pub).WithMany(p => p.Titles).HasConstraintName("FK__titles__pub_id__1A14E395");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}