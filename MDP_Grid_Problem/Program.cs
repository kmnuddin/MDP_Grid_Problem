using MDP_Grid_Problem.Algorithm;
using MDP_Grid_Problem.Models;
using System;
using System.Collections.Generic;

namespace MDP_Grid_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Grid.Construct(6, 5, new Obstacle[] {
                    new Obstacle(2,2),
                    new Obstacle(4,4)
            });

            MDP mdp = new MDP(grid);

            grid = mdp.ValueIteration();

            //Grid.show_grid(grid);


        }

       
    }
}
