using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class ResultPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private Button _newGameButton;

        private void Awake()
        {
            _newGameButton.onClick.AddListener(NewGame);
            _root.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.ResultReady += OnResultReady;
            GameEvents.Undo += UndoGame;
        }

        private void OnDisable()
        {
            GameEvents.ResultReady -= OnResultReady;
            GameEvents.Undo -= UndoGame;
        }

        private void OnResultReady(string message)
        {
            _resultText.text = message;
            _root.SetActive(true);
        }

        private void NewGame()
        {
            _root.SetActive(false);
            GameEvents.StartNewGame?.Invoke();
        }

        private void UndoGame()
        {
            _root.SetActive(false);
        }
    }
}
