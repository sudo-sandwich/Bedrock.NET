using Bedrock.Entities;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Summon : Command {
        public string EntityType { get; private set; }
        public Position? SpawnPos { get; private set; }
        public EntityEvent SpawnEvent { get; private set; }
        public string NameTag { get; private set; }

        private string output;

        public Summon(string entityType, Position? spawnPos = null, EntityEvent spawnEvent = null, string nameTag = null) {
            EntityType = entityType;
            SpawnPos = spawnPos;
            SpawnEvent = spawnEvent;
            NameTag = nameTag;

            output = CommandHelper.Build("summon", EntityType, spawnPos, spawnEvent?.Name, NameTag);
        }

        public Summon(string entityType, string nameTag, Position? spawnPos = null) {
            EntityType = entityType;
            NameTag = nameTag;
            SpawnPos = spawnPos;

            output = CommandHelper.Build("summon", EntityType, NameTag, SpawnPos);
        }

        public Summon(Entity entityType, Position? spawnPos = null, EntityEvent spawnEvent = null, string nameTag = null) {
            EntityType = entityType.FullIdentifier;
            SpawnPos = spawnPos;
            SpawnEvent = spawnEvent;
            NameTag = nameTag;

            output = CommandHelper.Build("summon", EntityType, spawnPos, spawnEvent?.Name, NameTag);
        }

        public Summon(Entity entityType, string nameTag, Position? spawnPos = null) {
            EntityType = entityType.FullIdentifier;
            NameTag = nameTag;
            SpawnPos = spawnPos;

            output = CommandHelper.Build("summon", EntityType, NameTag, SpawnPos);
        }

        public override string ToString() {
            return output;
        }
    }
}
