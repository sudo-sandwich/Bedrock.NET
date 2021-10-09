using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class SetWorldSpawn : Command {
        public Position SpawnPoint { get; private set; }

        public SetWorldSpawn(Position spawnPoint) {
            SpawnPoint = spawnPoint;
        }

        public override string ToString() {
            return CommandHelper.Build("setworldspawn", SpawnPoint);
        }
    }
}
