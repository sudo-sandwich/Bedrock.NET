using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Give : Command {
        public TargetSelector Target { get; private set; }
        public string ItemName { get; private set; }
        public int? Amount { get; private set; }
        public int? Data { get; private set; }
        //Components argument not implemented yet.
        //public JObject Components { get; private set; }

        public Give(TargetSelector target, string itemName, int? amount = null, int? data = null) {
            Target = target;
            ItemName = itemName;
            Amount = amount;
            Data = data;
        }

        public override string ToString() {
            return CommandHelper.Build("give", Target, ItemName, Amount, Data);
        }
    }
}
