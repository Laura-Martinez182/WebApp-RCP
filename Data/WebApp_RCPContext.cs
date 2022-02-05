#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_RCP.Models;

namespace WebApp_RCP.Data
{
    public class WebApp_RCPContext : DbContext
    {
        public WebApp_RCPContext (DbContextOptions<WebApp_RCPContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp_RCP.Models.User> User { get; set; }
    }
}
