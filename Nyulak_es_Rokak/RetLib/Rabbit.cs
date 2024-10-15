public class Rabbit
{
    public int Fullness { get; private set; }  
    private const int MaxFullness = 5;

    public Rabbit()
    {
        Fullness = MaxFullness;
    }

    public void Eat(Grass grass)
    {
        int nutrition = grass.GetNutritionValue();
        if (Fullness + nutrition <= MaxFullness && nutrition > 0)
        {
            Fullness += nutrition;
            grass.ResetToSeedling();  
        }
    }

    public void Starve()
    {
        Fullness--;
    }

    public bool IsDead()
    {
        return Fullness <= 0;
    }

    public void Move(Grid grid, Cell currentCell)
    {
        var neighbors = grid.GetNeighboringCells(currentCell.X, currentCell.Y);
        List<Cell> availableCells = neighbors.Where(c => c.IsEmpty()).ToList();

        
        List<Cell> preferredCells = availableCells.Where(c => c.Grass.State == GrassState.FullGrown).ToList();

        
        Cell targetCell = preferredCells.Count > 0 ? preferredCells[new Random().Next(preferredCells.Count)] : availableCells.Count > 0 ? availableCells[new Random().Next(availableCells.Count)] : null;

        if (targetCell != null)
        {
            targetCell.Rabbit = this;
            currentCell.Rabbit = null;
        }
    }

    public void TryReproduce(Grid grid, Cell currentCell)
    {
        List<Cell> adjacentCells = grid.GetAdjacentCells(currentCell);  

        foreach (var cell in adjacentCells)
        {
            if (cell.Rabbit != null)  
            {
                
                foreach (var adjacentCell in adjacentCells)
                {
                    if (adjacentCell.IsEmpty())
                    {
                        adjacentCell.Rabbit = new Rabbit();  
                        return;
                    }
                }
            }
        }
    }
}
