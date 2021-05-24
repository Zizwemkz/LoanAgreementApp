using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Models
{
    public class TbCustomerLoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        
        [Required]
        [ForeignKey("TbAgreementType")]
        [Display(Name = "AgreementType")]
        public int AgreementId { get; set; }

        [Required]
        [ForeignKey("TbCustomer")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public decimal Amount { get; set; }
        public decimal ReturnInterest { get; set; }
        public double RepoRate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual TbCustomer TbCustomer { get; set; }
        public virtual TbAgreementType TbAgreementType { get; set; }
    }
}
