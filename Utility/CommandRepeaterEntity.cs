using Bedrock.Entities;
using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Entities.Components.Filters;
using Bedrock.Files;
using Bedrock.Functions;
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

        public Tag WhileActive { get; private set; } //tags this entity while it is executing commands

        public CommandRepeaterEntity(string prefix, string identifier, params IEvent[] commands) : this(prefix, identifier, 0.05, commands) { }

        public CommandRepeaterEntity(string prefix, string identifier, double frequency, params IEvent[] commands) {
            AttachedEntity = new Entity(prefix, identifier);
            Frequency = frequency;
            Commands = new List<IEvent>(commands);
        }

        //creates an MCFunction with one command that will despawn this CommandRepeaterEntity ONLY if it is tagged as active. it will be tagged as active as the first command in its command sequence, then untagged after the last command in the sequence finishes.
        public MCFunction CreateActiveDespawner(Tag activeTag, string functionName) {
            WhileActive = activeTag;
            return new MCFunction(functionName, new TagAdd(new TargetSelector(AttachedEntity) { Tags = { WhileActive } }, TagManager.Despawn));
        }

        public Entity ToEntity() {
            if (Commands.Count == 0) {
                throw new InvalidOperationException("There are no commands to generate.");
            }

            Entity entity = new Entity(AttachedEntity.Prefix, AttachedEntity.Identifier) {
                IsSpawnable = false
            };
            entity.MainComponents.Add(new Despawn() { Filter = new Filter(Group.AllOf, new HasTag(Subject.Self, Test.Equal, TagManager.Despawn)) });
            //entity.MainComponents.Add(new TickWorld());

            AnimationTimeline animationTimeline = entity.CreateBehaviorAnimationTimeline(entity.Identifier, "animation." + entity.Identifier + ".commands", Frequency, true);
            TimelineStep commandsStep = new TimelineStep(0);
            if (WhileActive != null) {
                commandsStep.Events.Add(new TagAdd(TargetSelector.Self, WhileActive));
                commandsStep.Events.AddRange(Commands);
                commandsStep.Events.Add(new TagRemove(TargetSelector.Self, WhileActive));
            } else {
                commandsStep.Events.AddRange(Commands);
            }
            animationTimeline.Timeline.Add(commandsStep);

            return entity;
        }
    }
}
