using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class AddonCatalogue<T> {
        public IDictionary<AddonCategory, ICollection<T>> Catalogue { get; private set; } = new Dictionary<AddonCategory, ICollection<T>>();

        public void Add(AddonCategory category, IEnumerable<T> newEntries) {
            ICollection<T> categoryCollection = GetOrCreateCategory(category);

            categoryCollection.AddRange(newEntries);
        }

        public void Add(AddonCategory category, params T[] newEntries) => Add(category, (IEnumerable<T>)newEntries);

        public void Add(IEnumerable<T> newEntries) => Add(AddonCategory.None, newEntries);

        public void Add(params T[] newEntries) => Add(AddonCategory.None, (IEnumerable<T>)newEntries);

        public void Add(string category, IEnumerable<T> newEntries) => Add(new AddonCategory(category), newEntries);

        public void Add(string category, params T[] newEntries) => Add(new AddonCategory(category), (IEnumerable<T>)newEntries);

        public ICollection<T> GetOrCreateCategory(AddonCategory category) {
            if (!Catalogue.ContainsKey(category)) {
                Catalogue.Add(category, new HashSet<T>());
            }
            return Catalogue[category];
        }

        public ICollection<T> GetOrCreateCategory(string category) => GetOrCreateCategory(new AddonCategory(category));

        public void Merge(AddonCatalogue<T> other) => Merge(other, new AddonCategory());

        public void Merge(AddonCatalogue<T> other, AddonCategory category) {
            foreach ((AddonCategory otherCategory, ICollection<T> otherEntries) in other.Catalogue) {
                AddonCategory newCategory = category.Append(otherCategory);
                GetOrCreateCategory(newCategory).AddRange(otherEntries);
            }
        }

        public ICollection<T> this[AddonCategory category] {
            get => Catalogue[category];
        }

        public ICollection<T> this[string category] {
            get => this[new AddonCategory(category)];
        }
    }
}
