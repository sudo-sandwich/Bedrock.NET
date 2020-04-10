using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Weather : Command {
        public WeatherType Type { get; private set; }
        public int? Duration { get; private set; }

        public Weather(WeatherType type, int? duration = null) {
            Type = type;
            Duration = duration;
        }

        public override string ToString() {
            return CommandHelper.Build("weather", Type.GetDescription(), Duration);
        }
    }

    public enum WeatherType {
        [Description("clear")]
        Clear,
        [Description("rain")]
        Rain,
        [Description("thunder")]
        Thunder
    }
}
