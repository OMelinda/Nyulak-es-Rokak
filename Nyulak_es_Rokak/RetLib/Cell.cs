namespace RetLib;

public class Cell
{
    public Grass Grass { get; set; }
    public Rabbit Rabbit { get; set; }
    public Fox Fox { get; set; }

    public Cell(Grass grass)
    {
        Grass = grass;
        Rabbit = null!;
        Fox = null!;
    }

    public bool IsEmpty() => Rabbit == null && Fox == null;
}