using Bedrock.Files;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class RenderController : IRenderController {
        public string Name { get; set; }
        public RenderControllerFile File { get; set; }

        public IDictionary<string, RCArray<Geometry>> GeometryArrays { get; } = new Dictionary<string, RCArray<Geometry>>();
        public IDictionary<string, RCArray<Material>> MaterialArrays { get; } = new Dictionary<string, RCArray<Material>>();
        public IDictionary<string, RCArray<Texture>> TextureArrays { get; } = new Dictionary<string, RCArray<Texture>>();
        public IDictionary<string, string> Materials { get; } = new Dictionary<string, string>();
        public IList<string> Textures { get; set; } = new List<string>();

        public string Geometry { get; set; }

        public OverlayColorMolang OverlayColor { get; set; }

        public RenderController(string name) {
            Name = name;
        }

        #pragma warning disable CA1307 // Specify StringComparison
        public void AddGeometryArray(RCArray<Geometry> geometryArray) {
            if (geometryArray == null)
                throw new ArgumentNullException($"GeometryArray cannot be null in RenderController {Name}");

            if (string.IsNullOrEmpty(geometryArray.Name))
                throw new ArgumentNullException($"Geometry array name is invalid for Render controller {Name}");

            if (!geometryArray.Name.StartsWith("Array."))
                geometryArray.Name = geometryArray.Name.Insert(0, "Array.");

            GeometryArrays.Add(geometryArray.Name, geometryArray);
        }

        public void AddMaterialArray(RCArray<Material> materialArray) {
            if (materialArray == null)
                throw new ArgumentNullException($"MaterialArray cannot be null in RenderController {Name}");

            if (string.IsNullOrEmpty(materialArray.Name))
                throw new ArgumentNullException($"Material array name is invalid for Render controller {Name}");

            if (!materialArray.Name.StartsWith("Array."))
                materialArray.Name = materialArray.Name.Insert(0, "Array.");

            MaterialArrays.Add(materialArray.Name, materialArray);
        }

        public void AddTextureArray(RCArray<Texture> textureArray) {
            if (textureArray == null)
                throw new ArgumentNullException($"TextureArray cannot be null in RenderController {Name}");

            if (string.IsNullOrEmpty(textureArray.Name))
                throw new ArgumentNullException($"Texture array name is invalid for Render controller {Name}");

            if (!textureArray.Name.StartsWith("Array."))
                textureArray.Name = textureArray.Name.Insert(0, "Array.");

            TextureArrays.Add(textureArray.Name, textureArray);
        }
        #pragma warning restore CA1307 // Specify StringComparison

        public JProperty Generate() {
            JObject jObject = new JObject();

            JObject arrays = new JObject();

            if (GeometryArrays.Count > 0) {
                JObject geometryArrays = new JObject();
                arrays.Add(new JProperty("geometries", geometryArrays));

                foreach (RCArray<Geometry> geometryArray in GeometryArrays.Values) {
                    geometryArrays.Add(geometryArray.ToJToken());
                }
            }

            if (MaterialArrays.Count > 0) {
                JObject materialArrays = new JObject();
                arrays.Add(new JProperty("materials", materialArrays));

                foreach (RCArray<Material> materialArray in MaterialArrays.Values) {
                    materialArrays.Add(materialArray.ToJToken());
                }
            }

            if (TextureArrays.Count > 0) {
                JObject textureArrays = new JObject();
                arrays.Add(new JProperty("textures", textureArrays));

                foreach (RCArray<Texture> geometryArray in TextureArrays.Values) {
                    textureArrays.Add(geometryArray.ToJToken());
                }
            }

            if (arrays.Count > 0) {
                jObject.Add(new JProperty("arrays", arrays));
            }

            jObject.Add("geometry", Geometry);
            JArray materials = new JArray();
            jObject.Add("materials", materials);

            // new 
            foreach (KeyValuePair<string, string> kvp in Materials)
                materials.Add(new JObject() {{ kvp.Key, kvp.Value }});

            jObject.Add("textures", new JArray(Textures));

            jObject.AddIfNotNull("overlay_color", OverlayColor);

            return new JProperty(Name, jObject);
        }
    }
}
