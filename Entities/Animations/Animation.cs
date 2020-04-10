using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class Animation : IAnimation {
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public Animation(string shortName, string longName) {
            ShortName = shortName;
            LongName = longName;
        }
    }
}
