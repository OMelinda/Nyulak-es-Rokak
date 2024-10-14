
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Felhasználói bemenet a rács méreteinek és az entitások számának megadására
        Console.WriteLine("Add meg a rács oszlopainak számát:");
        int gridWidth = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a rács sorainak számát:");
        int gridHeight = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a nyulak számát:");
        int rabbitCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Add meg a rókák számát:");
        int foxCount = int.Parse(Console.ReadLine());

        // Szimuláció létrehozása a megadott méretű rácson
        Simulation simulation = new Simulation(gridWidth, gridHeight);

        // Nyulak és rókák véletlenszerű elhelyezése a rácson
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

        // Szimuláció futtatása 20 körön át
        for (int i = 0; i < 20; i++)
        {
            Console.Clear();
            Console.WriteLine($"Turn {i + 1}");
            DisplayGrid(simulation.Grid);
            simulation.RunTurn();
            Thread.Sleep(3000); // Egy másodperces szünet minden kör után
        }
    }

    // Rács megjelenítése a konzolon
    static void DisplayGrid(Grid grid)
    {
        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                var cell = grid.GetCell(x, y);

                if (cell.Rabbit != null)
                    Console.Write("R ");  // Nyúl
                else if (cell.Fox != null)
                    Console.Write("F ");  // Róka
                else if (cell.Grass.State == GrassState.Seedling)
                    Console.Write("# ");  // Fűkezdemény
                else if (cell.Grass.State == GrassState.Tender)
                    Console.Write("X ");  // Zsenge fű
                else if (cell.Grass.State == GrassState.FullGrown)
                    Console.Write("O ");  // Kifejlett fűcsomó
                else
                    Console.Write(" ");  // Üres cella
            }
            Console.WriteLine();
        }
    }
}
