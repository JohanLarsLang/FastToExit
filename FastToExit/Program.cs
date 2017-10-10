using System;

namespace FastToExit
{
    // Project started 171005
    // Testing new branch
    enum SquareType { Player = '@', Monster = 'M', Exit = 'E', Empty = ' ' };


    class Program
    {
        static void Main(string[] args)
        {

            const int ROWS = 16, COLUMNS = 24;

            char[,] map = new char[COLUMNS, ROWS];
            int playerRow = 3, playerColumn = 11;

            Wall wall = new Wall();
            char w = wall.PrintWall();

            //Skapa kartan
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    //Obs använd oject istället i lab 4

                    if (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1)
                        //map[column, row] = '#';
                        map[column, row] = w;


                    //map[column, row] = Wall.   '#';

                    //else if (row == playerRow && column == playerColumn)
                    //  map[column, row] = '@';
                    else

                        map[column, row] = '-';
                }
            }

            while (true)
            {
                Console.Clear();
                string buffer = "";

                //Rita ut kartan
                for (int row = 0; row < ROWS; row++)
                {
                    string line = "";
                    for (int column = 0; column < COLUMNS; column++)
                    {
                        if (row == playerRow && column == playerColumn)
                            //map[column, row] = '@';
                            line += '@';


                        else
                            line += map[column, row];
                        //Console.Write(map[column, row]);
                    }
                    //Console.WriteLine(line);
                    buffer += line + "\n";
                }

                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(buffer);

                var key = Console.ReadKey();

                //Uppåt
                if (key.Key == ConsoleKey.W)
                {
                    if (playerRow == 1)
                        playerRow = 1;

                    else
                        playerRow--;
                }

                //Nedåt
                if (key.Key == ConsoleKey.S)
                {
                    if (playerRow == ROWS - 2)
                        playerRow = ROWS - 2;

                    else
                        playerRow++;
                }

                // Vänster
                else if (key.Key == ConsoleKey.A)
                {
                    if (playerColumn == 1)
                        playerColumn = 1;

                    else
                        playerColumn--;
                }

                // Höger
                else if (key.Key == ConsoleKey.D)
                {
                    if (playerColumn == COLUMNS - 2)
                        playerColumn = COLUMNS - 2;

                    else
                        playerColumn++;
                }
            }
        }
    }
}
