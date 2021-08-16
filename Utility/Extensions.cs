using Bedrock.Entities.Server.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Bedrock.Utility {
    public static class Extensions {
        public static void AddIfNotNull(this JObject jObject, JProperty jProperty) {
            if (jProperty != null) {
                jObject?.Add(jProperty);
            }
        }
        public static void AddIfNotNull(this JObject jObject, string name, object content) {
            if (content != null) {
                jObject?.Add(new JProperty(name, content));
            }
        }
        public static void AddIfNotNull(this JObject jObject, string name, IJToken content) {
            if (content != null) {
                jObject?.Add(new JProperty(name, content.ToJToken()));
            }
        }
        public static void AddIfNotNull(this JObject jObject, IFilter content) {
            if (content != null) {
                jObject?.Add(content.ToJProperty());
            }
        }

        public static void AddRange<T>(this ICollection<T> collection, params T[] elements) {
            foreach (T element in elements) {
                collection?.Add(element);
            }
        }
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable) {
            if (enumerable == null) {
                throw new ArgumentNullException("Enumerable cannot be null.");
            }
            foreach (T element in enumerable) {
                collection?.Add(element);
            }
        }

        //stolen from https://stackoverflow.com/a/1415187/7787764
        public static string GetDescription(this Enum value) {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null) {
                FieldInfo field = type.GetField(name);
                if (field != null) {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null) {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static void Shuffle<T>(this IList<T> list) {
            Shuffle(list, new Random());
        }

        public static void Shuffle<T>(this IList<T> list, int seed) {
            Shuffle(list, new Random(seed));
        }

        public static void Shuffle<T>(this IList<T> list, Random random) {
            if (list != null && random != null) {
                for (int i = list.Count - 1; i > 1; i--) {
                    int randIndex = random.Next(i + 1);
                    T temp = list[randIndex];
                    list[randIndex] = list[i];
                    list[i] = temp;
                }
            }
        }

        //converts a list of IJToken to a list of JToken
        public static JArray ToJArray<T>(this ICollection<T> collection) where T : IJToken {
            if (collection != null) {
                JArray jArray = new JArray();
                foreach (T element in collection) {
                    jArray.Add(element.ToJToken());
                }
                return jArray;
            } else {
                return null;
            }
        }
    }
}
