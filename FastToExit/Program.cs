using System;

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

            int playerRow = 14, playerColumn = 5;

            #region Skapa kartan

            //Skapa kartan

            Player.Steps = 0;
            Player.Score = 10000;
            string message = "";

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    // Spelplan
                    if (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1)
                        map[row, column] = new Wall();

                    else if (row == 3 && column == 13 || row == 8 && column == 13)
                        map[row, column] = new Door();

                    else if (row == 4 && column == 7)
                        map[row, column] = new DoorKey();

                    else if (row == 1 && column == 20)
                        map[row, column] = new Exit();

                    else if (row == 1 && column == 7 || row == 8 && column == 21)
                        map[row, column] = new Monster();

                    else if (row == 10 && column == 2 || row == 8 && column == 22)
                        map[row, column] = new Sword();

                    else if (row == 3 && column >= 2 || row == 8 && column <= 20 || row == 12 && column >= 12)
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
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine($"The Fast To Exit Game");


                string buffer = "";


                for (int row = 0; row < ROWS; row++)
                {
                    string line = "";

                    for (int column = 0; column < COLUMNS; column++)
                    {
                        if (row == playerRow && column == playerColumn)
                            //map[row, column] = '@';
                            line += '@';


                        else
                            line += map[row, column].Print();
                        //Console.Write(map[row, column]);
                    }
                    //Console.WriteLine(line);
                    buffer += line + "\n";

                }


                Console.Write(buffer);
                Console.WriteLine();
                Console.WriteLine("Use these keys to navigate:");
                Console.WriteLine();
                Console.WriteLine($"\tw - Up");
                Console.WriteLine("a - Left\td - Right");
                Console.WriteLine("\ts - Down");
                Console.WriteLine();

                Console.WriteLine($"Position(Row, Column): {playerRow}, {playerColumn}");

                Console.WriteLine($"Steps: {Player.Steps}, Key: {Player.DoorKey}, Sword: {Player.Sword}, Score: {Player.Score}");
                Console.WriteLine($"Message: {message}");

                #endregion

                var key = Console.ReadKey();

                #region uppåt
                //Uppåt
                if (key.Key == ConsoleKey.W)
                {
                    message = "";

                    if (map[playerRow - 1, playerColumn] is Wall)
                    { }

                    else if (map[playerRow - 1, playerColumn] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        playerRow--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow - 1, playerColumn] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        playerRow--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow - 1, playerColumn] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            playerRow--;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[playerRow - 1, playerColumn] is Monster)
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
                            playerRow--;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[playerRow - 1, playerColumn] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            playerRow--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        playerRow--;
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

                    if (map[playerRow + 1, playerColumn] is Wall)
                    { }

                    else if (map[playerRow + 1, playerColumn] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        playerRow++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow + 1, playerColumn] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        playerRow++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow + 1, playerColumn] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            playerRow++;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[playerRow + 1, playerColumn] is Monster)
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
                            playerRow++;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[playerRow + 1, playerColumn] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            playerRow++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        playerRow++;
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

                    if (map[playerRow, playerColumn - 1] is Wall)
                    { }

                    else if (map[playerRow, playerColumn - 1] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        playerColumn--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow, playerColumn - 1] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        playerColumn--;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow, playerColumn - 1] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            playerColumn--;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[playerRow, playerColumn - 1] is Monster)
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
                            playerColumn--;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[playerRow, playerColumn - 1] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            playerColumn--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        playerColumn--;
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

                    if (map[playerRow, playerColumn + 1] is Wall)
                    { }

                    else if (map[playerRow, playerColumn + 1] is DoorKey)
                    {
                        message = DoorKey.Message(true);
                        Player.DoorKey = true;
                        playerColumn++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow, playerColumn + 1] is Sword)
                    {
                        message = Sword.Message(true);
                        Player.Sword = true;
                        playerColumn++;
                        Player.Score += 1000;
                        Player.Steps++;
                    }

                    else if (map[playerRow, playerColumn + 1] is Door)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Door.Message(false);
                        }

                        else
                        {
                            message = Door.Message(true);
                            playerColumn++;
                            Player.Steps++;
                            Player.DoorKey = false;
                            Player.Score -= 100;
                            if (Player.Score < 0)
                                Player.Score = 0;
                        }
                    }

                    else if (map[playerRow, playerColumn + 1] is Monster)
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
                            playerColumn++;
                            Player.Steps++;
                            Player.Sword = false;
                            Player.Score += 1000;
                        }
                    }

                    else if (map[playerRow, playerColumn + 1] is Exit)
                    {
                        if (Player.DoorKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            playerColumn++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)}  by { Player.Steps} steps and you got {Player.Score} points!";
                            Player.DoorKey = false;
                        }
                    }

                    else
                    {
                        playerColumn++;
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
