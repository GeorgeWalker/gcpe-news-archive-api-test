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
using MongoDB.Bson;

namespace Gov.News.Archive.Api.Controllers
{
    [Route("api/archives")]
    public class ArchivesController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly DbAppContext db;


        public ArchivesController(DbAppContext db, IConfiguration configuration)
        {
            Configuration = configuration;
            this.db = db;        
        }
        
        
        
        /// <summary>
        /// GET api/collections
        /// </summary>
        /// <returns>List of collections</returns>
        [HttpGet]
        async public Task<IActionResult> GetArchives()
        {
            List<Models.Archive> result = await db.Archives.ToListAsync<Models.Archive>();
            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult AddArchive([FromBody] Models.Collection newArchive)
        {
            /*
            //Models.Archive data = JsonConvert.DeserializeObject<Models.Archive>(newArchive);
            // first add the collection.
            Collection c = newArchive.Collection;

            Collection added = null;

            if (c.Id != null)
            {
                added = db.Collections.FirstOrDefault(x => x.Id == c.Id);
            }
            if (added == null)
            {
                db.Collections.Add(c);
                db.SaveChanges();
                newArchive.Collection = c;
            }
            db.Archives.Add(newArchive);

            return new ObjectResult(newArchive);
            */
            return new ObjectResult("");
        }
    

        [HttpGet("{archiveId:length(24)}")]
        public IActionResult GetArchive( string archiveId)
        {
            ObjectId id = new ObjectId(archiveId);
            Models.Archive result = db.Archives.FirstOrDefault(x => x.Id == id);
            return new ObjectResult(result);
        }
        
    }
}
