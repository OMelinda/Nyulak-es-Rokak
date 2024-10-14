

public class Simulation
{
    public Grid Grid { get; private set; }
    public int Turns { get; private set; }

    public Simulation(int width, int height)
    {
        Grid = new Grid(width, height);
        Turns = 0;
    }

    public void RunTurn()
    {
        // Grass grows
        foreach (var cell in Grid.Cells)
        {
            if (cell.Rabbit == null)
            {
                cell.Grass.Grow();
            }
        }

        // Process rabbits
        foreach (var cell in Grid.Cells)
        {
            if (cell.Rabbit != null)
            {
                cell.Rabbit.Starve();
                if (cell.Rabbit.IsDead())
                {
                    cell.Rabbit = null;  // Nyúl elpusztul
                }
                else
                {
                    cell.Rabbit.Eat(cell.Grass);  // Nyúl legel
                    // Nyúl mozgása
                    // Szaporodás, ha van hely és másik nyúl közelben
                }
            }
        }

        // Process foxes
        foreach (var cell in Grid.Cells)
        {
            if (cell.Fox != null)
            {
                cell.Fox.Starve();
                if (cell.Fox.IsDead())
                {
                    cell.Fox = null;  // Róka elpusztul
                }
                else
                {
                    // Róka táplálkozása és mozgása
                }
            }
        }

        Turns++;
    }
}