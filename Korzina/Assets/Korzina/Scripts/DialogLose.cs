using Dialogs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogLose : Dialog
{

    public Text text;

    private void Start()
    {
        text.text = LevelController.Instance.score.ToString();
    }

    public void Restart()
    {
        LevelController.Instance.Restart();
        Close();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Close();
    }
}