using Bedrock.Entities.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class RenderControllerFile {
        public string Name { get; set; }
        public IReadOnlyDictionary<string, RenderController> Controllers => _renderControllers;
        private Dictionary<string, RenderController> _renderControllers { get; set; } = new Dictionary<string, RenderController>();

        public RenderControllerFile(string name) {
            Name = name;
        }

        public void Add(RenderController rc) {
            if (Controllers.ContainsKey(rc.Name)) {
                throw new ArgumentException($"Render controller with name {rc.Name} already exists in this file.");
            }

            _renderControllers.Add(rc.Name, rc);
        }

        public bool Remove(RenderController ac) => Remove(ac.Name);

        public bool Remove(string name) => _renderControllers.Remove(name);

        public JObject Generate() {
            JObject jObject = new JObject() {
                { "format_version", "1.8.0" }
            };

            JObject animations = new JObject();
            jObject.Add(new JProperty("animations", animations));

            foreach (RenderController animation in Controllers.Values) {
                animations.Add(animation.Generate());
            }

            return jObject;
        }
    }
}
