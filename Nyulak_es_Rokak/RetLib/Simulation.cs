namespace RetLib;

public class Simulation
{
    private Grid _grid;
    private int _turn;

    public Simulation(int rows, int columns)
    {
        _grid = new Grid(rows, columns);
        _turn = 0;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            DisplayGrid();
            UpdateEntities();
            _turn++;
            Thread.Sleep(1000);
        }
    }

    private void DisplayGrid()
    {
        for (int i = 0; i < _grid.Rows; i++)
        {
            for (int j = 0; j < _grid.Columns; j++)
            {
                var cell = _grid.Cells[i, j];
                if (cell.Fox != null) Console.Write("F ");
                else if (cell.Rabbit != null) Console.Write("R ");
                else if (cell.Grass.State == Grass.GrassState.FullGrass) Console.Write("G ");
                else if (cell.Grass.State == Grass.GrassState.YoungGrass) Console.Write("Y ");
                else Console.Write(". ");
            }
            Console.WriteLine();
        }
    }

    private void UpdateEntities()
    {
        
    }
}