namespace TicTacToe
{
    public class PlayCommand : ICommand
    {
        private readonly Cell _cell;
        private readonly string _mark;

        public PlayCommand(Cell cell,  string mark)
        {
            _cell = cell;
            _mark = mark;
        }

        public void Execute()
        {
            _cell.SetMark(_mark);
            GameEvents.MoveMade?.Invoke();
        }

        public void Undo()
        {
            _cell.Clear();
            GameEvents.Undo?.Invoke();
        }
    }
}