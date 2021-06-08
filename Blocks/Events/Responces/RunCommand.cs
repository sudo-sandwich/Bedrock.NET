using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class RunCommand : BlockEventResponse
    {
        public string Command { get; set; } = "";
#pragma warning disable CA1819 // Properties should not return arrays
        // yeah no, its ok compiler... you allow this shit in C# 8 anyway
        public string[] CommandArray { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public string Target { get; set; } = "self";

        public RunCommand()
        {
            Name = "run_command";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (string.IsNullOrEmpty(Command))
                jObject.Add("command", new JArray(CommandArray));
            else
                jObject.Add("command", Command);
            if (!Target.Equals("self")) jObject.Add("target", Target);
            return new JProperty(Name, jObject);
        }
    }
}
