using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class ShapedCraftingRecipe {
        public string Prefix { get; set; }
        public string Identifier { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public string Group { get; set; }

        public IList<IList<ItemKey>> Pattern { get; set; }

        public string ResultItem { get; set; }
        public string ResultData { get; set; }
        public int? ResultCount { get; set; }

        public ShapedCraftingRecipe(string prefix, string identifier) {
            Prefix = prefix;
            Identifier = identifier;
            Pattern = new List<IList<ItemKey>>() {
                new List<ItemKey>() { null, null, null },
                new List<ItemKey>() { null, null, null },
                new List<ItemKey>() { null, null, null }
            };
        }

        public JObject Generate() {
            JObject jObject = new JObject() {
                { "format_version", "1.12" }
            };

            JObject recipeShared = new JObject();
            jObject.Add(new JProperty("minecraft:recipe_shaped", recipeShared));

            recipeShared.Add(new JProperty("description", new JObject() { { "identifier", Prefix + ":" + Identifier } }));
            recipeShared.Add("tags", new JArray(Tags));

            IDictionary<ItemKey, char> uniqueItems = new Dictionary<ItemKey, char>();
            char currentChar = 'A';
            foreach (IList<ItemKey> row in Pattern) {
                foreach (ItemKey key in row) {
                    if (key != null && !uniqueItems.ContainsKey(key)) {
                        uniqueItems.Add(key, currentChar);
                        currentChar++;
                    }
                }
            }

            JArray charPattern = new JArray();
            recipeShared.Add("pattern", charPattern);
            for (int i = 0; i < Pattern.Count; i++) {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < Pattern[i].Count; j++) {
                    row.Append(Pattern[i][j] == null ? ' ' : uniqueItems[Pattern[i][j]]);
                }
                charPattern.Add(row.ToString());
            }

            JObject jsonKeys = new JObject();
            recipeShared.Add(new JProperty("key", jsonKeys));
            foreach (ItemKey item in uniqueItems.Keys) {
                jsonKeys.Add(new JProperty(uniqueItems[item].ToString(), item.ToJToken()));
            }

            JObject result = new JObject() {
                { "item", ResultItem }
            };
            recipeShared.Add(new JProperty("result", result));
            result.AddIfNotNull("data", ResultData);
            result.AddIfNotNull("count", ResultCount);

            return jObject;
        }
    }
}
