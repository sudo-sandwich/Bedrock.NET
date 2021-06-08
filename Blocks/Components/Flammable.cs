using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Flammable : BlockComponentBase
    {
        public int? BurnOdds { get; set; }
        public int? FlameOdds { get; set; }

        public Flammable()
        {
            Name = "minecraft:flammable";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (BurnOdds != null) jObject.Add("burn_odds", BurnOdds);
            if (FlameOdds != null) jObject.Add("flame_odds", FlameOdds);

            return new JProperty(Name, jObject);
        }
    }
}
