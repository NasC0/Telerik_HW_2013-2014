using System;
using System.Threading;
using System.Collections.Generic;

namespace _11.FallingRocks
{
    class FallingRocks
    {
        // for game objects printing
        static void PrintOnField(int col, int row, char sign,
            ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(sign);
        }

        // for score printing
        static void PrintStringOnField(int col, int row, string str,
            ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        static void Main()
        {
            // player playing field dimensions
            int playFieldWidth = 30;
            int playFieldHeight = 20;

            // dwarf creation
            Dwarf dwarf = new Dwarf(playFieldHeight - 1, playFieldWidth / 2, ConsoleColor.Yellow, '0');

            // for random color generation
            ConsoleColor[] randomColor = new ConsoleColor[5];
            randomColor[0] = ConsoleColor.Green;
            randomColor[1] = ConsoleColor.Magenta;
            randomColor[2] = ConsoleColor.Cyan;
            randomColor[3] = ConsoleColor.Blue;
            randomColor[4] = ConsoleColor.White;

            // for random char generation
            char[] randomChar = new char[11];
            randomChar[0] = '^';
            randomChar[1] = '@';
            randomChar[2] = '*';
            randomChar[3] = '&';
            randomChar[4] = '+';
            randomChar[5] = '%';
            randomChar[6] = '$';
            randomChar[7] = '#';
            randomChar[8] = '!';
            randomChar[9] = '.';
            randomChar[10] = ';';

            // random numbers generator
            Random randomGenerator = new Random();

            // rocks
            List<GameObject> rocks = new List<GameObject>();


            // game field and cursor visibility
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 60;
            int gameFieldBoundaries = playFieldWidth + 1;

            // game end conditions, speed and score
            int lives = 3;
            double sleepTime = 0.5;
            double speed = 150;
            int score = 0;

            // Game Rules
            PrintStringOnField(0, 0, "Welcome to the game Falling Rocks!", ConsoleColor.White);
            PrintStringOnField(0, 1, "You are a brave dwarf who is facing a rock-hurling troll!", ConsoleColor.White);
            PrintStringOnField(0, 2, "For each rock you avoid you gain 10 points.", ConsoleColor.White);
            PrintStringOnField(0, 3, "You lose 50 points and 1 life for each rock that hits you!", ConsoleColor.White);
            PrintStringOnField(0, 4, "The game speed increases over time.", ConsoleColor.White);
            PrintStringOnField(0, 5, "Good Luck!!!", ConsoleColor.White);
            PrintStringOnField(0, 6, "To start the game press \"y\", to exit press \"n\"", ConsoleColor.Green);
            Console.SetCursorPosition(0, 7);
            ConsoleKeyInfo yesOrNo = Console.ReadKey(true);
            if (yesOrNo.Key == ConsoleKey.Y)
            // game start
            {
                while (true)
                {
                    // game speed;
                    if (speed < 425)
                    {
                        speed += sleepTime;
                    }

                    // hit flag
                    bool hit = false;

                    // Randomly create rocks
                    // Maximum of 5 rocks per row
                    // Create List newRocks, which holds the newly created rocks
                    // And checks if they are not already created
                    // Without this, the game sometimes creates two rocks at the same position
                    // Which translates to two lives taken if the player is hit
                    List<GameObject> newRocks = new List<GameObject>();
                    for (int i = 0; i < randomGenerator.Next(0, 5); i++)
                    {
                        GameObject newRock = new GameObject(
                            0,
                            randomGenerator.Next(0, playFieldWidth),
                            randomColor[randomGenerator.Next(0, 4)],
                            randomChar[randomGenerator.Next(0, 10)]);

                        bool exists = false;

                        // Checks all rocks in the newRock list for duplicates
                        foreach (var rock in newRocks)
                        {
                            if (newRock.row == rock.row && newRock.col == rock.col)
                            {
                                exists = true;
                            }
                        }
                        // If there aren't any duplicates, add the rock to the newRock list
                        if (exists != true)
                        {
                            newRocks.Add(newRock);
                        }
                    }
                    // Append the newRocks list to all rocks
                    rocks.AddRange(newRocks);
                    // Move Dwarf
                    while (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                        }
                        if (pressedKey.Key == ConsoleKey.LeftArrow || pressedKey.Key == ConsoleKey.A)
                        {
                            if (dwarf.col - 1 > 0)
                            {
                                dwarf.col = dwarf.col - 1;
                                dwarf.colTwo = dwarf.colTwo - 1;
                                dwarf.colThree = dwarf.colThree - 1;
                            }
                        }
                        if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.D)
                        {
                            if (dwarf.colThree + 1 < playFieldWidth)
                            {
                                dwarf.col = dwarf.col + 1;
                                dwarf.colTwo = dwarf.colTwo + 1;
                                dwarf.colThree = dwarf.colThree + 1;
                            }
                        }
                    }

                    // Move Rocks
                    // @hits holds how many times the dwarf was hit. I.e. if there are two or more rocks "glued" together on a single row, count the hits
                    // and don't subtract more than 1 life
                    int hits = 0;
                    List<GameObject> newList = new List<GameObject>();
                    for (int i = 0; i < rocks.Count; i++)
                    {
                        GameObject oldRock = rocks[i];
                        GameObject newRock = new GameObject(oldRock.row + 1, oldRock.col, oldRock.color, oldRock.sign);
                        if (newRock.row == dwarf.row && (newRock.col == dwarf.col || newRock.col == dwarf.colTwo || newRock.col == dwarf.colThree)) // unit collision
                        {
                            hits++;
                            if (hits > 1)
                            {
                                continue;
                            }
                            hit = true;
                            lives -= 1;
                            if (lives <= 0)
                            {
                                PrintStringOnField(10, 9, "GAME OVER!", ConsoleColor.Red);
                                PrintStringOnField(6, 10, "Your score is: " + score, ConsoleColor.Red);
                                PrintStringOnField(5, 11, "Press [Enter] to exit", ConsoleColor.Red);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        if (newRock.row < playFieldHeight)
                        {
                            newList.Add(newRock);
                        }
                        else          // scoring system
                        {
                            score += 10;
                        }
                    }
                    rocks = newList;

                    // Clear the console
                    Console.Clear();

                    // ReDraw playfield

                    if (hit)
                    {
                        rocks.Clear();
                        if (score <= 50)
                        {
                            score = 0;
                        }
                        else
                        {
                            score -= 50;
                        }

                        PrintOnField(dwarf.col, dwarf.row, 'X', ConsoleColor.Red);
                        PrintOnField(dwarf.colTwo, dwarf.row, 'X', ConsoleColor.Red);
                        PrintOnField(dwarf.colThree, dwarf.row, 'X', ConsoleColor.Red);
                    }
                    else
                    {
                        dwarf.Print();
                    }

                    foreach (GameObject rock in rocks)
                    {
                        rock.Print();
                    }

                    for (int i = 0; i < playFieldHeight; i++)  // playfield boundaries
                    {
                        PrintOnField(playFieldWidth, i, '|', ConsoleColor.Gray);
                    }



                    // Print Score
                    PrintStringOnField(40, 9, "Lives: " + lives, ConsoleColor.White);
                    PrintStringOnField(40, 10, "Speed: " + speed, ConsoleColor.White);
                    PrintStringOnField(40, 11, "Score: " + score, ConsoleColor.White);

                    // Slow down the console
                    Thread.Sleep(500 - (int)speed);
                }
            }
            if (yesOrNo.Key == ConsoleKey.N)
                return;
            else
            {
                Main();
            }
        }
    }
}