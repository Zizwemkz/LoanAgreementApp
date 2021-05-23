using LoanAgreementAPI.Interfaces;
using LoanAgreementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Services
{
    public class AgreementTypeService : IAgreementTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public AgreementTypeService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


        public async Task<int> AddAgreementTypeAsync(AgreementTypeViewModel model)
        {
          
            if(model.AgreementTypeId != 0)
                throw new ArgumentException("Agreement Already Exists!");

            var AgreementType = new TbAgreementType
            {
                AgreementName = model.AgreementName,
            };
            await _dbContext.TbAgreementType.AddAsync(AgreementType);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<AgreementTypeViewModel> GetAgreementTypeByIdAsync(int AgreementId)
        {
            var result = await _dbContext.TbAgreementType.FindAsync(AgreementId);

            var AgreementType = new AgreementTypeViewModel
            {
                AgreementTypeId = result.AgreementTypeId,
               AgreementName = result.AgreementName
            };

            return AgreementType;
        }


        public async Task<List<AgreementTypeViewModel>> GetAllAgreementTypeAsync()
        {
            var Itemlist = await _dbContext.TbAgreementType.ToListAsync();
            var itempar = new List<AgreementTypeViewModel>();

            foreach (var item in Itemlist)
            {
                itempar.Add(new AgreementTypeViewModel
                {
                   AgreementTypeId = item.AgreementTypeId,
                   AgreementName = item.AgreementName
                });
            }
            if (itempar.Count() == 0)
                throw new ArgumentException("No Item where found");

            return itempar;
        }

    }
}
