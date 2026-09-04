using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.DataAccess
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions<NotesAppDbContext>options) : base(options)
        {

        }
            public DbSet<Note> Notes { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Tag> Tags { get; set; }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Note>()
            //    .Property(note => note.Text)
            //    .IsRequired();
            //modelBuilder.Entity<Note>()
            //    .Property(note => note.Priority)
            //    .IsRequired();
            //modelBuilder.Entity<Note>()
            //    .Property(note => note.Text)
            //    .IsRequired();
            //modelBuilder.Entity<Note>()
            //    .Property(note => note.Text)
            //    .IsRequired();
            //modelBuilder.Entity<Note>()
            //    .Property(note => note.Text)
            //    .IsRequired();

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note");//preimenuvanje na table vo baza
                entity.Property(note => note.Text)
                    .IsRequired()//ne e null
                    .HasMaxLength(100);

                //entity.ToTable("Note");//preimenuvanje na table vo baza
                entity.Property(note => note.Priority)
                    .IsRequired()//ne e null
                    .HasConversion<string>()//samo vo baza da bide zapisano vo string
                    .HasMaxLength(30);

                //One to Many relation
                entity.HasOne(note => note.User)
                    .WithMany(user => user.Notes)//dokolku sakame da gi imame vo List<Note> Notes vo User
                    .HasForeignKey(note => note.UserId)
                    .OnDelete(DeleteBehavior.Cascade);//ako imame user so 10 notes, i se brise userot, logicno e i notesot da se izbrisat

                entity.HasIndex(note => note.UserId);


                //many to many relation
                entity.HasMany(note => note.Tags)
                    .WithMany()
                    .UsingEntity(
                        //napravi ja relacijata ama deka treba megjutabela 
                        "NoteTag",
                        right => right.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId"),
                        left => left.HasOne(typeof(Note)).WithMany().HasForeignKey("NoteId")
                    );

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
