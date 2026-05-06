using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        private int _scoreX;
        private int _scoreO;
        private string _winner;

        private void OnEnable()
        {
            GameEvents.GameWon += OnGameWon;
            GameEvents.GameDrawn += OnGameDrawn;
            GameEvents.Undo += ReduceScore;
            GameEvents.StartNewGame += ResetWinner;
        }

        private void OnDisable()
        {
            GameEvents.GameWon -= OnGameWon;
            GameEvents.GameDrawn -= OnGameDrawn;
            GameEvents.Undo -= ReduceScore;
            GameEvents.StartNewGame -= ResetWinner;
        }

        private void Start()
        {
            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
            _winner = "";
        }

        private void OnGameWon(string winner)
        {
            _winner = winner;
            if (winner == "X")
            {
                _scoreX++;
            }
            else
            {
                _scoreO++;
            }

            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
            GameEvents.ResultReady?.Invoke($"{winner} wins!");
        }

        private void OnGameDrawn()
        {
            GameEvents.ResultReady?.Invoke("Draw!");
        }

        private void ReduceScore()
        {
            if (_winner == "X")
            {
                _scoreX--;
                GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
            } else if (_winner == "O")
            {
                _scoreO--;
                GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
            }
            _winner = "";
        }

        private void ResetWinner()
        {
            _winner = "";
        }
    }
}
