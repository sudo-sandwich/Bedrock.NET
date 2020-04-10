using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Particle : Command {
        public string Effect { get; private set; }
        public Position Position { get; private set; }

        public Particle(string effect, Position position) {
            Effect = effect;
            Position = position;
        }

        public override string ToString() {
            return CommandHelper.Build("particle", Effect, Position);
        }
    }
}
