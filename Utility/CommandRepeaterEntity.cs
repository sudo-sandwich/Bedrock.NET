using Bedrock.Entities;
using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Entities.Components.Filters;
using Bedrock.Files;
using Bedrock.Functions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Utility {
    public class CommandRepeaterEntity : IEntityTemplate {
        public Entity AttachedEntity { get; private set; }
        public double Frequency { get; private set; }
        public IList<IEvent> Commands { get; private set; }

        public CommandRepeaterEntity(string prefix, string identifier, params IEvent[] commands) {
            AttachedEntity = new Entity(prefix, identifier);
            Frequency = 0.05;
            Commands = new List<IEvent>(commands);
        }

        public CommandRepeaterEntity(string prefix, string identifier, double frequency, params IEvent[] commands) {
            AttachedEntity = new Entity(prefix, identifier);
            Frequency = frequency;
            Commands = new List<IEvent>(commands);
        }

        public Entity ToEntity() {
            if (Commands.Count == 0) {
                throw new InvalidOperationException("There are no commands to generate.");
            }

            AddonContent content = new AddonContent();
            Entity entity = new Entity(AttachedEntity.Prefix, AttachedEntity.Identifier) {
                IsSpawnable = false
            };
            entity.MainComponents.Add(new Despawn() { Filter = new Filter(Group.AllOf, new HasTag(Subject.Self, Test.Equal, "despawn")) });
            //entity.MainComponents.Add(new TickWorld());

            AnimationTimeline animationTimeline = entity.CreateBehaviorAnimationTimeline(entity.Identifier, "animation." + entity.Identifier + ".commands", Frequency, true);
            animationTimeline.Timeline.Add(new TimelineStep(0, Commands.ToArray()));

            return entity;
        }
    }
}
