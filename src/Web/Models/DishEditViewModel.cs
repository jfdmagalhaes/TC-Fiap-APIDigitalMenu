using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class DishEditViewModel : DishRegisterViewModel
{
    [Required]
    public int Id { get; set; }
    public string UriFile { get; set; }
}