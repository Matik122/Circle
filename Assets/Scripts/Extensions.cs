using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions 
{
    public static void SetPrefToText(this TextMeshProUGUI text, ref int total, int defaultValue, string pref)
    {
        if (PlayerPrefs.HasKey(pref))
        {
            text.text = PlayerPrefs.GetInt(pref).ToString();
            total = PlayerPrefs.GetInt(pref);
        }
        else
        {
            text.text = defaultValue.ToString();
        }
    }
    
    

}
