using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bedrock.Files {
    public class AddonCategory {
        public IReadOnlyList<string> Categories { get; private set; }
        public int Count => Categories.Count;
        public string CategoryPath => Path.Combine(Categories.ToArray());

        public AddonCategory(params string[] categories) {
            foreach (string category in categories) {
                if (!Regex.IsMatch(category, @"^[a-zA-Z0-9_]+$")) {
                    throw new ArgumentException("Categories must only be letters, numbers, and underscores");
                }
            }

            Categories = new List<string>(categories);
        }

        public AddonCategory Append(AddonCategory category) {
            return new AddonCategory(Categories.Concat(category.Categories).ToArray());
        }

        public override bool Equals(object obj) {
            AddonCategory ac = obj as AddonCategory;
            return ac != null && ac.Categories.SequenceEqual(Categories);
        }

        public override int GetHashCode() {
            int hash = 97;

            foreach (string category in Categories) {
                hash = hash * 113 + category.GetHashCode();
            }

            return hash;
        }

        public override string ToString() => CategoryPath;
    }
}
