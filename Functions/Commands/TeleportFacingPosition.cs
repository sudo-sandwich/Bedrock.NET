using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TeleportFacingPosition : Command {
        public TargetSelector Target { get; private set; }
        public Position Destination { get; private set; }
        public Position LookAtPosition { get; private set; }
        public bool? CheckForBlocks { get; private set; }

        public TeleportFacingPosition(TargetSelector target, Position destination, Position lookAtPosition, bool? checkForBlocks = null) {
            Target = target;
            Destination = destination;
            LookAtPosition = lookAtPosition;
            CheckForBlocks = checkForBlocks;
        }

        public override string ToString() {
            return CommandHelper.Build("teleport", Target, Destination, "facing", LookAtPosition, CheckForBlocks);
        }
    }
}
