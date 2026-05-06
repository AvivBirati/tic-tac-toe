using TicTacToe;
using UnityEngine;
using UnityEngine.UI;

public class UndoButton : MonoBehaviour
{
    [SerializeField] private Button undoButton;
    
    private void Awake()
    {
        undoButton.onClick.AddListener(Undo);
    }

    private void Undo()
    {
        GameEvents.UndoButtonPressed?.Invoke();
    }
}