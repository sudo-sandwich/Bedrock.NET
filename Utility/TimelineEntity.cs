using Bedrock.Entities;
using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Entities.Components.Filters;
using Bedrock.Functions.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class TimelineEntity : IEntityTemplate {
        public bool Loop { get; set; }
        public double? Length { get; set; }

        public Entity AttachedEntity { get; private set; }
        public IList<TimelineStep> Steps { get; private set; } = new List<TimelineStep>();

        public double NextDelay { get; set; } = 0;

        public TimelineEntity(string prefix, string identifier, double? length = null, bool loop = false) {
            AttachedEntity = new Entity() {
                Prefix = prefix,
                Identifier = identifier
            };

            Length = length;
            Loop = loop;
        }

        public void AddStep(double stepTime, params IEvent[] events) {
            stepTime += NextDelay;
            NextDelay = 0;
            if (Steps.Count == 0) {
                Steps.Add(new TimelineStep(stepTime, events));
            } else if (stepTime == 0) {
                Steps[Steps.Count - 1].Events.AddRange(events);
            } else {
                Steps.Add(new TimelineStep(Steps[Steps.Count - 1].Time + stepTime, events));
            }
        }

        public Entity ToEntity() {
            if (Steps.Count == 0) {
                throw new InvalidOperationException("Timeline has no steps to generate.");
            }

            Entity entity = new Entity() {
                Prefix = AttachedEntity.Prefix,
                Identifier = AttachedEntity.Identifier,
                IsSpawnable = false
            };
            entity.MainComponents.Add(new Despawn() { Filter = new Filter(Group.AllOf, new HasTag(Subject.Self, Test.Equal, TagManager.Despawn)) });
            //entity.MainComponents.Add(new TickWorld());

            if (!Loop) {
                Steps[Steps.Count - 1].Events.Add(new TagAdd(TargetSelector.Self, TagManager.Despawn));
            }
            AnimationTimeline animationTimeline = entity.CreateBehaviorAnimationTimeline(entity.Identifier, "animation." + entity.Identifier + ".commands", Length ?? Steps[Steps.Count - 1].Time + 5, Loop);
            animationTimeline.Timeline.AddRange(Steps);

            return entity;
        }
    }
}
