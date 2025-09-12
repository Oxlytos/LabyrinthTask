using System.Drawing;

namespace LabyrinthTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerX = 1;
            int playerY = 1;
            int playerScore = 0;
            //Manipulate the cursor for playerPosition
            Console.CursorVisible = false;

            //Intro information
            Console.WriteLine("Choose an int for the size of the labyrinth:");

                
            int size = 0;
            string userLabInput = Console.ReadLine();
            if (!Int32.TryParse(userLabInput, out size))
            {
                size = 5;
                Console.WriteLine("Wrong, now using 5 as defualt");
            }

            Random random = new Random();
            int treasureX = random.Next(1, (size * 4) - 2); //X position within bounds
            int treasureY = random.Next(1, (size * 4) - 2); //Y position within bounds

           

            //Play and loop until we quit the application
            while (true) 
            {

                //Clear console
                Console.Clear();
                //Redraw labyrinth
                DrawLabyrinth(size);

                //Draw treasure at this position
                Console.SetCursorPosition(treasureX, treasureY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("£"); //Pound sign for treasure


                //SetCursor aka the player at this position
                //Cursor aka the typ:e that blinks ya know
                Console.SetCursorPosition(playerX, playerY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("P"); //P for player

                //User key input, switch case for specific keys
                ConsoleKey key = Console.ReadKey(true).Key;

                //Move Cursor to old position and clear it
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(" "); 


                //Depending on the keypress
                switch (key)
                {
                    //Player controls
                    //Up
                    case ConsoleKey.W:
                        if (playerY > 1) playerY--; //Negative value => Move up to previous line left or right
                        break;

                    //To the left
                    case ConsoleKey.A:
                        if(playerX > 1) playerX--;
                        break;

                    //Down
                    case ConsoleKey.S:
                        if (playerY < (size * 4)-1) playerY++; //Limit to the size of the labyrinth
                        break;                                   //4 is the height of a grid, -1 to avoid the last line
                    //To the right
                    case ConsoleKey.D:
                        if (playerX < (size * 4)-1) playerX++;
                        break;

                    //Adjust size
                    case ConsoleKey.X:
                        size++;
                        break;
                    case ConsoleKey.Z:
                        size--;
                        break;

                }

                if(playerX == treasureX && playerY == treasureY)
                {
                    Console.WriteLine("You found the treasure!");

                    //New position for da treasure
                    treasureX = random.Next(1, (size * 4) - 2); //X position within bounds
                    treasureY = random.Next(1, (size * 4) - 2); //Y position within bounds

                    //Increase the very important player score
                    playerScore++;
                }

            }

           void DrawLabyrinth(int size)
           {
                string symbolForRoof = "X";
                string symbolForPillar = "X";
                //Draw along the X axis
                for (int row = 0; row < size; row++)
                {       //Top Part
                    for (int col = 0; col < size; col++)
                    {
                        /*
                         * We generate 5 parts at the start, then 4 after the first iteration
                         * Otherwise we get a "spillover" of to many extra roof parts, has to do with the offset
                         */
                        if (col > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");

                        }
                    }
                    //Change line after loop is done
                    Console.WriteLine();


                    //Y Axis part that uses WriteLine
                    //Handles the height of a grid, left and right
                    for (int innerWall = 0; innerWall < 3; innerWall++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{symbolForPillar}   ");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{symbolForPillar}");
                    }

                //Bottom part of the wholass graphic
                //Like the roof, outside its loop in this case
                }
                for (int col = 0; col < size; col++)
                {
                    if (col > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");

                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nPlayer Score: {playerScore}"); 
                //Old method of increasing the size of the grid
                //   Console.SetCursorPosition(playerX, playerY);
                //   Console.Write("P");

                // Console.WriteLine("\nWrite 'x' to increase size, 'z' to decrease, or leave blank to reset");
                //string userInputChangeSize = Console.ReadLine();
                //  Console.Clear();

                /*
                if (userInputChangeSize.ToLower().Contains("x"))
                {
                    DrawLabyrinth(playerX, playerY, size + 1);
                }
                else if (userInputChangeSize.ToLower().Contains("z"))
                {
                    DrawLabyrinth(playerX, playerY, size -1);
                }*/



            }



        }
    }
}
