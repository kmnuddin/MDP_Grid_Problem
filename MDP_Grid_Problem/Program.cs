using MDP_Grid_Problem.Models;
using System;

namespace MDP_Grid_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Grid.Construct(5, 5, new Obstacle[] {
                    new Obstacle(2,2),
                    new Obstacle(4,4)
            });

            for(int i = 4; i > 0; i--)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write(grid[i,j].Reward);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
    }
}
