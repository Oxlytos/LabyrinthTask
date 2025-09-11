using System.Drawing;

namespace LabyrinthTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while (true)
           {
                Console.WriteLine("Choose an int for the size of the labyrinth:");
               
                int size = 0;
                string userLabInput = Console.ReadLine();
                if (!Int32.TryParse(userLabInput, out size))
                {
                    Console.WriteLine("Wrong");
                }
                else
                {
                    DrawLabyrinth(size);
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
                            Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");
                        }
                        else
                        {
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
                            Console.Write($"{symbolForPillar}   ");
                        }
                        Console.WriteLine($"{symbolForPillar}");
                    }

                //Bottom part of the wholass graphic
                //Like the roof, outside its loop in this case
                }
                for (int col = 0; col < size; col++)
                {
                    if (col > 0)
                    {
                        Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");
                    }
                    else
                    {
                        Console.Write($"{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}{symbolForRoof}");

                    }
                }
                Console.WriteLine("\nWrite 'x' to increase size, 'z' to decrease, or leave blank to reset");
                string userInputChangeSize = Console.ReadLine();
                Console.Clear();

                if (userInputChangeSize.ToLower().Contains("x"))
                {
                    DrawLabyrinth(size + 1);
                }
                else if (userInputChangeSize.ToLower().Contains("z"))
                {
                    DrawLabyrinth(size -1);
                }

                i

               
           }



        }
    }
}
