using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Blueshift.EntityFrameworkCore.MongoDB.Annotations;

namespace Gov.News.Archive.Api.Models
{
    /// <summary>
    /// Database Context Factory Interface
    /// </summary>
    public interface IDbAppContextFactory
    {
        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns></returns>
        IDbAppContext Create();
    }

    /// <summary>
    /// Database Context Factory
    /// </summary>
    public class DbAppContextFactory : IDbAppContextFactory
    {
        private readonly DbContextOptions<DbAppContext> _options;

        /// <summary>
        /// Database Context Factory Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="options"></param>
        public DbAppContextFactory(DbContextOptions<DbAppContext> options)
        {
            _options = options;
        }

        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns></returns>
        public IDbAppContext Create()
        {
            return new DbAppContext(_options);
        }
    }

    /// <summary>
    /// Database Context Interface
    /// </summary>
    public interface IDbAppContext
    {
        /// <summary>
        /// Collection
        /// </summary>
        DbSet<Collection> Collections { get; set; }

        /// <summary>
        /// Archive
        /// </summary>
        DbSet<Archive> Archives { get; set; }

        /// <summary>
        /// Ministry records
        /// </summary>
        DbSet<Ministry> Ministries { get; set; }

    }

    /// <summary>
    /// Database Context Interface
    /// </summary>
    [MongoDatabase("NewsArchiveDb")]
    public class DbAppContext : DbContext, IDbAppContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor for Class used for Entity Framework access.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="options"></param>
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
        {
            
            // override the default timeout as some operations are time intensive
            // Database?.SetCommandTimeout(180);
        }
        
        /// <summary>
        /// Collection
        /// </summary>
        public DbSet<Collection> Collections { get; set; }

        /// <summary>
        /// Archive
        /// </summary>
        public DbSet<Archive> Archives { get; set; }

        /// <summary>
        /// Ministries
        /// </summary>
        public DbSet<Ministry> Ministries { get; set; }

    }
}
