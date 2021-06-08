using Bedrock.Blocks.Events.Responces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events
{
    public class BlockEvent
    {
        public string Name { get; set; }
        public List<BlockEventResponse> Responces { get; set; } = new List<BlockEventResponse>();
        public bool HasResponces => Responces.Count > 0;

        public List<BlockEventResponse> Sequence { get; set; } = new List<BlockEventResponse>();

        public BlockEvent(string name)
        {
            Name = name;
        }

        public void AddResponce(BlockEventResponse ber)
        {
            Responces.Add(ber);
        }

        public JProperty Generate()
        {
            JObject jObject = new JObject();

            if (Responces.Count > 0)
            {
                foreach (BlockEventResponse r in Responces)
                    jObject.Add(r.Generate());
            }

            if (Sequence.Count > 0)
            {
                JArray jArray = new JArray();
                jObject.Add("sequence", jArray);

                foreach (BlockEventResponse ber in Sequence)
                {
                    JObject j = new JObject(ber.Generate());
                    jArray.Add(j);
                }
            }

            return new JProperty(Name, jObject);
        }
    }
}
