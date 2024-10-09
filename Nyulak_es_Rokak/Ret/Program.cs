using RetLib;
using System.Text;

namespace PredatorPreySimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 10;
            int columns = 10;
            Simulation simulation = new Simulation(rows, columns);
            simulation.Run();
        }
    }
}