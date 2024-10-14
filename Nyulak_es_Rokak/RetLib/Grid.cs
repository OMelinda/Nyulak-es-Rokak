public class Grid
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public Cell[,] Cells;

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new Cell[width, height];

        // Létrehozzuk a cellákat
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell(i, j);
            }
        }
    }

    // Segédfüggvény egy adott cella lekérdezésére
    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
            return Cells[x, y];
        return null;
    }
}
