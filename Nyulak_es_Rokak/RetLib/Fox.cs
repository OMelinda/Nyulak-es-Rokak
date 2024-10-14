
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
        Fullness += 3;  // Nyúl tápértéke 3
        currentCell.Rabbit = null;  // Nyulat elfogyasztja
    }

    public void Starve()
    {
        Fullness--;
    }

    public bool IsDead()
    {
        return Fullness <= 0;
    }

    public void Move(Cell currentCell, Cell targetCell)
    {
        if (targetCell.IsEmpty())
        {
            targetCell.Fox = this;
            currentCell.Fox = null;
        }
    }
}