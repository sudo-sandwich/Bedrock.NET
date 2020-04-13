using Bedrock.Entities;
using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Entities.Components.Filters;
using Bedrock.Functions.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class TimelineEntity {
        public bool Loop { get; set; }
        public double? Length { get; set; }

        public Entity AttachedEntity { get; private set; } //this entity is always empty, used for things that don't care about components (like a summon command) before you generate the full entity.
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

        public Entity Generate(TimelineEntity despawnPreviousTimeline) {
            return Generate(despawnPreviousTimeline?.AttachedEntity);
        }
        public Entity Generate(Entity despawnPreviousEntity = null) {
            if (Steps.Count == 0) {
                throw new InvalidOperationException("Timeline has no steps to generate.");
            }

            Entity entity = new Entity() {
                Prefix = AttachedEntity.Prefix,
                Identifier = AttachedEntity.Identifier,
                IsSpawnable = false
            };
            entity.MainComponents.Add(new Despawn() { Filter = new Filter(Group.AllOf, new HasTag(Subject.Self, Test.Equal, "despawn")) });
            //entity.MainComponents.Add(new TickWorld());

            IList<TimelineStep> stepsToAdd = new List<TimelineStep>(Steps);
            if (despawnPreviousEntity != null) {
                TagAdd despawnCommand = new TagAdd(new TargetSelector(Target.AllEntities) { Type = despawnPreviousEntity }, "despawn");
                if (stepsToAdd[0].Time == 0) {
                    stepsToAdd[0].Events.Insert(0, despawnCommand);
                } else {
                    stepsToAdd.Insert(0, new TimelineStep(0, despawnCommand));
                }
            }
            if (!Loop) {
                stepsToAdd.Add(new TimelineStep(Steps[Steps.Count - 1].Time + 1, new TagAdd(TargetSelector.Self, "despawn")));
            }
            AnimationTimeline animationTimeline = entity.CreateBehaviorAnimationTimeline(entity.Identifier, "animation." + entity.Identifier + ".commands", Length ?? Steps[Steps.Count - 1].Time + 5, Loop);
            animationTimeline.Timeline.AddRange(stepsToAdd);

            return entity;
        }

        public static Entity[] GenerateAll(params TimelineEntity[] timelines) {
            Entity[] generatedEntities = new Entity[timelines.Length];
            generatedEntities[0] = timelines[0].Generate();
            for (int i = 1; i < timelines.Length; i++) {
                generatedEntities[i] = timelines[i].Generate(timelines[i - 1]);
            }
            return generatedEntities;
        }
    }
}
