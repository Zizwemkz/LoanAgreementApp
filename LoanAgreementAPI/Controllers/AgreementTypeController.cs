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
    public class AgreementTypeController : ControllerBase
    {
        private readonly IAgreementTypeService _AgreementTypeService;
        // GET: api/Category

        public AgreementTypeController(IAgreementTypeService AgreementTypeService)
        {
            _AgreementTypeService = AgreementTypeService;
        }

        // GET: api/Item
        [HttpGet("{AgreementId}")]
        public async Task<ActionResult<AgreementTypeViewModel>> Get(int AgreementId)
        {
            return Ok(await _AgreementTypeService.GetAgreementTypeByIdAsync(AgreementId));
        }


        // GET: api/Item
        [HttpGet()]
        public async Task<List<AgreementTypeViewModel>> Get()
        {
            return (await _AgreementTypeService.GetAllAgreementTypeAsync());
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AgreementTypeViewModel model)
        {
            return Ok(await _AgreementTypeService.AddAgreementTypeAsync(model));
        }

    }
}
