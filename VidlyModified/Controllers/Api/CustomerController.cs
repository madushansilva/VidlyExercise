using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VidlyModified.Models;
using VidlyModified.Dtos;
using AutoMapper;

namespace VidlyNew.Controllers.Api
{
    [Authorize]
    public class CustomerController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

       // public IEnumerable<CustomerDto> GetCustomer()
       public IHttpActionResult GetCustomer()
        {
            //return _context.Customer.ToList().Select(Mapper.Map<Customer,CustomerDto>);
            var customerDtos = _context.Customer.Include(c => c.MemberShipType)
                            .ToList()
                            .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);


        }


        public CustomerDto GetCustomer(int id)
        {

            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto> (customer);

        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            //return customerDto;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //customerInDb.Name = customer.Name;
            //customerInDb.BirthDay = customer.BirthDay;
            //customerInDb.MemberShipType = customer.MemberShipType;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            Mapper.Map(customerDto,customerInDb);

            _context.SaveChanges();




        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}
