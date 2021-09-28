using Microsoft.AspNetCore.Components;
using TicTacToe.Helper;

namespace TicTacToe.Shared
{
    public partial class Board : ComponentBase
    {
        private bool xIsNext;
        private char[] values = new char[9];

        private void InitState()
        {
            values = new char[9]
            {
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '
            };
            xIsNext = true;
        }

        protected override void OnInitialized()
        {
            InitState();
        }

        private void PlayAgainHandler()
        {
            InitState();
        }

        private void HandleClick(int i)
        {
            if (values[i] != ' ')
            {
                return;
            }

            bool isGameFinished = Helper.Helper.CalculateGameStatus(values) != GameStatus.NotYetFinished;

            if (isGameFinished)
            {
                return;
            }
        
            bool xToPlay = xIsNext;
            values[i] = xToPlay ? 'X' : 'O';
            xIsNext = !xToPlay;
        }

        private string PrintStatus()
        {
            var gameStatus = Helper.Helper.CalculateGameStatus(values);

            if (gameStatus == GameStatus.X_wins)
            {
                return "Winner: X";
            }

            if (gameStatus == GameStatus.O_wins)
            {
                return "Winner: O";
            }

            if (gameStatus == GameStatus.Draw)
            {
                return "Draw !";
            }

            char nextPlayer = xIsNext ? 'X' : 'O';
            return $"Next player: {nextPlayer}";
        }
    }
}