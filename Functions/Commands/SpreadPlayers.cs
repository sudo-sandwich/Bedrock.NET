using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class SpreadPlayers : Command {

        public Coordinate X { get; set; }
        public Coordinate Z { get; set; }
        public double SpreadDistance { get; set; }
        public double MaxRange { get; set; }
        public TargetSelector Victim { get; set; }

        public SpreadPlayers(Coordinate x, Coordinate z, double spreadDistance, double maxRange, TargetSelector victim) {
            X = x;
            Z = z;
            SpreadDistance = spreadDistance;
            MaxRange = maxRange;
            Victim = victim;
        }

        public override string ToString() {
            return CommandHelper.Build("spreadplayers", X, Z, SpreadDistance, MaxRange, Victim);
        }
    }
}
