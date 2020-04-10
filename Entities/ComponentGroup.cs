using Bedrock.Entities.Components;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities {
    public class ComponentGroup {
        public string Name { get; set; }
        public IList<IComponent> Components { get; } = new List<IComponent>();

        public int Count {
            get {
                return Components.Count;
            }
        }

        public ComponentGroup(string name, params IComponent[] components) {
            Name = name;
            Components = new List<IComponent>(components);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();
            foreach (IComponent component in Components.OrderBy(c => c.Name)) {
                jObject.Add(component.Generate());
            }

            return new JProperty(Name, jObject);
        }

        public void Add(params IComponent[] components) {
            Components.AddRange(components);
        }
    }
}
