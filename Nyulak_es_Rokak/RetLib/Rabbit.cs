

public class Rabbit
{
    public int Fullness { get; private set; }  // Jóllakottság
    private const int MaxFullness = 5;

    public Rabbit()
    {
        Fullness = MaxFullness;
    }

    public void Eat(Grass grass)
    {
        int nutrition = grass.GetNutritionValue();
        if (Fullness + nutrition <= MaxFullness)
        {
            Fullness += nutrition;
            grass.ResetToSeedling();  // Nyúl legelés után zsenge fûre vált
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

    public void Move(Cell currentCell, Cell targetCell)
    {
        if (targetCell.IsEmpty())
        {
            targetCell.Rabbit = this;
            currentCell.Rabbit = null;
        }
    }
}
