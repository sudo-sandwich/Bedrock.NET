using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    //incomplete implementation of teleport
    public class Teleport : Command {
        public TargetSelector Victim { get; private set; }
        public Position Destination { get; private set; }
        public Coordinate? YRot { get; private set; }
        public Coordinate? XRot { get; private set; }
        
        public Teleport(TargetSelector victim, Position destination, Coordinate? yRot = null, Coordinate? xRot = null) {
            Victim = victim;
            Destination = destination;
            YRot = yRot;
            XRot = xRot;
        }

        public override string ToString() {
            return CommandHelper.Build("teleport", Victim, Destination, YRot, XRot);
        }
    }
}
