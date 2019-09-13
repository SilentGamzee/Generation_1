using UnityEngine;
using UnityEngine.UI;

public class ScoreUIHandler : MonoBehaviour
{
    //EDITOR VARIABLES

    [SerializeField] private Text _scoreT;
    [SerializeField] private Text _bestScoreT;

    private void Start()
    {
        _bestScoreT.text = ScoreManager.Instance.BestScore.ToString();
        _scoreT.text = ScoreManager.Instance.Score.ToString();
        ScoreManager.Instance.OnUpdateScoreEvent += UpdateUI;
    }

    private void UpdateUI(int _score, int _bestScore)
    {
        _scoreT.text = _score.ToString();
        _bestScoreT.text = _bestScore.ToString();
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.OnUpdateScoreEvent -= UpdateUI;
    }
}