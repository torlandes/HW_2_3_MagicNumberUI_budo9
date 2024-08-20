using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbersUI : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    [SerializeField] private TMP_Text _answerLabel;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _guessButton;
    [SerializeField] private Button _downButton;
    [Header("Range Numbers")]
    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min;
    private int _currentMax;
    private int _currentMin;

    #endregion

    #region Properties

    public static int Guess { get; private set; }
    public static int Step { get; private set; }

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Step = 1;
        _currentMin = _min;
        _currentMax = _max;
        _upButton.onClick.AddListener(PressUp);
        _downButton.onClick.AddListener(PressDown);
        _guessButton.onClick.AddListener(PressGuess);
        StartGame();
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        Guess = (_max + _min) / 2;
        _answerLabel.text = $"Your number is {Guess}? Step: {Step}";
    }

    private void PressDown()
    {
        Step++;
        _max = Guess;
        CalculateGuessAndLog();
    }

    private void PressGuess()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void PressUp()
    {
        Step++;
        _min = Guess;
        CalculateGuessAndLog();
    }

    private void StartGame()
    {
        Step = 1;
        Guess = 0;
        _min = _currentMin;
        _max = _currentMax;
        _answerLabel.text = $"Guess number from {_currentMin} to {_currentMax}";
        CalculateGuessAndLog();
    }

    #endregion
}