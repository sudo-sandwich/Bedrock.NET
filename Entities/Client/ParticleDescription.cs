using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class ParticleDescription {
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public ParticleDescription(string shortName, string longName) {
            ShortName = shortName;
            LongName = longName;
        }
    }
}
