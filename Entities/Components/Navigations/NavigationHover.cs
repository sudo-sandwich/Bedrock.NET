using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Navigation {
    public class NavigationHover : NavigationBase {
        public override string Name {
            get {
                return "minecraft:navigation.hover";
            }
        }
    }
}
