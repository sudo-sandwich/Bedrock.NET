using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Bedrock.Utility {
    public class TagManager {
        public static readonly Tag Despawn = new Tag("despawn", true);
        public const string UniqueTagPrefix = "bedrock.net_unique_tag_";
        private static readonly Regex ValidCharacters = new Regex(@"^[-_\+\.A-Za-z0-9]*$");
        public int NumUniqueTags { get; private set; }
        private HashSet<string> _tags { get; set; }
        public IReadOnlyCollection<string> Tags { 
            get {
                return _tags;
            }
        }

        public TagManager() {
            NumUniqueTags = 0;
            _tags = new HashSet<string>() { Despawn.Value };
        }

        public Tag Create(string value) {
            if (!ValidCharacters.IsMatch(value)) {
                throw new Exception("Tag has invalid characters.");
            }
            if (_tags.Contains(value)) {
                throw new Exception("Tag already exists.");
            }
            if (value.StartsWith(UniqueTagPrefix)) {
                throw new Exception("This tag is reserved by Bedrock.NET. Use a different tag.");
            }

            return new Tag(value, true);
        }

        public Tag CreateUnique() {
            NumUniqueTags++;
            return new Tag(UniqueTagPrefix + (NumUniqueTags - 1), true);
        }
    }
}
