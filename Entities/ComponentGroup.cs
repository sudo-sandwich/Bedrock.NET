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
        public IDictionary<Type, IComponent> Components { get; }

        public int Count {
            get {
                return Components.Count;
            }
        }

        public ComponentGroup(string name, params IComponent[] components) {
            Name = name;
            Components = new Dictionary<Type, IComponent>();
            //Add(components);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();
            foreach (IComponent component in Components.Values) {
                jObject.Add(component.Generate());
            }

            return new JProperty(Name, jObject);
        }

        public void Add(IComponent component) {
            if (component == null) {
                throw new ArgumentNullException(nameof(component));
            }
            if (Components.ContainsKey(component.GetType())) {
                throw new ArgumentException($"Component {component.Name} already exists in this component group.");
            }

            Components.Add(component.GetType(), component);
        }

        public void Add(params IComponent[] components) {
            foreach (IComponent component in components) {
                Add(component);
            }
        }

        public T Get<T>() where T : IComponent => (T)Components[typeof(T)];

        public bool Remove<T>() where T : IComponent {
            if (Components.ContainsKey(typeof(T))) {
                Components.Remove(typeof(T));
                return true;
            } else {
                return false;
            }
        }
    }
}
