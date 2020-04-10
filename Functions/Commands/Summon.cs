using Bedrock.Entities;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Summon : Command {
        public Entity EntityType { get; private set; }
        public Position? SpawnPos { get; private set; }
        public EntityEvent SpawnEvent { get; private set; }
        public string NameTag { get; private set; }

        private string output;

        public Summon(Entity entityType, Position? spawnPos = null, EntityEvent spawnEvent = null, string nameTag = null) {
            EntityType = entityType;
            SpawnPos = spawnPos;
            SpawnEvent = spawnEvent;
            NameTag = nameTag;

            output = CommandHelper.Build("summon", EntityType?.FullIdentifier, spawnPos, spawnEvent?.Name, NameTag);
        }

        public Summon(Entity entityType, string nameTag, Position? spawnPos = null) {
            EntityType = entityType;
            NameTag = nameTag;
            SpawnPos = spawnPos;

            output = CommandHelper.Build("summon", EntityType?.FullIdentifier, NameTag, SpawnPos);
        }

        public override string ToString() {
            return output;
        }
    }
}
