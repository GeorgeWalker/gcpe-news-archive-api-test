using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Hangfire;
using Newtonsoft.Json;
using Gov.News.Archive.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;

namespace Gov.News.Archive.Api.Controllers
{
    [Route("api/collections")]
    public class CollectionsController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly DbAppContext db;


        public CollectionsController(DbAppContext db, IConfiguration configuration)
        {
            Configuration = configuration;
            this.db = db;        
        }
        
        /// <summary>
        /// GET api/collections
        /// </summary>
        /// <returns>List of collections</returns>
        [AllowAnonymous]
        [HttpGet]
        async public Task<IActionResult> GetCollections()
        {
            List<Collection> result = await db.Collections.ToListAsync<Collection>();
            return new ObjectResult(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{collectionId:length(24)}/archives")]
        async public Task<IActionResult> GetCollectionArchives(string collectionId)
        {
            ObjectId id = new ObjectId(collectionId);
            List<Models.Archive> result = await db.Archives.Where(x => x.Collection.Id == id).ToListAsync();
           return new ObjectResult(result);
        }

    
    }
}
