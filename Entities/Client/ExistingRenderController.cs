using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class ExistingRenderController : IRenderController {
        public string Name { get; set; }

        public ExistingRenderController(string name) {
            Name = name;
        }
    }
}
