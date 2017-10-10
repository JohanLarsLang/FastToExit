using System;

//Lab 4 by Johan Lång och Anders Eriksson,  Göteborg 171010

namespace FastToExit
{
    public enum SquareType { Player = '@', Monster = 'M', Exit = 'E', Empty = '-', Wall = '#', Door = 'D', DoorKey = 'k', SuperKey = 'k', Sword = 's' };

    class Program
    {

        static void Main(string[] args)
        {

            const int ROWS = 16, COLUMNS = 24;

            Square[,] map = new Square[ROWS, COLUMNS];

            #region Skapa kartan

            //Skapa kartan

            Player player = new Player(14, 5);

            Player.Steps = 0;
            Player.Score = 10000;
            string message = "";
            string messageE = "";
            string command = "";
            Player.Exit = false;

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    // Spelplan
                    if (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1 || row == 12 && column > 18 || row == 2 && column == 18)
                        map[row, column] = new Wall();

                    else if (row == 3 && column == 13 || row == 8 && column == 13 || row == 1 && column == 19 || row == 13 && column == 22)
                        map[row, column] = new Door();

                    else if (row == 4 && column == 7 || row == 10 && column == 2)
                        map[row, column] = new DoorKey();

                    else if (row == 14 && column == 22)
                        map[row, column] = new SuperKey();

                    else if (row == 1 && column == 20)
                        map[row, column] = new Exit();

                    else if (row == 1 && column == 18 || row == 8 && column == 21 || row == 14 && column == 20)
                        map[row, column] = new Monster();

                    else if (row == 8 && column == 22)
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
                // Console.WriteLine();
                Console.WriteLine("Use these keys to navigate:");
                Console.WriteLine();
                Console.WriteLine($"\tw - Up");
                Console.WriteLine("a - Left\td - Right");
                Console.WriteLine("\ts - Down\n");
                Console.WriteLine("q - Quit the game, p - play again (after enter Exit)\n");

                Console.WriteLine($"Position(Row, Column): {player.Xpos}, {player.Ypos}");

                Console.WriteLine($"Steps: {Player.Steps}, Key: {Player.DoorKey}, , SuperKey: {Player.SuperKey}, Sword: {Player.Sword}, Score: {Player.Score}");
                Console.WriteLine($"Message: {message}");
                Console.WriteLine($"Message: {messageE}");
                Console.Write($"Command: {command}");

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

                    else if (map[player.Xpos - 1, player.Ypos] is SuperKey)
                    {
                        message = SuperKey.Message(true);
                        Player.SuperKey = true;
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
                        if (Player.SuperKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Xpos--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)} You got: { Player.Steps} steps and {Player.Score} points!";
                            messageE = "Type: q  to quit or type: p  to play again";
                            Player.Exit = true;
                            Player.SuperKey = false;
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

                    else if (map[player.Xpos + 1, player.Ypos] is SuperKey)
                    {
                        message = SuperKey.Message(true);
                        Player.SuperKey = true;
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
                        if (Player.SuperKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Xpos++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)} You got: { Player.Steps} steps and {Player.Score} points!";
                            Player.SuperKey = false;
                            Player.Exit = true;
                            messageE = "Type: q  to quit or type: p  to play again";
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

                    else if (map[player.Xpos, player.Ypos - 1] is SuperKey)
                    {
                        message = SuperKey.Message(true);
                        Player.SuperKey = true;
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
                        if (Player.SuperKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Ypos--;
                            Player.Steps++;
                            message = $"{Exit.Message(true)} You got: { Player.Steps} steps and {Player.Score} points!";
                            Player.SuperKey = false;
                            Player.Exit = true;
                            messageE = "Type: q  to quit or type: p  to play again";
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

                    else if (map[player.Xpos, player.Ypos + 1] is SuperKey)
                    {
                        message = SuperKey.Message(true);
                        Player.SuperKey = true;
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
                        if (Player.SuperKey == false)
                        {
                            message = Exit.Message(false);
                        }

                        else
                        {
                            player.Ypos++;
                            Player.Steps++;
                            message = $"{Exit.Message(true)} You got: { Player.Steps} steps and {Player.Score} points!";
                            Player.SuperKey = false;
                            Player.Exit = true;
                            messageE = "Type: q  to quit or type: p  to play again";
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

                #region Quit
                //Quit
                else if (key.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to play again! \n Thank you! \n");
                    Console.WriteLine();
                    Console.WriteLine("Are you sure you want to quit the game?");
                    Console.Write("Select Y or y to quit the game or any key to continue: ");

                    string quitSelection = Console.ReadLine();

                    if (quitSelection == "Y" || quitSelection == "y")
                        return;

                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
                #endregion

                #region Play again

                else if (key.Key == ConsoleKey.P)
                {
                    if (Player.Exit == true)
                    {
                        Console.Clear();
                        message = "";
                        messageE = "";
                        command = "";
                        Player.Score = 0;
                        Player.Steps = 0;

                        player.Xpos = 14;
                        player.Ypos = 5;

                    }
                    else
                    {
                        message = "";
                        messageE = "You need to success to go to Exit before play again";

                    }
                }
            }
            #endregion
        }

    }
}
