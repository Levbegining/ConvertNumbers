using System;
using NS_ASP.Models.ViewModels;
using NS_ASP.Services.Interfaces;

namespace NS_ASP.Services;

public class TranslationService : ITranslationService
{
    public string Translate(TranslateViewModel viewModel)
    {
        return Translate(viewModel.Number.ToString(), int.Parse(viewModel.SystemOfNumber), int.Parse(viewModel.System));
    }
             Dictionary<int, string> dictFromDecimal = new Dictionary<int, string>()
        {
            {10, "A"}, {11, "B"}, {12, "C"},
            {13, "D" }, {14, "E"}, {15, "F"}
        };
     Dictionary<string, int> dictBinaryToOctal = new Dictionary<string, int>()
        {
            {"000", 0}, {"00", 0}, {"0", 0}, {"001", 1}, {"01", 1}, {"1", 1 }, {"10", 2 },
            {"010", 2},{"011", 3}, {"11", 3}, {"100", 4 }, {"101", 5}, {"110", 6}, {"111", 7}
        };
     Dictionary<int, string> dictOctalToBinary = new Dictionary<int, string>()
        {
            {0, "000"}, {1, "001"}, {2, "010"}, {3, "011"},
            {4,"100" }, {5, "101"}, {6, "110"}, {7, "111"}
        };
     Dictionary<string, int> dictNumToDecimal = new Dictionary<string, int>()
        {
            {"0", 0 }, {"1", 1}, {"2", 2 }, {"3", 3}, {"4", 4},
            {"5", 5 }, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9},
            {"A", 10}, {"B", 11}, {"C", 12}, {"D", 13}, {"E", 14},
            {"F", 15 }
        };


    public string Translate(string num, int currentSystem, int system){
        if(IsCorrect(num, currentSystem, system) == false) return "";
        if(currentSystem == system){
            return num;
        }
        else if(currentSystem == 10){
            return NumFromDecimalSystemToOther(int.Parse(num), system);
        }
        else if(system == 10){
            return $"{NumToDecimalSystem(num, currentSystem)}";
        }
        else{
            var iRes = NumToDecimalSystem(num, currentSystem);
            NumFromDecimalSystemToOther(iRes, system);
        }
        
        return "";
    }
    private bool IsCorrect(string num, int currentSystem, int system)
    {
        if(currentSystem < 2 || system < 2) return false;
        if(int.TryParse(num, out int result)){
            if(result < 0) return false;
        }
        return true;
    }
    #region Стандартные переводы
    private string NumFromDecimalSystemToOther(int num, int syst)
    {
        string res = "";

        int b = 0;
        while (num > 0)
        {
            b = num % syst;
            if (b >= 10)
            {
                res = dictFromDecimal[b] + res;
            }
            else
            {
                res += b;
            }
            num = num / syst;
        }
        res = Reverse(res);
        return res;
    }
    private int NumToDecimalSystem(string _num, int currentSystem)
    {
        if (currentSystem < 10) return NumToDecimalSystemLess10(int.Parse(_num), currentSystem);
        else return NumToDecimalsystemMore10(_num, currentSystem);
    }
    private int NumToDecimalSystemLess10(int num, int currentSystem)
    {
        int res = 0;
        int midRes;
        int i = 0;
        while (num != 0)
        {
            midRes = num % 10;
            res += (int)Math.Pow(currentSystem, i) * midRes;
            i++;
            num = num / 10;

        }
        return res;
    }
    private int NumToDecimalsystemMore10(string num, int currentSystem)
    {
        int res = 0;
        int midRes = 0;
        int i = 0;
        int k = num.Length - 1;
        while (k >= 0)
        {
            midRes = dictNumToDecimal[num[k].ToString()];
            res += (int)Math.Pow(currentSystem, i) * midRes;
            i++;
            num = num.Remove(k);
            k--;
        }
        return res;
    }
    #endregion
    private int BinaryToOctal(int num)
    {
        string res = "";
        while (num > 0)
        {
            res = dictBinaryToOctal[(num % 1000).ToString()] + res;
            num = num / 1000;
        }
        return int.Parse(res);
    }
    private int OctalToBinary(int num)
    {
        string res = "";
        while (num > 0)
        {
            res = dictOctalToBinary[num % 10] + res;
            num = num / 10;
        }
        res = res.TrimStart("0"[0]);
        return int.Parse(res);
    }
    private string Reverse(string str)
    {
        string res = "";
        var arr = str.ToCharArray();
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            res += arr[i];
        }
        return res;
    }

    
}

