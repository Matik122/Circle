using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceEncounters : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    private int _totalScore;

    public void AddScore(int scoreValue)
    {
        _totalScore += scoreValue;
        _score.text = _totalScore.ToString();
    }
}
