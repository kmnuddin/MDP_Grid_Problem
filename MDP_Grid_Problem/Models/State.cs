using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_Grid_Problem.Models
{
    public class State
    {
        public double Reward { get; set; }
        public double Utility { get; set; }

        public State(double reward, double utility, Type? stateType)
        {
            Reward = reward;
            Utility = utility;
            StateType = stateType;
        }

        public enum Type { Goal, Undesired, Normal, Obstacle };
        public Type? StateType = null;

    }

    
}
