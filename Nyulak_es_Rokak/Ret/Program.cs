using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Add meg a rács oszlopainak számát:");
        int gridWidth = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a rács sorainak számát:");
        int gridHeight = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a nyulak számát:");
        int rabbitCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a rókák számát:");
        int foxCount = int.Parse(Console.ReadLine());

        
        Simulation simulation = new Simulation(gridWidth, gridHeight);

        
        Random rand = new Random();
        for (int i = 0; i < rabbitCount; i++)
        {
            int x = rand.Next(0, gridWidth);
            int y = rand.Next(0, gridHeight);
            if (simulation.Grid.Cells[x, y].IsEmpty())
            {
                simulation.Grid.Cells[x, y].Rabbit = new Rabbit();
            }
        }

        for (int i = 0; i < foxCount; i++)
        {
            int x = rand.Next(0, gridWidth);
            int y = rand.Next(0, gridHeight);
            if (simulation.Grid.Cells[x, y].IsEmpty())
            {
                simulation.Grid.Cells[x, y].Fox = new Fox();
            }
        }

        
        for (int i = 0; i < 10; i++)
        {
            Console.Clear();
            Console.WriteLine($"{i + 1}. kör");
            DisplayGrid(simulation.Grid);
            simulation.RunTurn();
            Thread.Sleep(2000); 
        }
    }

    
    static void DisplayGrid(Grid grid)
    {
        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                var cell = grid.GetCell(x, y);

                if (cell.Rabbit != null)
                {
                    Console.Write("R ");  
                }
                else if (cell.Fox != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;  
                    Console.Write("F ");
                    Console.ResetColor();
                }
                else if (cell.Grass.State == GrassState.Seedling)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;  
                    Console.Write("# ");
                    Console.ResetColor();
                }
                else if (cell.Grass.State == GrassState.Tender)
                {
                    Console.ForegroundColor = ConsoleColor.Green;  
                    Console.Write("X ");
                    Console.ResetColor();
                }
                else if (cell.Grass.State == GrassState.FullGrown)
                {
                    Console.ForegroundColor = ConsoleColor.Green;  
                    Console.Write("O ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");  
                }
            }
            Console.WriteLine();
        }
    }
}
