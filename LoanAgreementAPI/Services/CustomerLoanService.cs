using LoanAgreementAPI.Interfaces;
using LoanAgreementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
              AgreementId = model.AgreementId,
              CustomerId = model.CustomerId,
              Amount =  model.Amount,
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
                AgreementId = result.AgreementId,
                CustomerId = result.CustomerId,
                Amount = result.Amount,
                ReturnInterest = result.ReturnInterest,
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
                    AgreementId = item.AgreementId,
                    CustomerId = item.CustomerId,
                    Amount = item.Amount,
                    ReturnInterest = item.ReturnInterest,
                    RepoRate = item.RepoRate,
                    StartDate =  item.StartDate,
                    EndDate = item.EndDate
                    
                });
            }
            if (Allcustomerloans.Count() == 0)
                throw new ArgumentException("No Item where found");

            return Allcustomerloans;
        }

        public async Task<CustomerLoanViewModel> RequestLoanAgreement(string Stardte, string Enddate,double Reporate, int AgreementTypeId, double Amount, int CustomerId)
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
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    CustomerLoanViewModel response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while ( await reader.ReadAsync())
                        {
                            response  = MapTovalue(reader);
                        }
                    }
                    return response;
                }
               
            }
        }

        public async Task<List<CustomerLoanViewModel>> GetAgreementReturen(CustomerLoanViewModel model)
        {

            var AgreementTypeID = new SqlParameter("@AgreementTypeID", model.AgreementId);
            var Amount = new SqlParameter("@Amount", model.Amount);
            var StartDate = new SqlParameter("@StartDate", model.StartDate);
            var EndDate = new SqlParameter("@EndDate", model.EndDate);
            var RepoRate = new SqlParameter("@RepoRate", model.RepoRate);
            var CustomerId = new SqlParameter("@CustomerId", model.CustomerId);
          
            var users = await _dbContext
                     .Customerloanmodel.FromSql("exec dbo.AgreementInterestReturn @AgreementTypeID, @Amount,@StartDate,@EndDate,@RepoRate,@CustomerId,", AgreementTypeID, Amount, StartDate, EndDate, RepoRate, CustomerId)
                     .ToListAsync();
            //var baseItem = _dbContext.TbCustomer.FromSql("Execute dbo.GetBaseItems @id = {0} ,@name = {1}", id, "itemName");
            return users;
        }


        public async  Task<List<CustomerViewModel>> GetAgreement( CustomerViewModel model)
        {
            var email = new SqlParameter("@email", model.Email);
            var CustomerId = new SqlParameter("@CustomerId", model.CustomerId);

            var users = await _dbContext
                        .Customermodel.FromSql("exec GetCustomers @email, @CustomerId", email, CustomerId)
                        .ToListAsync();
            //var baseItem = _dbContext.TbCustomer.FromSql("Execute dbo.GetBaseItems @id = {0} ,@name = {1}", id, "itemName");
            return users;
        }

        public CustomerLoanViewModel MapTovalue(SqlDataReader reader)
        {
            return new CustomerLoanViewModel()
            {
                ReturnInterest = (float)reader["Calculation"],
                StatusCode = (int)reader["return_status"],
                TransectionMessage = reader["return_message"].ToString(),
                AgreementId = (int)reader["return_Agreementtype"],
                CustomerId = (int)reader["CustomerId"],
                Amount = (float)reader["Amount"],
            };
        }
     
    }
}
