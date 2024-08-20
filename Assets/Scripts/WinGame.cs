using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _winText;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _exitGame;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _winText.text = $"YAHOO! Your number: {MagicNumbersUI.Guess}! Total steps: {MagicNumbersUI.Step}";
        _restartGame.onClick.AddListener(RestartGame);
        _exitGame.onClick.AddListener(ExitGame);
    }

    #endregion

    #region Private methods

    private void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}