using Bedrock.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public interface IEntityTemplate {
        Entity ToEntity();
    }
}
