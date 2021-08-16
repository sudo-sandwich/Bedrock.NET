using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class ExistingAnimation : IAnimation {
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ExistingAnimation(string shortName, string longName) {
            ShortName = shortName;
            LongName = longName;
        }
    }
}
