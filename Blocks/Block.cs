using Bedrock.Blocks.Components;
using Bedrock.Blocks.Events;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class Block
    {
        public string Prefix { get; set; } = "";
        public string Name { get; set; } = "";
        public string FullIdentifier { get { return Prefix + ":" + Name; } }
        public string FormatVersion { get; set; } = "1.16.0";
        public bool IsExperimental { get; set; } = true;

        // register_to_creative_menu
        public bool RegisterToCreativeMenu { get; set; } = true;

        // properties
        public List<Property> Properties { get; set; } = new List<Property>();

        // permutations (is the same as a component)
        public List<Permutation> Permutations { get; set; } = new List<Permutation>();

        // Terrain
        public Terrain Terrain { get; set; }
        public RPBlocks Definition { get; set; }

        public List<BlockComponentBase> Components { get; set; } = new List<BlockComponentBase>();
        public List<BlockEvent> Events { get; set; } = new List<BlockEvent>();

        public Block(string prefix, string name, Terrain t, RPBlocks r)
        {
            Prefix = prefix;
            Name = name;
            Terrain = t;
            Definition = r;
        }

        public TerrainDefinition RegisterTerrainDefinition()
        {
            TerrainDefinition td = new TerrainDefinition() { Name = Name };
            Terrain.TerrainData.Add(td);
            return td;
        }

        public BlockDefinition RegisterBlockDefinition()
        {
            BlockDefinition d = new BlockDefinition() { Identifier = FullIdentifier };
            Definition.Definitions.Add(d);
            return d;
        }

        public JObject GenerateBlock()
        {
            JObject jObject = new JObject();

            jObject.Add("format_version", FormatVersion);
            JObject minecraftBlock = new JObject();
            jObject.Add(new JProperty("minecraft:block", minecraftBlock));

            JObject description = new JObject();
            minecraftBlock.Add(new JProperty("description", description));
            description.Add("identifier", FullIdentifier);
            description.Add("is_experimental", IsExperimental);
            description.Add("register_to_creative_menu", RegisterToCreativeMenu);

            // properties

            if (Properties.Count > 0)
            {
                JObject props = new JObject();
                description.Add("properties", props);

                foreach (Property p in Properties)
                    props.Add(p.Generate());
            }

            // permutations ?
            if (Permutations.Count > 0)
            {
                JArray jArray = new JArray();
                minecraftBlock.Add("permutations", jArray);

                foreach (Permutation p in Permutations)
                    jArray.Add(p.Generate());
            }

            // components
            if (Components.Count > 0)
            {
                JObject components = new JObject();
                minecraftBlock.Add(new JProperty("components", components));

                foreach (BlockComponentBase bcb in Components)
                    components.Add(bcb.Generate());
            }

            // events
            if (Events.Count > 0)
            {
                JObject events = new JObject();
                minecraftBlock.Add(new JProperty("events", events));

                foreach (BlockEvent be in Events)
                    events.Add(be.Generate());
            }

            return jObject;
        }
    }
}
