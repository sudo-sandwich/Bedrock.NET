using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class Geometry : ClientAsset {
        public override string ArrayEntry => $"geometry.{ShortName}";
        public Geometry(string shortName, string longName) : base(shortName, longName) { }
    }
}
