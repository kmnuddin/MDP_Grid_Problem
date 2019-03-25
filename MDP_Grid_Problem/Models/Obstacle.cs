using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_Grid_Problem.Models
{
    public class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Obstacle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
