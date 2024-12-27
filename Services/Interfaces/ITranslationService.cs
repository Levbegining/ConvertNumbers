using System;
using NS_ASP.Models.ViewModels;

namespace NS_ASP.Services.Interfaces;

public interface ITranslationService
{
    void Translate(TranslateViewModel viewModel);
}
