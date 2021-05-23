using LoanAgreementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(CustomerViewModel mode);
        Task<CustomerViewModel> GetCustomerByIdAsync(int CustomerId);
        Task<List<CustomerViewModel>> GetAllCustomerAsync();

    }
}
