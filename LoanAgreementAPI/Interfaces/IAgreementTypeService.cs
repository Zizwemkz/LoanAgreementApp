using LoanAgreementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Interfaces
{
    public interface IAgreementTypeService
    {
        Task<int> AddAgreementTypeAsync(AgreementTypeViewModel mode);
        Task<AgreementTypeViewModel> GetAgreementTypeByIdAsync(int AgreementId);
        Task<List<AgreementTypeViewModel>> GetAllAgreementTypeAsync();
    }
}
