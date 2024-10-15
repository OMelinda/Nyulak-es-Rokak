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
        
        foreach (var cell in Grid.Cells)
        {
            if (cell.Rabbit == null)
            {
                cell.Grass.Grow();
            }
        }

        
        foreach (var cell in Grid.Cells)
        {
            if (cell.Rabbit != null)
            {
                cell.Rabbit.Starve();
                if (cell.Rabbit.IsDead())
                {
                    cell.Rabbit = null;  
                }
                else
                {
                    cell.Rabbit.Eat(cell.Grass);  
                    cell.Rabbit.Move(Grid, cell);  

                    
                    if (cell.Rabbit != null)
                    {
                        cell.Rabbit.TryReproduce(Grid, cell);  
                    }
                }
            }
        }

        
        foreach (var cell in Grid.Cells)
        {
            if (cell.Fox != null)
            {
                cell.Fox.Starve();
                if (cell.Fox.IsDead())
                {
                    cell.Fox = null;  
                }
                else
                {
                    cell.Fox.Move(Grid, cell);  

                    
                    if (cell.Fox != null)
                    {
                        cell.Fox.TryReproduce(Grid, cell);  
                    }
                }
            }
        }

        Turns++;
    }
}
