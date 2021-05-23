using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

        public virtual DbSet<TbAgreementType> TbAgreementType { get; set; }
        public virtual DbSet<TbCustomer> TbCustomer { get; set; }
        public virtual DbSet<TbCustomerLoan> TbCustomerLoan { get; set; }
        //public virtual DbSet<TbOrder_Item> TbOrder_item { get; set; }
        //public DbQuery<TbCustomer> Customer { get; set; }
        public DbQuery<CustomerViewModel> Customermodel { get; set; }
        public DbQuery<CustomerLoanViewModel> Customerloanmodel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

      
        }

        }
    }
