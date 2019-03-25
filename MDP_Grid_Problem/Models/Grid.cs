using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_Grid_Problem.Models
{
    public static class Grid
    {
        public static State[,] Construct(int m, int n, Obstacle[] q)
        {
            var grid = new State[m, n];

            grid[m - 1, n - 1] = new State(1, 1, State.Type.Goal);
            grid[m - 2, n - 1] = new State(-1, -1, State.Type.Undesired);
            

            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid[i, j] == null)
                        grid[i, j] = new State(-0.04, 0, State.Type.Normal);
                }
            }
            addObstacle(grid, q);
            return grid;
        }

        private static void addObstacle(State[,] grid, Obstacle[] q)
        {
            foreach(var o in q)
            {
                grid[o.X - 1, o.Y - 1] = new State(0, 0, State.Type.Obstacle);
            }
        }
    }
}
