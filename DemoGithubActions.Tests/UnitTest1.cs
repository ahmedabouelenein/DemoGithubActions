using DemoGithubActions.API.Controllers;
using DemoGithubActions.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DemoGithubActions.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FakeTest()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public async Task AddCustomer()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            var optionsContext = new DbContextOptionsBuilder<CustomerDbContext>();
            optionsContext.UseSqlServer(configuration["ConnectionStrings:Default"]);

            var context = new CustomerDbContext(optionsContext.Options);
            await context.Database.EnsureDeletedAsync();

            await context.Database.EnsureCreatedAsync();

            context.Customers.Add(new Customer() { Name = "Khaled" });
            context.SaveChanges();


            var controller = new CustomersController(context);
            var customers = controller.Get().ToList();
            var khaled = customers.FirstOrDefault();
            Assert.NotNull(khaled);
            Assert.Equal("Khaled", khaled.Name);


        }
    }
}
