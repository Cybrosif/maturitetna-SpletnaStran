using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace maturitetna_NovaTestnaStran.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    public int DomainId { get; set; }  

    public List<DomainItem> DomainList { get; set; }
}

public class DomainItem
{
    public int Value { get; set; }
    public string Text { get; set; }
}