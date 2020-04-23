using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Clear : Command {
        public TargetSelector Target { get; private set; }
        public string Item { get; private set; }
        public int? Data { get; private set; }
        public int? MaxCount { get; private set; }

        public Clear(TargetSelector target = null, string item = null, int? data = null, int? maxCount = null) {
            Target = target;
            Item = item;
            Data = data;
            MaxCount = maxCount;
        }

        public override string ToString() {
            return CommandHelper.Build("clear", Target, Item, Data, MaxCount);
        }
    }
}
