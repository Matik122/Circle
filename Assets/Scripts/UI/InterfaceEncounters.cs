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
        SetPrefToText(_score, ref _totalScore, _defaultValue, Constants.HighScoreDefinition);
        SetPrefToText(_distance, ref _totalDistance, _defaultValue, Constants.HighDistanceDefinition);
    }
    
    public void AddValue(int scoreValue, ref int total, TextMeshProUGUI text, string pref)
    {
        total += scoreValue;
        text.text = total.ToString();
        SetHighScore(total,pref);
    }
    
    private void SetHighScore(int highScore, string pref)
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
    
    private void SetPrefToText(TextMeshProUGUI text, ref int total, int defaultValue, string pref)
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