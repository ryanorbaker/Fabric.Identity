﻿using System.Threading.Tasks;
using Fabric.Identity.API.Persistence.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Fabric.Identity.API.Persistence.SqlServer.Services
{
    public interface IIdentityDbContext
    {
        DbSet<ClientDomainModel> Clients { get; set; }

        Task<int> SaveChangesAsync();
    }
}