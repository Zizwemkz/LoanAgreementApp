using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanAgreementAPI.Interfaces;
using LoanAgreementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAgreementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        // GET: api/Category

        public CustomerController(ICustomerService CustomerServiceService)
        {
            _CustomerService = CustomerServiceService;
        }

        // GET: api/Item
        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<CustomerViewModel>> Get(int CustomerId)
        {
            return Ok(await _CustomerService.GetCustomerByIdAsync(CustomerId));
        }


        // GET: api/Item
        [HttpGet()]
        public async Task<List<CustomerViewModel>> Get()
        {
            return (await _CustomerService.GetAllCustomerAsync());
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerViewModel model)
        {
            return Ok(await _CustomerService.AddCustomerAsync(model));
        }
    }
}
