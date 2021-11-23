using DemoGithubActions.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGithubActions.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _dbContext;
        public CustomersController(CustomerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public List<Customer> Get()
        {
            return _dbContext.Customers.ToList();
        }
    }
}
