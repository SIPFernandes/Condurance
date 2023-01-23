using Condurance.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condurance.App
{
    public class Grid : IGrid
    {
        public int MaxX { get; } = 10;
        public int MaxY { get; } = 10;
        public HashSet<Coordinate> ObstaclesHash { get; }

        public Grid() 
        {
            ObstaclesHash = new HashSet<Coordinate>();
        }
    
        public Grid(HashSet<Coordinate> obstacles)
        {
            ObstaclesHash = obstacles;
        }
    }
}
