using MDP_Grid_Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MDP_Grid_Problem.Models.Action;

namespace MDP_Grid_Problem.Algorithm
{
    public class MDP
    {
        private State[,] grid;

        private State[,] temp_grid;

        private int m = 0;
        private int n = 0;

        public MDP(State[,] _grid)
        {
            grid = _grid;

            m = grid.GetLength(0);
            n = grid.GetLength(1);

            InitializeTempGrid();
        }

        private void InitializeTempGrid()
        {
            temp_grid = new State[m, n];

            for(int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp_grid[i, j].Utility = -100;
                }
            }
        }


        public State[,] ValueIteration()
        {
            while(CheckConvergence(grid, temp_grid))
            {
                temp_grid = grid;

                
            }
        }

        private bool CheckConvergence(State[,] grid, State[,] temp_grid)
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid[i, j].Utility != temp_grid[i, j].Utility)
                        return false;
                }
            }

            return true;
        }
    }
}
