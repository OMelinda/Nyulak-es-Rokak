public class Cell
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Grass Grass { get; set; }
    public Rabbit Rabbit { get; set; }
    public Fox Fox { get; set; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        Grass = new Grass();
    }

    public bool IsEmpty()
    {
        return Rabbit == null && Fox == null;
    }
}