using Bedrock.Entities.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Utility {
    public struct EventGroup {
        public EntityEvent AddEvent { get; private set; }
        public EntityEvent RemoveEvent { get; private set; }
        public ComponentGroup Group { get; private set; }

        public EventGroup(EntityEvent addEvent, EntityEvent removeEvent, ComponentGroup group) {
            AddEvent = addEvent;
            RemoveEvent = removeEvent;
            Group = group;
        }
    }
}
