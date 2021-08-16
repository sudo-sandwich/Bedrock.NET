using Bedrock.Entities.Animations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class AnimationControllerFile {
        public string Name { get; set; }
        public IReadOnlyDictionary<string, AnimationController> Controllers => _controllers;
        private Dictionary<string, AnimationController> _controllers { get; set; } = new Dictionary<string, AnimationController>();

        public AnimationControllerFile(string name) {
            Name = name;
        }

        public void Add(AnimationController ac) {
            if (Controllers.ContainsKey(ac.LongName)) {
                throw new ArgumentException($"Animation controller with long name {ac.LongName} already exists in this file.");
            }

            _controllers.Add(ac.LongName, ac);
        }

        public bool Remove(AnimationController ac) => Remove(ac.LongName);

        public bool Remove(string longName) => _controllers.Remove(longName);

        public JObject Generate() {
            JObject jObject = new JObject() {
                { "format_version", "1.10.0" }
            };

            JObject animationControllers = new JObject();
            jObject.Add(new JProperty("animation_controllers", animationControllers));

            foreach (AnimationController controller in Controllers.Values) {
                animationControllers.Add(controller.Generate());
            }

            return jObject;
        }
    }
}
