using Dragonportal235.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dragonportal235.Data
{
    public class ApplicationDbContext : IdentityDbContext<FPUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dragonportal235.Models.BankAccount> BankAccount { get; set; }
        public DbSet<Dragonportal235.Models.Category> Category { get; set; }
        public DbSet<Dragonportal235.Models.CategoryItem> CategoryItem { get; set; }
        public DbSet<Dragonportal235.Models.Household> Household { get; set; }
        public DbSet<Dragonportal235.Models.Invitation> Invitation { get; set; }
        public DbSet<Dragonportal235.Models.Notification> Notification { get; set; }
        public DbSet<Dragonportal235.Models.Transaction> Transaction { get; set; }
    }
}
