using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal class Program
    {
        static char[,] board = new char[3, 3];

        static void Main(string[] args)
        {
            PlayGame();
        }
        static void InitializeBoard()
        {
            int num = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = num.ToString()[0];
                    num++;
                }
            }
        }

        static void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i, j]} ");
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("---|---|---");
            }
        }
        static void PlayerMove(char player)
        {
            int choice;
            while (true)
            {
                Console.WriteLine($"Player {player}, enter your move (1-9): ");
                choice = int.Parse(Console.ReadLine()) - 1;
                int row = choice / 3;
                int col = choice % 3;

                if (choice >= 0 && choice <= 8 && board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = player;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
        }
        static bool CheckWin(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                {
                    return true;
                }
            }

            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
            }

            return false;
        }
        static bool IsDraw()
        {
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O')
                {
                    return false;
                }
            }

            return true;
        }
        static void PlayGame()
        {
            char currentPlayer = 'X';
            InitializeBoard();

            while (true)
            {
                Console.Clear();
                DisplayBoard();
                PlayerMove(currentPlayer);

                if (CheckWin(currentPlayer))
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break;
                }

                if (IsDraw())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }

            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }

}
