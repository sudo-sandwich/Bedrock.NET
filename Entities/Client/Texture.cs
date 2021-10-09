using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class Texture : ClientAsset {
        public override string ArrayEntry => $"Texture.{ShortName}";
        public Texture(string shortName, string longName) : base(shortName, longName) { }
    }
}
