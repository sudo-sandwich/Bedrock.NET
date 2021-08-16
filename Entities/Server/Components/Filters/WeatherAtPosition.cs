using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class WeatherAtPosition : FilterTest {
        public override string Name {
            get {
                return "weather_at_position";
            }
        }

        public WeatherAtPosition(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
