using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NS_ASP.Models.ViewModels;

public class TranslateViewModel
{
    [Required]
    [RegularExpression(@"[1-2]{1}[1-6]{1}", ErrorMessage = "недоступимая система счисления будущего числа(должна быть в диапазоне 1-16)")]
    public string System { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    [RegularExpression(@"[1-2]{1}[1-6]{1}", ErrorMessage = "недоступимая система счисления исходного числа(должна быть в диапазоне 1-16)")]
    public string SystemOfNumber { get; set; }
}
