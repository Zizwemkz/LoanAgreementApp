using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Models
{
    public class TbAgreementType
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  AgreementTypeId { get; set; }
        [Display(Name = "AgreementName")]
        [Required(ErrorMessage = "AgreementName is required")]
        public string AgreementName { get; set; }
    }
}
