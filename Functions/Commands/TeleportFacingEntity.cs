using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TeleportFacingEntity : Command {
        public TargetSelector Target { get; private set; }
        public Position Destination { get; private set; }
        public TargetSelector EntityToFace { get; private set; }
        public bool? CheckForBlocks { get; private set; }

        public TeleportFacingEntity(TargetSelector target, Position destination, TargetSelector entityToFace, bool? checkForBlocks = null) {
            Target = target;
            Destination = destination;
            EntityToFace = entityToFace;
            CheckForBlocks = checkForBlocks;
        }

        public override string ToString() {
            return CommandHelper.Build("teleport", Target, Destination, "facing", EntityToFace, CheckForBlocks);
        }
    }
}
