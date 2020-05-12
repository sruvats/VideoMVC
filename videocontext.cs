using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using video.Models;

namespace video
{
    public class videocontext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembersipTypes { get; set; }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public videocontext()
            : base("name=defaultconnection")
        { }
    }
}