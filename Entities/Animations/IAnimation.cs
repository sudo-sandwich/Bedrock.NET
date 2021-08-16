using Bedrock.Entities.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public interface IAnimation {
        string ShortName { get; }
        string LongName { get; }
    }
}
