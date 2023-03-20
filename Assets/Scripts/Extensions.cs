using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions 
{
    public static void SetPrefToText(this TextMeshProUGUI text, string pref)
    {
        text.text = PlayerPrefs.GetInt(pref).ToString();
    }
    
    public static void SetPrefToInt(this int value, string pref)
    {
        value = PlayerPrefs.GetInt(pref);
    }

}
