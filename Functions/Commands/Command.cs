using Bedrock.Entities.Animations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public abstract class Command : IEvent {
        public string Expression {
            get {
                return "/" + ToString();
            }
        }
    }
}
