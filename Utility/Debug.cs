using Bedrock.Entities.Animations;
using Bedrock.Functions.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public static class Debug {
        public static AnimationController ACMolang(string name, string query, int maxValue) {
            AnimationController ac = new AnimationController(name, "controller.animation." + name);

            AnimationState[] states = new AnimationState[maxValue];
            AnimationStateTransition[] transitions = new AnimationStateTransition[maxValue];
            for (int i = 0; i < maxValue; i++) {
                states[i] = ac.CreateState("val_" + i);
                states[i].OnEntry.Add(new Say(query + " = " + i));
                transitions[i] = new AnimationStateTransition(states[i], query + " == " + i);
            }

            for (int i = 0; i < maxValue; i++) {
                for (int j = 0; j < maxValue; j++) {
                    if (i != j) {
                        states[i].Transitions.Add(transitions[j]);
                    }
                }
            }

            return ac;
        }
    }
}
