﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public interface IBehavior : IComponent {
        int Priority { get; set; } //priority must be set before generating JProperty
    }
}
