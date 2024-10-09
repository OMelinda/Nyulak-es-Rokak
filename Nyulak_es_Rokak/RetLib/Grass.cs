namespace RetLib;

public class Grass
{
    public enum GrassState { Seedling, YoungGrass, FullGrass }
    public GrassState State { get; private set; }
    public int NutritionalValue => State == GrassState.FullGrass ? 2 : State == GrassState.YoungGrass ? 1 : 0;

    public Grass()
    {
        State = GrassState.Seedling;
    }

    public void Grow()
    {
        if (State == GrassState.Seedling)
            State = GrassState.YoungGrass;
        else if (State == GrassState.YoungGrass)
            State = GrassState.FullGrass;
    }

    public void Eat()
    {
        if (State == GrassState.FullGrass)
            State = GrassState.YoungGrass;
        else if (State == GrassState.YoungGrass)
            State = GrassState.Seedling;
    }
}