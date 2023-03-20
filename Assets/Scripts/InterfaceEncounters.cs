using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class InterfaceEncounters : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private int _defaultScoreValue;
    private int _totalScore;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _score.SetPrefToText("HighScore");
            _totalScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            _score.text = _defaultScoreValue.ToString();
        }
    }


    public void AddScore(int scoreValue)
    {
        _totalScore += scoreValue;
        _score.text = _totalScore.ToString();
        SetHighScore(_totalScore);
    }
    
    public void SetHighScore(int highScore)
    {
        if (highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        else if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _totalScore);
        }
    }

}
