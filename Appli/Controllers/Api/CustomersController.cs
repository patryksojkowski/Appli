using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Appli.Models;
using Appli.Dtos;
using AutoMapper;


namespace Appli.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        // GET api/Customers
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = context.Customers
                .Include(c => c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customersDto = customersQuery.Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customersDto);
        }

        // GET api/Customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        // POST api/Customers
        [HttpPost]
        [Authorize(Roles= RoleName.CanManageCustomers)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            context.SaveChanges();
            return Created(new Uri($"{Request.RequestUri}/{customer.Id}"), customerDto);
        }

        // PUT api/Customers/1
        [HttpPut]
        [Authorize(Roles= RoleName.CanManageCustomers)]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerDb = context.Customers.FirstOrDefault(x => x.Id == id);
            if (customerDb is null)
            {
                return NotFound();
            }

            customerDb.UpdateModel(Mapper.Map<CustomerDto, Customer>(customerDto));
            context.SaveChanges();

            Mapper.Map(customerDb, customerDto);
            return Ok(customerDto);
        }

        // DELETE api/Customers/1
        [HttpDelete]
        [Authorize(Roles= RoleName.CanManageCustomers)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = context.Customers.FirstOrDefault(x => x.Id == id);
            if (customerDb is null)
            {
                return NotFound();
            }
            context.Customers.Remove(customerDb);
            context.SaveChanges();
            return Ok();
        }
    }
}
