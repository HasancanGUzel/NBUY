﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; }
        [DisplayName("Email adresi")]
        [Required(ErrorMessage ="{0} alanı zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Yeni parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
