using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvidersApp.Models;

namespace ProvidersApp.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : Controller
    {

        ProviderContext dbContext;

        public ProvidersController(ProviderContext context)
        {
            dbContext = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<ProviderEntity> Read()
        {
            return dbContext.Providers;
        }

        [HttpPost("[action]")]
        public IEnumerable<ProviderEntity> Add([FromBody] ProviderEntity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return dbContext.Providers;
        }

        [HttpPut("[action]")]
        public IEnumerable<ProviderEntity> Update([FromBody] ProviderEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return dbContext.Providers;
        }

        [HttpDelete("[action]")]
        public IEnumerable<ProviderEntity> Delete([FromBody] ProviderEntity entity)
        {
            try
            {
                //var providerToDelete = dbContext.Providers.Find(entity);
                dbContext.Providers.Remove(entity);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                //some error handling 
            }
            return dbContext.Providers;
        }
    }
}