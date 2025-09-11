namespace LabyrinthTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an int for the size of the labyrint:");
            string symbolForRoof = "Ö";
            string symbolForPillar = "X";
            int size = 0;
            string userLabInput = Console.ReadLine();
            if(!Int32.TryParse(userLabInput, out size))
            {
                Console.WriteLine("Wrong");
            }
            else
            {
                
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

                //Bottom part of the wholess graphic
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
                Console.WriteLine();








                //Huvudet
                /*
                Console.Write($"XXXXX\n");
                Console.WriteLine($"X   X");
                Console.WriteLine($"X   X");
                Console.WriteLine($"X   X");
                Console.Write($"XXXXX\n");*/







            }
                
            
        }
    }
}
