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
        [HttpGet("{Stardte}/{Enddate}/{Reporate}/{AgreementTypeId}/{Amount}")]
        public async Task<ActionResult<CustomerLoanViewModel>> Get(string Stardte, string Enddate, double Reporate, int AgreementTypeId, double Amount)
        {
            return Ok(await _CustomerloanService.RequestLoanAgreement(Stardte, Enddate, Reporate, AgreementTypeId, Amount));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerLoanViewModel model)
        {
            return Ok(await _CustomerloanService.AddCustomerLoandAsync(model));
        }
    }
}
