using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class minite
    {
        static void Main()
        {
            const int MaxPoints = 35;

            string currentCommand = string.Empty;

            char[,] gameField = GenerateGameField();
            char[,] bombPositions = GenerateBombs();

            int scoreCounter = 0;
            bool bombTriggered = false;
            List<PlayerScore> players = new List<PlayerScore>(6);

            int currentRow = 0;
            int currentCol = 0;
            bool gameStart = true;
            bool gameEnd = false;

            do
            {
                if (gameStart)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try to find all fields without bombs." +
                                      " 'Top' shows player ranking, 'restart' starts a new game, 'exit' quits the game!");
                    SetGameField(gameField);
                    gameStart = false;
                }

                Console.Write("Input row and column: ");
                currentCommand = Console.ReadLine().Trim();
                if (currentCommand.Length >= 3)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out currentRow) &&
                        int.TryParse(currentCommand[2].ToString(), out currentCol) &&
                        currentRow <= gameField.GetLength(0) && currentCol <= gameField.GetLength(1))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        PrintScoreList(players);
                        break;
                    case "restart":
                        gameField = GenerateGameField();
                        bombPositions = GenerateBombs();
                        SetGameField(gameField);
                        bombTriggered = false;
                        gameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Byebye!");
                        break;
                    case "turn":
                        if (bombPositions[currentRow, currentCol] != '*')
                        {
                            if (bombPositions[currentRow, currentCol] == '-')
                            {
                                ExecuteTurn(gameField, bombPositions, currentRow, currentCol);
                                scoreCounter++;
                            }

                            if (MaxPoints == scoreCounter)
                            {
                                gameEnd = true;
                            }
                            else
                            {
                                SetGameField(gameField);
                            }
                        }
                        else
                        {
                            bombTriggered = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvallid command parsed!\n");
                        break;
                }

                if (bombTriggered)
                {
                    SetGameField(bombPositions);
                    Console.Write("\nHrrrrrr! Game over! Your scoe: {0} points. " +
                                  "Input your name: ", scoreCounter);
                    string playerName = Console.ReadLine();
                    PlayerScore currentPlayer = new PlayerScore(playerName, scoreCounter);

                    if (players.Count < 5)
                    {
                        players.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].PlayerScorePoints < currentPlayer.PlayerScorePoints)
                            {
                                players.Insert(i, currentPlayer);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((PlayerScore r1, PlayerScore r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    players.Sort((PlayerScore r1, PlayerScore r2) => r2.PlayerScorePoints.CompareTo(r1.PlayerScorePoints));
                    PrintScoreList(players);

                    gameField = GenerateGameField();
                    bombPositions = GenerateBombs();
                    scoreCounter = 0;
                    bombTriggered = false;
                    gameStart = true;
                }

                if (gameEnd)
                {
                    Console.WriteLine("\nWell done! You found all 35 fields without triggering a bomb.");

                    SetGameField(bombPositions);
                    Console.WriteLine("Input your name: ");
                    string playerName = Console.ReadLine();

                    PlayerScore currentPlayer = new PlayerScore(playerName, scoreCounter);
                    players.Add(currentPlayer);
                    PrintScoreList(players);

                    gameField = GenerateGameField();
                    bombPositions = GenerateBombs();
                    scoreCounter = 0;
                    gameEnd = false;
                    gameStart = true;
                }
            }
            while (currentCommand != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void PrintScoreList(List<PlayerScore> scoreList)
        {
            Console.WriteLine("\nScore:");
            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields",
                        i + 1, scoreList[i].PlayerName, scoreList[i].PlayerScorePoints);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scorelist!\n");
            }
        }

        private static void ExecuteTurn(char[,] field,
            char[,] bombPlacement, int row, int col)
        {
            char bombCount = GetBombSize(bombPlacement, row, col);
            bombPlacement[row, col] = bombCount;
            field[row, col] = bombCount;
        }

        private static void SetGameField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombs()
        {
            const int MaxBombsCount = 15;
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombsList = new List<int>();
            while (bombsList.Count < MaxBombsCount)
            {
                Random random = new Random();
                int randomPosition = random.Next(50);
                if (!bombsList.Contains(randomPosition))
                {
                    bombsList.Add(randomPosition);
                }
            }

            foreach (int bomb in bombsList)
            {
                int currentColumns = (bomb / columns);
                int currentRow = (bomb % columns);

                if (currentRow == 0 && bomb != 0)
                {
                    currentColumns--;
                    currentRow = columns;
                }
                else
                {
                    currentRow++;
                }

                gameField[currentColumns, currentRow - 1] = '*';
            }

            return gameField;
        }

        private static void smetki(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (gameField[i, j] != '*')
                    {
                        char bombSize = GetBombSize(gameField, i, j);
                        gameField[i, j] = bombSize;
                    }
                }
            }
        }

        private static char GetBombSize(char[,] gameField, int currentRows, int currentCols)
        {
            int bombCounter = 0;
            int maxRows = gameField.GetLength(0);
            int maxCols = gameField.GetLength(1);

            if (currentRows - 1 >= 0)
            {
                if (gameField[currentRows - 1, currentCols] == '*')
                { 
                    bombCounter++; 
                }
            }

            if (currentRows + 1 < maxRows)
            {
                if (gameField[currentRows + 1, currentCols] == '*')
                { 
                    bombCounter++; 
                }
            }

            if (currentCols - 1 >= 0)
            {
                if (gameField[currentRows, currentCols - 1] == '*')
                { 
                    bombCounter++;
                }
            }

            if (currentCols + 1 < maxCols)
            {
                if (gameField[currentRows, currentCols + 1] == '*')
                { 
                    bombCounter++;
                }
            }

            if ((currentRows - 1 >= 0) && (currentCols - 1 >= 0))
            {
                if (gameField[currentRows - 1, currentCols - 1] == '*')
                { 
                    bombCounter++; 
                }
            }

            if ((currentRows - 1 >= 0) && (currentCols + 1 < maxCols))
            {
                if (gameField[currentRows - 1, currentCols + 1] == '*')
                { 
                    bombCounter++; 
                }
            }

            if ((currentRows + 1 < maxRows) && (currentCols - 1 >= 0))
            {
                if (gameField[currentRows + 1, currentCols - 1] == '*')
                { 
                    bombCounter++; 
                }
            }

            if ((currentRows + 1 < maxRows) && (currentCols + 1 < maxCols))
            {
                if (gameField[currentRows + 1, currentCols + 1] == '*')
                { 
                    bombCounter++; 
                }
            }

            return char.Parse(bombCounter.ToString());
        }
    }
}