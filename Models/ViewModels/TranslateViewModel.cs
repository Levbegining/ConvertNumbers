using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NS_ASP.Models.ViewModels;

public class TranslateViewModel
{
    [Required]
    [RegularExpression(@"[2-9]|[1-2][\d]|3[0-6]")]
    public string System { get; set; }

    public int Number { get; set; }

    [RegularExpression(@"[2-9]|[1-2][\d]|3[0-6]")]
    public string SystemOfNumber { get; set; }
}
