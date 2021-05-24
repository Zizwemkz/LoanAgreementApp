using LoanAgreementAPI.Interfaces;
using LoanAgreementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Services
{
    public class CustomerLoanService : ICustomerLoanService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly string _conectionstring;

        public CustomerLoanService(ApplicationDbContext applicationDbContext,IConfiguration configiuration)
        {
            _dbContext = applicationDbContext;
            _conectionstring = configiuration.GetConnectionString("ConString");
        }


        public async Task<int> AddCustomerLoandAsync(CustomerLoanViewModel model)
        {

            var Customerloan = new TbCustomerLoan
            {
              AgreementId = model.AgreementTypeId,
              CustomerId = model.CustomerId,
              Amount = model.Amount,
              ReturnInterest =  model.ReturnInterest,
              RepoRate = model.RepoRate,
              StartDate =  model.StartDate,
              EndDate = model.EndDate
            };
            await _dbContext.TbCustomerLoan.AddAsync(Customerloan);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<CustomerLoanViewModel> GetCustomerloanByIdAsync(int CustomerloanId)
        {
            var result = await _dbContext.TbCustomerLoan.FindAsync(CustomerloanId);

            var Customerloanobj = new CustomerLoanViewModel
            {
                AgreementTypeId = result.AgreementId,
                CustomerId = result.CustomerId,
                Amount = Convert.ToDecimal(result.Amount),
                ReturnInterest = Convert.ToDecimal(result.ReturnInterest),
                RepoRate = result.RepoRate
            };

            return Customerloanobj;
        }


        public async Task<List<CustomerLoanViewModel>> GetAllCustomerAsync()
        {
            var Itemlist = await _dbContext.TbCustomerLoan.ToListAsync();
            var Allcustomerloans = new List<CustomerLoanViewModel>();

            foreach (var item in Itemlist)
            {
                Allcustomerloans.Add(new CustomerLoanViewModel
                {
                    AgreementTypeId = item.AgreementId,
                    CustomerId = item.CustomerId,
                    Amount = Convert.ToDecimal(item.Amount),
                    ReturnInterest = Convert.ToDecimal(item.ReturnInterest),
                    RepoRate = item.RepoRate,
                    StartDate =  item.StartDate,
                    EndDate = item.EndDate
                    
                });
            }
            if (Allcustomerloans.Count() == 0)
                throw new ArgumentException("No Item where found");

            return Allcustomerloans;
        }

        public async Task<CustomerLoanViewModel> RequestLoanAgreement(string Stardte, string Enddate,double Reporate, int AgreementTypeId, double Amount)
        {

            using(SqlConnection sql = new SqlConnection(_conectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("AgreementInterestReturn", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AgreementTypeID", AgreementTypeId));
                    cmd.Parameters.Add(new SqlParameter("@Amount", Amount));
                    cmd.Parameters.Add(new SqlParameter("@StartDate", Stardte));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", Enddate));
                    cmd.Parameters.Add(new SqlParameter("@RepoRate", Reporate));
                    ////cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    cmd.Parameters.Add(new SqlParameter("@return_status", ParameterDirection.Output));
                    cmd.Parameters.Add(new SqlParameter("@Calculation",ParameterDirection.Output));
                    cmd.Parameters.Add(new SqlParameter("@return_message", ParameterDirection.Output));
                    cmd.Parameters.Add(new SqlParameter("@return_Agreementtype", ParameterDirection.Output));

                  
                    CustomerLoanViewModel response = null;
                    await sql.OpenAsync();
                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapTovalue(reader);
                            }
                        }
                    }
                    catch(Exception e)
                    { }

                   
                    return response;
                }
               
            }
        }

     
        public CustomerLoanViewModel MapTovalue(SqlDataReader reader)
        {
            return new CustomerLoanViewModel()
            {
                ReturnInterest = Convert.ToDecimal(reader["Calculation"]),
                StatusCode = (int)reader["return_status"],
                TransectionMessage = reader["return_message"].ToString(),
                Agreementpicked = reader["return_Agreementtype"].ToString(),
                Amount = Convert.ToDecimal(reader["Amount"]),
            };
        }
     
    }
}
