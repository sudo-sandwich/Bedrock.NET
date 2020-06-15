using Bedrock.Entities.Animations;
using Bedrock.Functions.Commands;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Functions {
    public class MCFunction : IEvent {
        public string Name { get; set; }
        public IList<Command> Commands { get; } = new List<Command>();

        //this value should be assigned by AddonContent only
        internal string FunctionName { get; set; }

        public JToken Expression {
            get {
                return "/" + ToCommand().ToString();
            }
        }

        public MCFunction(string name, params Command[] commands) {
            Name = name;
            Commands.AddRange(commands);
        }

        public override string ToString() {
            IList<string> commands = Commands.Select(c => c.ToString()).ToList();
            return string.Join("\n", commands);
        }

        public static implicit operator Command(MCFunction mcf) {
            return mcf?.ToCommand();
        }
        
        public Command ToCommand() {
            return new Function(this);
        }

        private class Function : Command {
            public MCFunction function { get; private set; }

            public Function(MCFunction mcFunction) {
                function = mcFunction;
            }

            public override string ToString() {
                //this if statement is here just becuase of some legacy code in the area 51 project. should only use MCFunction.FunctionName
                if (function.FunctionName != null) {
                    return CommandHelper.Build("function", function.FunctionName);
                } else {
                    //remove this else block after Area 51 is complete
                    if (function.Name.StartsWith("npc_dialogue_")) {
                        return CommandHelper.Build("function", "dialogue/" + function.Name);
                    }
                    return CommandHelper.Build("function", function.Name);
                }
            }
        }
    }
}
