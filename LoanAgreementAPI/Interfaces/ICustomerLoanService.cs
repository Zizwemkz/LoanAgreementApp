using LoanAgreementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Interfaces
{
    public interface ICustomerLoanService
    {
        Task<int> AddCustomerLoandAsync(CustomerLoanViewModel mode);
        Task<CustomerLoanViewModel> GetCustomerloanByIdAsync(int CustomerloanId);
        Task<List<CustomerLoanViewModel>> GetAllCustomerAsync();
        Task<CustomerLoanViewModel> RequestLoanAgreement(string Stardte, string Enddate, double Reporate, int AgreementTypeId, double Amount, int CustomerId);
        Task<List<CustomerViewModel>> GetAgreement(CustomerViewModel mode); 
        Task<List<CustomerLoanViewModel>> GetAgreementReturen(CustomerLoanViewModel mode);
    }
}
