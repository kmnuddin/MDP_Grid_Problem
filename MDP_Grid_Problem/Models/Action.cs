using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_Grid_Problem.Models
{
    public class Action
    {
        public enum Actions { up, down, left, right };
        public State Up(State[,] grid, int i, int j)
        {
            try
            {
                return grid[i + 1, j];
            }
            catch (IndexOutOfRangeException)
            {
                return grid[i, j];
            }
        }

        public State Down(State[,] grid, int i, int j)
        {
            try
            {
                return grid[i - 1, j];
            }
            catch (IndexOutOfRangeException)
            {
                return grid[i, j];
            }
        }

        public State Right(State[,] grid, int i, int j)
        {
            try
            {
                return grid[i, j + 1];
            }
            catch (IndexOutOfRangeException)
            {
                return grid[i, j];
            }
        }

        public State Left(State[,] grid, int i, int j)
        {
            try
            {
                return grid[i, j - 1];
            }
            catch (IndexOutOfRangeException)
            {
                return grid[i, j];
            }
        }
    }
}
