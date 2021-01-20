using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ReplaceItemBlock : Command {
        public Position Position { get; private set; }
        public int SlotId { get; private set; }
        public OldItemHandling? ReplaceMode { get; private set; } = null;
        public string ItemName { get; private set; }
        public int? Amount { get; private set; }
        public int? Data { get; private set; }
        public JObject Components { get; private set; }

        public ReplaceItemBlock(Position position, int slotId, string itemName, int? amount = null, int? data = null, JObject components = null) {
            Position = position;
            SlotId = slotId;
            ItemName = itemName;
            Amount = amount;
            Data = data;
            Components = components;
        }

        public ReplaceItemBlock(Position position, int slotId, OldItemHandling replaceMode, string itemName, int? amount = null, int? data = null, JObject components = null) {
            Position = position;
            SlotId = slotId;
            ReplaceMode = replaceMode;
            ItemName = itemName;
            Amount = amount;
            Data = data;
            Components = components;
        }

        public override string ToString() {
            if (ReplaceMode == null) {
                return CommandHelper.Build("replaceitem", "block", Position, "slot.container", SlotId, ItemName, Amount, Data, Components?.ToString());
            } else {
                return CommandHelper.Build("replaceitem", "block", Position, "slot.container", SlotId, ReplaceMode, ItemName, Amount, Data, Components?.ToString(Newtonsoft.Json.Formatting.None));
            }
        }
    }
}
