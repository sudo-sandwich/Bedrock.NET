using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    //incomplete implementation of teleport
    public class TeleportTarget : Command {
        public TargetSelector Victim { get; private set; }
        public TargetSelector Destination { get; private set; }
        public bool? CheckForBlocks { get; private set; }
        
        public TeleportTarget(TargetSelector victim, TargetSelector destination, bool? checkForBlocks = null) {
            Victim = victim;
            Destination = destination;
            CheckForBlocks = checkForBlocks;
        }

        public override string ToString() {
            return CommandHelper.Build("teleport", Victim, Destination, CheckForBlocks);
        }
    }
}
