using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_Grid_Problem.Models
{
    public class Action
    {
        public enum Actions { up, down, left, right };

        private State[,] grid;
        private int m = 0;
        private int n = 0;

        public Action(State[,] _grid)
        {
            grid = _grid;

            m = grid.GetLength(0);
            n = grid.GetLength(1);

        }
        public State Up(State[,] _grid, int i, int j)
        {
            if (i + 1 >= m || _grid[i + 1, j].StateType == State.Type.Obstacle)
                return _grid[i, j];

            return _grid[i + 1, j];
        }

        public State Down(State[,] _grid, int i, int j)
        {
            if (i - 1 < 0 || _grid[i - 1, j].StateType == State.Type.Obstacle)
                return _grid[i, j];

            return _grid[i - 1, j];
        }

        public State Right(State[,] _grid, int i, int j)
        {
            if (j + 1 >= n || _grid[i, j + 1].StateType == State.Type.Obstacle)
                return _grid[i, j];

            return _grid[i, j + 1];
        }

        public State Left(State[,] _grid, int i, int j)
        {
            if (j - 1 < 0 || _grid[i, j - 1].StateType == State.Type.Obstacle)
                return _grid[i, j];

            return _grid[i, j - 1];
        }
    }
}
