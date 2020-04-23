using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TagRemove : Command {
        public TargetSelector Targets { get; private set; }
        public Tag Tag { get; private set; }

        public TagRemove(TargetSelector targets, Tag tag) {
            Targets = targets;
            Tag = tag;
        }

        public override string ToString() {
            return CommandHelper.Build("tag", Targets, "remove", Tag);
        }
    }
}
