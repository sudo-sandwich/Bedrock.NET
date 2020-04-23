using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities {
    public class SpawnEggTexture : ISpawnEgg {

        public string Texture { get; private set; }
        public int? TextureIndex { get; private set; }

        public SpawnEggTexture(string texture, int? textureIndex = null) {
            Texture = texture;
            TextureIndex = textureIndex;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("texture", Texture);
            jObject.AddIfNotNull("texture_index", TextureIndex);

            return jObject;
        }
    }
}
