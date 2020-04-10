using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TitleTimes : Command {
        public TargetSelector Selector { get; private set; }
        public int FadeIn { get; private set; }
        public int Stay { get; private set; }
        public int FadeOut { get; private set; }

        public TitleTimes(TargetSelector selector, int fadeIn, int stay, int fadeOut) {
            Selector = selector;
            FadeIn = fadeIn;
            Stay = stay;
            FadeOut = fadeOut;
        }

        public override string ToString() {
            return CommandHelper.Build("title", Selector, "times", FadeIn, Stay, FadeOut);
        }
    }
}
