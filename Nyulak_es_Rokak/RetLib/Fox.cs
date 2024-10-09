namespace RetLib;

public class Fox
{
    public int Fullness { get; private set; }
    private const int MaxFullness = 10;

    public Fox()
    {
        Fullness = MaxFullness / 2;
    }

    public void Eat(Rabbit rabbit)
    {
        Fullness += 3;
        Fullness = Math.Min(Fullness, MaxFullness);
        
    }

    public void Move(Grid grid)
    {
        
    }

    public void Reproduce()
    {
        
    }
}
