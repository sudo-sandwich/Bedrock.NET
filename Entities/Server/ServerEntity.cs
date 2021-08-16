using Bedrock.Entities.Animations;
using Bedrock.Entities.Server.Components;
using Bedrock.Files;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Server {
    public class ServerEntity {
        public Entity Parent { get; private set; }
        public string Prefix => Parent.Prefix;
        public string Identifier => Parent.Identifier;
        public string FullIdentifier => Parent.FullIdentifier;
        public string RuntimeIdentifier { get; set; }

        public bool IsSpawnable { get; set; } = true;
        public bool IsSummonable { get; set; } = true;
        public bool? IsExperimental { get; set; }

        public AnimationControllerFile AnimationControllerFile { get; }
        public AnimationTimelineFile AnimationTimelineFile { get; }
        public IList<IAnimation> Animations { get; } = new List<IAnimation>();
        public IList<AnimationBlend> AnimateScripts { get; } = new List<AnimationBlend>();

        public IList<ComponentGroup> ComponentGroups { get; } = new List<ComponentGroup>();
        public ComponentGroup MainComponents { get; } = new ComponentGroup("components", new ConditionalBandwidthOptimization());

        public IList<EntityEvent> Events { get; } = new List<EntityEvent>();

        //built in events
        public EntityEvent EntityBorn { get; } = new EntityEvent("minecraft:entity_born");
        public EntityEvent EntitySpawned { get; } = new EntityEvent("minecraft:entity_spawned");
        public EntityEvent EntityTransformed { get; } = new EntityEvent("minecraft:entity_transformed");
        public EntityEvent OnPrime { get; } = new EntityEvent("minecraft:on_prime");

        internal ServerEntity(Entity parent) {
            Parent = parent;
            AnimationControllerFile = new AnimationControllerFile(parent.Identifier);
            AnimationTimelineFile = new AnimationTimelineFile(parent.Identifier);
        }

        public ComponentGroup CreateComponentGroup(string name, params IComponent[] components) {
            ComponentGroup cg = new ComponentGroup(name, components);
            ComponentGroups.Add(cg);
            return cg;
        }

        public EntityEvent CreateEvent(string name) {
            EntityEvent ee = new EntityEvent(name);
            Events.Add(ee);
            return ee;
        }

        public EntityEvent CreateEvent(string name, ComponentGroup groupToAdd) {
            EntityEvent ee = new EntityEvent(name, groupToAdd);
            Events.Add(ee);
            return ee;
        }

        public EntityEvent CreateEvent(string name, ComponentGroup groupToAdd, ComponentGroup groupToRemove) {
            EntityEvent ee = new EntityEvent(name, groupToAdd, groupToRemove);
            Events.Add(ee);
            return ee;
        }

        public AnimationController CreateRootController(string shortName, string longName, string query = null) {
            AnimationController ac = new AnimationController(shortName, longName);
            AnimationControllerFile.Add(ac);
            AddRootAnimation(ac, query);
            return ac;
        }

        public AnimationTimeline CreateRootTimeline(string shortName, string longName, double length, bool loop, string query = null) {
            AnimationTimeline at = new AnimationTimeline(shortName, longName, length, loop);
            AnimationTimelineFile.Add(at);
            AddRootAnimation(at, query);
            return at;
        }

        public void AddRootAnimation(IAnimation anim, string query = null) {
            Animations.Add(anim);
            AnimateScripts.Add(new AnimationBlend(anim, query));
        }

        public JObject Generate() {
            JObject jObject = new JObject();

            jObject.Add("format_version", "1.16.1");
            JObject minecraftEntity = new JObject();
            jObject.Add(new JProperty("minecraft:entity", minecraftEntity));

            JObject description = new JObject();
            minecraftEntity.Add(new JProperty("description", description));
            description.Add("identifier", FullIdentifier);
            description.AddIfNotNull("runtime_identifier", RuntimeIdentifier);
            description.Add("is_spawnable", IsSpawnable);
            description.Add("is_summonable", IsSummonable);
            description.AddIfNotNull("is_experimental", IsExperimental);

            EntityUtil.AddAnimations(description, Animations, AnimateScripts);

            if (ComponentGroups.Count > 0) {
                JObject componentGroups = new JObject();
                minecraftEntity.Add(new JProperty("component_groups", componentGroups));
                foreach (ComponentGroup componentGroup in ComponentGroups) {
                    componentGroups.Add(componentGroup.Generate());
                }
            }

            if (MainComponents.Count > 0) {
                minecraftEntity.Add(MainComponents.Generate());
            }

            IList<EntityEvent> events = new List<EntityEvent>();
            if (EntityBorn.HasContent) events.Add(EntityBorn);
            if (EntitySpawned.HasContent) events.Add(EntitySpawned);
            if (EntityTransformed.HasContent) events.Add(EntityTransformed);
            if (OnPrime.HasContent) events.Add(OnPrime);
            events.AddRange(Events);

            if (events.Count > 0) {
                JObject eventsJO = new JObject();
                minecraftEntity.Add(new JProperty("events", eventsJO));
                foreach (EntityEvent eventToAdd in events) {
                    eventsJO.Add(eventToAdd.Generate());
                }
            }

            return jObject;
        }
    }
}
