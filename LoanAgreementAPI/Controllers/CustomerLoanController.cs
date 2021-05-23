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
    public class CustomerLoanController : ControllerBase
    {
        private readonly ICustomerLoanService _CustomerloanService;
        // GET: api/Category

        public CustomerLoanController(ICustomerLoanService CustomerloanServiceService)
        {
            _CustomerloanService = CustomerloanServiceService;
        }

        // GET: api/Item
        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<CustomerLoanViewModel>> Get(int CustomerId)
        {
            return Ok(await _CustomerloanService.GetCustomerloanByIdAsync(CustomerId));
        }
        


           // GET: api/Item
        [HttpGet("{Stardte}/{Enddate}/{Reporate}/{AgreementTypeId}/{Amount}/{CustomerId}")]
        public async Task<ActionResult<CustomerLoanViewModel>> Get(string Stardte, string Enddate, double Reporate, int AgreementTypeId, double Amount, int CustomerId)
        {
            return Ok(await _CustomerloanService.RequestLoanAgreement(Stardte, Enddate, Reporate, AgreementTypeId, Amount, CustomerId));
        }


        // GET: api/Item
        //[HttpGet()]
        //public async Task<List<CustomerLoanViewModel>> Get()
        //{
        //    return (await _CustomerloanService.GetAllCustomerAsync());
        //}

        [HttpGet()]
        public async Task<List<CustomerViewModel>> Get([FromBody] CustomerViewModel model)
        {
            return (await _CustomerloanService.GetAgreement(model));
        }

        [HttpGet()]
        public async Task<List<CustomerLoanViewModel>> Get([FromBody] CustomerLoanViewModel model)
        {
            return (await _CustomerloanService.GetAgreementReturen(model));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerLoanViewModel model)
        {
            return Ok(await _CustomerloanService.AddCustomerLoandAsync(model));
        }
    }
}
