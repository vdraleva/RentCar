using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentCar.Models
{ 
    [MetadataType(typeof(carRegistrationMetaData))]
    public partial class carInfoTable
    {
       
        public class carRegistrationMetaData
        {
            [DisplayName("Марка кола")]
            [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            public string brandCar { get; set; }
            [DisplayName("Модел кола")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            public string modelCar { get; set; }
            [DisplayName("Година на производство")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            public string yearCar { get; set; }
            [DisplayName("Брой пасажерски места")]
            [Range(2, 50)]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [Column(TypeName = "int")]
            public string numberSeats { get; set; }
            [DisplayName("Цена наем за ден")]
            [Range(20,300)]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [Column(TypeName = "decimal(18, 2)")]
            public decimal priceCar { get; set; }
           
            //public string avaliable { get; set; }
        

        }
    }
}