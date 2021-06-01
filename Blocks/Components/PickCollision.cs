using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class PickCollision : BlockComponentBase
    {
        public bool Collision { get; set; } = true;
        public float[] Origin { get; set; }
        public float[] Size { get; set; }

        public PickCollision()
        {
            Name = "minecraft:pick_collision";
        }

        public override JProperty Generate()
        {
            if (!Collision)
                return new JProperty(Name, Collision);

            JObject jObject = new JObject();
            if (Origin != null) jObject.Add("origin", new JArray(Origin));
            if (Size != null) jObject.Add("size", new JArray(Size));
            return new JProperty(Name, jObject);
        }
    }
}
