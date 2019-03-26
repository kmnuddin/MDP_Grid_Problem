using MDP_Grid_Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MDP_Grid_Problem.Models.Action;
using Action = MDP_Grid_Problem.Models.Action;

namespace MDP_Grid_Problem.Algorithm
{
    public class MDP
    {
        private State[,] grid;

        private List<State[,]> Stacks;

        private State[,] updated_grid;

        private Action action;

        private int m = 0;
        private int n = 0;

        private double gamma = 1;


        public MDP(State[,] _grid)
        {
            grid = _grid;
            //initialize_updated_grid();

            m = grid.GetLength(0);
            n = grid.GetLength(1);

            action = new Action(grid);

            Stacks = new List<State[,]>();
        }

        public State[,] ValueIteration()
        {
            int iteration = 1;
            while(!convergence(Stacks))
            {
                updated_grid = new State[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[i, j].StateType == State.Type.Normal)
                        {
                            grid[i, j].Utility = grid[i, j].Reward + compute_policy(i, j);
                            updated_grid[i, j] = new State(-0.04, Math.Round(grid[i, j].Utility, 2), State.Type.Normal);
                        }
                        else
                        {
                            updated_grid[i, j] = new State(grid[i, j].Reward, grid[i, j].Utility, grid[i, j].StateType);
                        }
                    }
   
                }
                Stacks.Add(updated_grid);
                
                

            }

            foreach (var item in Stacks)
            {
                Console.WriteLine("Values: " + iteration);
                Grid.show_grid(item);
                Console.WriteLine();
                iteration++;
            }   
            return grid;
        }

        private bool convergence(List<State[,]> stacks)
        {
            if (stacks.Count <= 1)
                return false;
            if (!is_same_utility(stacks[stacks.Count - 2], stacks[stacks.Count - 1]))
                return false;

            return true;

        }

        private double compute_policy(int i, int j)
        {
            var state_up = action.Up(grid, i, j).Utility;
            var state_down = action.Down(grid, i, j).Utility;
            var state_right = action.Right(grid, i, j).Utility;
            var state_left = action.Left(grid, i, j).Utility;

            double[] transition_values = new double[4];

            transition_values[0] = state_up * 0.8 + state_right * 0.1 + state_left * 0.1;
            transition_values[1] = state_down * 0.8 + state_right * 0.1 + state_left * 0.1;
            transition_values[2] = state_up * 0.1 + state_right * 0.8 + state_left * 0.1;
            transition_values[3] = state_up * 0.1 + state_right * 0.1 + state_left * 0.8;

            return maximize_trans_values(transition_values);

        }

        private double maximize_trans_values(double[] transition_values)
        {
            double max = 0;

            foreach(var v in transition_values)
            {
                if (max < v)
                    max = v;
            }

            return max;
        }

        private void initialize_updated_grid()
        {
            updated_grid = new State[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    updated_grid[i, j] = new State(-100, -100, State.Type.Undesired);
                }
            }
        }

       

        private bool is_same_utility(State[,] grid_i1, State[,] grid_i2)
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid_i1[i, j].Utility != grid_i2[i, j].Utility)
                        return false;
                }
            }

            return true;
        }
    }
}
