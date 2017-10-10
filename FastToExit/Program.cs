﻿using System;

//Lab 4 by Johan Lång och Anders Eriksson,  Göteborg 171010

namespace FastToExit
{
    public enum SquareType { Player = '@', Monster = 'M', Exit = 'E', Empty = '-', Wall = '#', Door = 'D', DoorKey = 'k', Sword = 's' };

    class Program
    {
        static void Main(string[] args)
        {

            const int ROWS = 16, COLUMNS = 24;

            Square[,] map = new Square[ROWS, COLUMNS];

            //int playerRow = 3, playerColumn = 5;

            #region Skapa kartan

            //Skapa kartan

            Player player = new Player(3, 5);

            Player.Steps = 0;
            Player.Score = 10000;
            string message = "";

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    //Obs använd oject istället i lab 4

                    if (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1)
                        map[row, column] = new Wall();

                    else if (row == 3 && column == 13 || row == 4 && column == 13)
                        map[row, column] = new Door();

                    else if (row == 4 && column == 7)
                        map[row, column] = new DoorKey();

                    else if (row == 1 && column == 20)
                        map[row, column] = new Exit();

                    else if (row == 1 && column == 7)
                        map[row, column] = new Monster();

                    else if (row == 10 && column == 2)
                        map[row, column] = new Sword();

                    else if (row == 3 && column >= 7)
                        map[row, column] = new Wall();

                    else

                        map[row, column] = new Room();
                }

            }

            #endregion

            #region Rita kartan
            //Rita ut kartan
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"**************** The Fast To Exit Game ******************");
                Console.WriteLine();


                string buffer = "";


                for (int row = 0; row < ROWS; row++)
                {
                    string line = "";

                    for (int column = 0; column < COLUMNS; column++)
                    {


                        if (row == player.Xpos && column == player.Ypos)
                        {
                            //Console.SetCursorPosition(column, row);
                            //Console.Write(player.Print());
                            line += player.Print();
                        }
                        else
                        {
                            //Console.SetCursorPosition(column, row);
                            //Console.Write(map[row, column].Print());
                            line += map[row, column].Print();
                        }
                    }

                    buffer += line + "\n";
                }


                Console.Write(buffer);

                Console.SetCursorPosition(0, 2); //0 är left och 2 är top 
                Console.SetCursorPosition(0, Console.WindowHeight - 10);
                Console.WriteLine($"Use Key: S - Left, W - Up, D - Right, S - Down");
                Console.WriteLine();

                Console.WriteLine($"Position(Row, Column): {player.Xpos}, {player.Ypos}");

                Console.WriteLine($"Steps: {Player.Steps}, Key: {Player.DoorKey}, Sword: {Player.Sword}, Score: {Player.Score}");
                Console.WriteLine($"Message: {message}");

                #endregion

                var key = Console.ReadKey();

                #region uppåt
                //Uppåt
                if (key.Key == ConsoleKey.W)
                {
                    message = "";

                    if (map[player.Xpos - 1, player.Ypos] is Wall)
                    { }

                    else if (map[player.Xpos - 1, player.Ypos] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        player.Xpos--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos - 1, player.Ypos] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        player.Xpos--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos - 1, player.Ypos] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            player.Xpos--;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[player.Xpos - 1, player.Ypos] is Monster)
                    {
                        if (Player.Sword == false)
                        {
                            message = Monster.Message(false);
                            Player.Score -= 1000;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }

                        else
                        {
                            message = Monster.Message(true);
                            player.Xpos--;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[player.Xpos - 1, player.Ypos] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Xpos--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        player.Xpos--;
                        Player.Steps++;
                        Player.Score -= 100;
                        if (Player.Score < 0)
                            Player.Score = 0;
                    }
                }
                #endregion

                #region Nedåt
                //Nedåt
                if (key.Key == ConsoleKey.S)
                {
                    message = "";

                    if (map[player.Xpos + 1, player.Ypos] is Wall)
                    { }

                    else if (map[player.Xpos + 1, player.Ypos] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        player.Xpos++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos + 1, player.Ypos] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        player.Xpos++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos + 1, player.Ypos] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            player.Xpos++;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[player.Xpos + 1, player.Ypos] is Monster)
                    {
                        if (Player.Sword == false)
                        {
                            message = Monster.Message(false);
                            Player.Score -= 1000;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }

                        else
                        {
                            message = Monster.Message(true);
                            player.Xpos++;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[player.Xpos + 1, player.Ypos] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Xpos++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        player.Xpos++;
                        Player.Steps++;
                        Player.Score -= 100;
                        if (Player.Score < 0)
                            Player.Score = 0;
                    }
                }

                #endregion

                #region vänster

                // Vänster
                else if (key.Key == ConsoleKey.A)
                {
                    message = "";

                    if (map[player.Xpos, player.Ypos - 1] is Wall)
                    { }

                    else if (map[player.Xpos, player.Ypos - 1] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        player.Ypos--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos, player.Ypos - 1] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        player.Ypos--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos, player.Ypos - 1] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            player.Ypos--;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[player.Xpos, player.Ypos - 1] is Monster)
                    {
                        if (Player.Sword == false)
                        {
                            message = Monster.Message(false);
                            Player.Score -= 1000;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }

                        else
                        {
                            message = Monster.Message(true);
                            player.Ypos--;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[player.Xpos, player.Ypos - 1] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Ypos--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        player.Ypos--;
                        Player.Steps++;
                        Player.Score -= 100;
                        if (Player.Score < 0)
                            Player.Score = 0;
                    }
                }
                #endregion

                #region Höger
                // Höger
                else if (key.Key == ConsoleKey.D)
                {
                    message = "";

                    if (map[player.Xpos, player.Ypos + 1] is Wall)
                    { }

                    else if (map[player.Xpos, player.Ypos + 1] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        player.Ypos++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos, player.Ypos + 1] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        player.Ypos++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[player.Xpos, player.Ypos + 1] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            player.Ypos++;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[player.Xpos, player.Ypos + 1] is Monster)
                    {
                        if (Player.Sword == false)
                        {
                            message = Monster.Message(false);
                            Player.Score -= 1000;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }

                        else
                        {
                            message = Monster.Message(true);
                            player.Ypos++;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[player.Xpos, player.Ypos + 1] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Ypos++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        player.Ypos++;
                        Player.Steps++;
                        Player.Score -= 100;
                        if (Player.Score < 0)
                            Player.Score = 0;
                    }
                }
                #endregion
            }
        }

    }
}
