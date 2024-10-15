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

        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell(i, j);
            }
        }
    }

    
    public Cell GetCell(int x, int y)
    {
        if (IsWithinBounds(x, y))
            return Cells[x, y];
        return null;
    }

    
    public List<Cell> GetNeighboringCells(int x, int y)
    {
        List<Cell> neighbors = new List<Cell>();

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                if (IsWithinBounds(x + i, y + j))
                {
                    neighbors.Add(Cells[x + i, y + j]);
                }
            }
        }

        return neighbors;
    }

    public List<Cell> GetAdjacentCells(Cell currentCell)
    {
        List<Cell> adjacentCells = new List<Cell>();

        for (int x = currentCell.X - 1; x <= currentCell.X + 1; x++)
        {
            for (int y = currentCell.Y - 1; y <= currentCell.Y + 1; y++)
            {
                if (x == currentCell.X && y == currentCell.Y) continue;  

                if (IsWithinBounds(x, y))  
                {
                    adjacentCells.Add(GetCell(x, y));  
                }
            }
        }

        return adjacentCells;
    }

    
    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }


}
