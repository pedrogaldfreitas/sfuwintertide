
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AllDiagOptions : MonoBehaviour
{
    public string diag0;
    public string diag1;
    public string diag2;
    public string diag3;
    public string diag4;
    public string diag5;
    public string diag6;
    public string diag7;
    public string diag8;
    public string diag9;



    public string GetProperDiagOption(string diag)
    {
        switch (diag)
        {
            case "diag0":
                return diag0;
            case "diag1":
                return diag1;
            case "diag2":
                return diag2;
            case "diag3":
                return diag3;
            case "diag4":
                return diag4;
            case "diag5":
                return diag5;
            case "diag6":
                return diag6;
            case "diag7":
                return diag7;
            case "diag8":
                return diag8;
            case "diag9":
                return diag9;
        }

        return diag0;
    }
}
