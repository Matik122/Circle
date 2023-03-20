using TMPro;
using UnityEngine;

public class InterfaceEncounters : MonoBehaviour
{
    public ref int TotalScore => ref _totalScore;
    public ref int TotalDistacne => ref _totalDistance;
    public TextMeshProUGUI Score => _score;
    public TextMeshProUGUI Distance => _distance;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _distance;
    [SerializeField] private int _defaultValue;
    private int _totalScore;
    private int _totalDistance;
    
    private void Start()
    {
        _score.SetPrefToText(ref _totalScore,_defaultValue,Constants.HighScoreDefinition);
        _distance.SetPrefToText(ref _totalDistance,_defaultValue,Constants.HighDistanceDefinition);
    }
    
    public void AddValue(int scoreValue, ref int total, TextMeshProUGUI text,string pref)
    {
        total += scoreValue;
        text.text = total.ToString();
        SetHighScore(total,pref);
    }
    
    private void SetHighScore(int highScore,string pref)
    {
        if (highScore > PlayerPrefs.GetInt(pref))
        {
            PlayerPrefs.SetInt(pref, highScore);
        }
        else if (!PlayerPrefs.HasKey(pref))
        {
            PlayerPrefs.SetInt(pref, highScore);
        }
    }

}
