using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Inventory : IComponent {
        public string Name => "minecraft:inventory";

        public int? AdditionalSlotsPerStrength { get; set; }
        public bool? CanBeSiphonedFrom { get; set; }
        public string ContainerType { get; set; }
        public int? InventorySize { get; set; }
        public bool? Private { get; set; }
        public bool? RestrictToOwner { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("additional_slots_per_strength", AdditionalSlotsPerStrength);
            jObject.AddIfNotNull("can_be_siphoned_from	", CanBeSiphonedFrom);
            jObject.AddIfNotNull("container_type", ContainerType);
            jObject.AddIfNotNull("inventory_size", InventorySize);
            jObject.AddIfNotNull("private", Private);
            jObject.AddIfNotNull("restrict_to_owner", RestrictToOwner);

            return new JProperty(Name, jObject);
        }
    }
}
