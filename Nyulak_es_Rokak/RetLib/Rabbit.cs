namespace RetLib;

public class Rabbit
{
    public int Fullness { get; private set; }
    private const int MaxFullness = 5;

    public Rabbit()
    {
        Fullness = MaxFullness / 2; 
    }

    public void Eat(Grass grass)
    {
        if (grass.NutritionalValue > 0)
        {
            Fullness += grass.NutritionalValue;
            Fullness = Math.Min(Fullness, MaxFullness);
            grass.Eat();
        }
    }

    public void Move(Grid grid)
    {
        
    }

    public void Reproduce()
    {
        
    }
}