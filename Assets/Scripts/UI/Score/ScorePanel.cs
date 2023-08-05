using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public void UpdateScore(string money)
    {
        _scoreText.text = "Заработано: " + money;
    }
}
