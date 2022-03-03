using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени не менее 15 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина фамилии не менее 15 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]      
        [StringLength(40)]
        [Required(ErrorMessage = "Длина адреса не менее 40 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина номера не менее 20 знаков")]
        public string phone { get; set; }

        [Display(Name = "Еmail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(35)]
        [Required(ErrorMessage = "Длина email не менее 35 знаков")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public  DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
