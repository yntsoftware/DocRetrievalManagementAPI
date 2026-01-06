
using DocRetrievalManagementAPI.Models;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.EntityFrameworkCore;
using System;

namespace DocRetrievalManagementAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Documents> Documents { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }

    }
}
