using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Execute : Command {
        public TargetSelector Selector { get; private set; }
        public Position Position { get; private set; }
        public Command Command { get; private set; }
        public Position? DetectPos { get; private set; }
        public string Block { get; private set; }
        public int? Data { get; private set; }

        public Execute(TargetSelector selector, Position position, Command command) {
            Selector = selector;
            Position = position;
            Command = command;
        }

        public Execute(TargetSelector selector, Command command) : this(selector, Position.Self, command) { }

        public Execute(TargetSelector selector, Position position, Position detectPos, string block, int data, Command command) {
            Selector = selector;
            Position = position;
            DetectPos = detectPos;
            Block = block;
            Data = data;
            Command = command;
        }

        public override string ToString() {
            if (DetectPos != null && Block != null && Data != null) {
                return CommandHelper.Build("execute", Selector, Position, "detect", DetectPos, Block, Data, Command);
            } else {
                return CommandHelper.Build("execute", Selector, Position, Command);
            }
        }
    }
}
