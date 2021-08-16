using Bedrock.Entities.Server;
using Bedrock.Entities.Server.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public static class EntityExtensions {
        public static EntityEvent CreateDespawnEvent(this ServerEntity se, string eventName = "despawn", string groupName = "despawn_group") => se.CreateEvent(eventName, se.CreateComponentGroup(groupName, new InstantDespawn()));
    }
}
