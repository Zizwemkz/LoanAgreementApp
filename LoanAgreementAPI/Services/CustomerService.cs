using LoanAgreementAPI.Interfaces;
using LoanAgreementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


        public async Task<int> AddCustomerAsync(CustomerViewModel model)
        {

            var Customer = new TbCustomer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                phone = model.phone,
                Email = model.Email
            };
            await _dbContext.TbCustomer.AddAsync(Customer);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<CustomerViewModel> GetCustomerByIdAsync(int CustomerId)
        {
            var result = await _dbContext.TbCustomer.FindAsync(CustomerId);

            var Customerobj = new CustomerViewModel
            {
                CustomerId = result.CustomerId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                phone = result.phone,
                Email = result.Email
            };

            return Customerobj;
        }


        public async Task<List<CustomerViewModel>> GetAllCustomerAsync()
        {
            var Itemlist = await _dbContext.TbCustomer.ToListAsync();
            var Allcustomers = new List<CustomerViewModel>();

            foreach (var item in Allcustomers)
            {
                Allcustomers.Add(new CustomerViewModel
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    phone = item.phone,
                    Email = item.Email
                });
            }
            if (Allcustomers.Count() == 0)
                throw new ArgumentException("No Item where found");

            return Allcustomers;
        }
    }
}
