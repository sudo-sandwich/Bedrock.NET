using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Title : Command {
        public TargetSelector Selector { get; private set; }
        public TitleType Type { get; private set; }
        public string TitleText { get; private set; }

        public Title(TargetSelector selector, TitleType type, string titleText) {
            Selector = selector;
            Type = type;
            TitleText = titleText;
        }

        public override string ToString() {
            return CommandHelper.Build("title", Selector, Type.GetDescription(), TitleText);
        }
    }

    public enum TitleType {
        [Description("title")]
        Title,
        [Description("subtitle")]
        Subtitle,
        [Description("actionbar")]
        Actionbar
    }
}
