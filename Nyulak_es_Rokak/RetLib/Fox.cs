public class Fox
{
    public int Fullness { get; private set; }
    private const int MaxFullness = 10;

    public Fox()
    {
        Fullness = MaxFullness;
    }

    public void Eat(Rabbit rabbit, Cell currentCell)
    {
        Fullness += 3;  
        currentCell.Rabbit = null;  
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
        Cell targetRabbitCell = neighbors.FirstOrDefault(c => c.Rabbit != null);

        if (targetRabbitCell != null)
        {
            
            Eat(targetRabbitCell.Rabbit, targetRabbitCell);
            targetRabbitCell.Fox = this;
            currentCell.Fox = null;
        }
        else
        {
            
            List<Cell> availableCells = neighbors.Where(c => c.IsEmpty() && c.Fox == null).ToList();
            if (availableCells.Count > 0)
            {
                Cell targetCell = availableCells[new Random().Next(availableCells.Count)];
                targetCell.Fox = this;
                currentCell.Fox = null;
            }
        }
    }

    public bool TryReproduce(Grid grid, Cell currentCell)
    {
        var neighbors = grid.GetNeighboringCells(currentCell.X, currentCell.Y);
        if (neighbors.Any(c => c.Fox != null))  
        {
            List<Cell> emptyCells = neighbors.Where(c => c.IsEmpty()).ToList();
            if (emptyCells.Count > 0)
            {
                Cell birthCell = emptyCells[new Random().Next(emptyCells.Count)];
                birthCell.Fox = new Fox();  
                return true;
            }
        }
        return false;
    }
}
