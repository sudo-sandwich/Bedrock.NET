﻿using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities {
    public class SpawnEggColor : ISpawnEgg {
        public string BaseColor { get; private set; }
        public string OverlayColor { get; private set; }

        public SpawnEggColor(string baseColor, string overlayColor) {
            BaseColor = baseColor;
            OverlayColor = overlayColor;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("base_color", BaseColor);
            jObject.AddIfNotNull("overlay_color", OverlayColor);

            return jObject;
        }
    }
}
