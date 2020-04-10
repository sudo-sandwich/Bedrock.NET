using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Components {
    public interface IComponent {
        string Name { get; }
        JProperty Generate();
    }
}
