using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ReplaceItemEntity : Command {
        public TargetSelector Target { get; private set; }
        public ItemSlot Slot { get; private set; }
        public int SlotId { get; private set; }
        public OldItemHandling? ReplaceMode { get; private set; }
        public string ItemName { get; private set; }
        public int? Amount { get; private set; }
        public int? Data { get; private set; }
        public JObject Components { get; private set; }

        public ReplaceItemEntity(TargetSelector target, ItemSlot slot, int slotId, string itemName, int? amount = null, int? data = null, JObject components = null) {
            Target = target;
            Slot = slot;
            SlotId = slotId;
            ItemName = itemName;
            Amount = amount;
            Data = data;
            Components = components;
        }

        public ReplaceItemEntity(TargetSelector target, ItemSlot slot, int slotId, OldItemHandling replaceMode, string itemName, int? amount = null, int? data = null, JObject components = null) {
            Target = target;
            Slot = slot;
            SlotId = slotId;
            ReplaceMode = replaceMode;
            ItemName = itemName;
            Amount = amount;
            Data = data;
            Components = components;
        }

        public override string ToString() {
            if (ReplaceMode == null) {
                return CommandHelper.Build("replaceitem", "entity", Target, Slot.GetDescription(), SlotId, ItemName, Amount, Data, Components);
            } else {
                return CommandHelper.Build("replaceitem", "entity", Target, Slot.GetDescription(), SlotId, ReplaceMode.GetDescription(), ItemName, Amount, Data, Components);
            }
        }
    }

    public enum ItemSlot {
        [Description("slot.armor")]
        HorseArmor,
        [Description("slot.armor.chest")]
        Chest,
        [Description("slot.armor.feet")]
        Feet,
        [Description("slot.armor.head")]
        Head,
        [Description("slot.armor.legs")]
        Legs,
        [Description("slot.chest")]
        HorseInventory,
        [Description("slot.enderchest")]
        EnderChest,
        [Description("slot.hotbar")]
        Hotbar,
        [Description("slot.inventory")]
        Inventory,
        [Description("slot.saddle")]
        Saddle,
        [Description("slot.weapon.mainhand")]
        MainHand,
        [Description("slot.weapon.offhand")]
        OffHand
    }

    public enum OldItemHandling {
        [Description("destroy")]
        Destroy,
        [Description("keep")]
        Keep
    }

}
