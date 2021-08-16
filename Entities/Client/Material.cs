using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class Material : ClientAsset {
        public override string ArrayEntry => $"material.{ShortName}";
        public Material(string shortName, string longName) : base(shortName, longName) { }
    }
}
