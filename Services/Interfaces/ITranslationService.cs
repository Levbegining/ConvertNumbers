using System;

namespace NS_ASP.Services.Interfaces;

public interface ITranslationService
{
    // public string NumFromDecimalSystemToOther(int num, int syst);
    // public int NumToDecimalSystem(string _num, int currentSystem);
    // public int BinaryToOctal(int num);
    // public int OctalToBinary(int num);
    string Translate(string num, int currentSystem, int system);
}
