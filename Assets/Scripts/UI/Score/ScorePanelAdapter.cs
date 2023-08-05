using UnityEngine;
using Zenject;

public class ScorePanelAdapter : MonoBehaviour
{
    [SerializeField] private ScorePanel _scorePanel;

    private IPlayer _player;

    [Inject]
    private void Construct(PlayerService playerService)
    {
        _player = playerService.GetPlayer();

        _player.OnMoneyChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        _player.OnMoneyChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scorePanel.UpdateScore(score.ToString());
    }
}
