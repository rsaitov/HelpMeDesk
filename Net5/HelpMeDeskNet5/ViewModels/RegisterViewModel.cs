using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указан проект")]
        public int ProjectId { get; set; }
        public IEnumerable<ProjectDTO> Projects { get; set; }
    }
}
