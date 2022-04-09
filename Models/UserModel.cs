using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    [MetadataType(typeof(userMetaData))]
    public partial class userTable
    {

        public class userMetaData
        {

            [DisplayName("Потребителско име")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [StringLength(20, MinimumLength = 3)]
            [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
            public string username { get; set; }
            [DisplayName("Парола")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [DataType(DataType.Password)]
            public string password { get; set; }
            [DisplayName("Собствено име")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
            public string nameUser { get; set; }
            [DisplayName("Фамилно име")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
            public string familyUser { get; set; }
            [DisplayName("ЕГН")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            public string EGN { get; set; }
            [DisplayName("Телефонен номер")]
            [Required(ErrorMessage = "Това поле е задължително!")]
            [RegularExpression(@"/08[789]\d{7}/")]
            public string phone { get; set; }
            [DisplayName("Имейл")]
            public string email { get; set; }

        }
    }
}