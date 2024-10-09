namespace RetLib;

public class Grid
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public Cell[,] Cells { get; private set; }

    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = new Cell[rows, columns];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Cells[i, j] = new Cell(new Grass());
            }
        }
    }
}