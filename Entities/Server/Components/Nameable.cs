using System;
using System.Collections.Generic;
using System.Text;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;

namespace Bedrock.Entities.Server.Components {
    //implementation not complete
    public class Nameable : IComponent {
        public string Name {
            get {
                return "minecraft:nameable";
            }
        }

        public bool? AlwaysShow { get; set; }
        public bool? AllowNameTagRenaming { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();
            jObject.AddIfNotNull("always_show", AlwaysShow);
            jObject.AddIfNotNull("allow_name_tag_renaming", AllowNameTagRenaming);

            return new JProperty(Name, jObject);
        }
    }
}
