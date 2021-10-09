using Bedrock.Entities.Animations;
using Bedrock.Files;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class ClientEntity {
        public Entity Parent { get; private set; }
        public string Prefix => Parent.Prefix;
        public string Identifier => Parent.Identifier;
        public string FullIdentifier => Parent.FullIdentifier;

        private Dictionary<string, Geometry> _geometries { get; set; } = new Dictionary<string, Geometry>();
        public IReadOnlyDictionary<string, Geometry> Geometries => _geometries;
        private Dictionary<string, Material> _materials { get; set; } = new Dictionary<string, Material>();
        public IReadOnlyDictionary<string, Material> Materials => _materials;
        private Dictionary<string, Texture> _textures { get; set; } = new Dictionary<string, Texture>();
        public IReadOnlyDictionary<string, Texture> Textures => _textures;

        public RenderControllerFile RenderControllerFile { get; }
        public IDictionary<IRenderController, string> RenderControllers { get; set; } = new Dictionary<IRenderController, string>();

        public ISpawnEgg SpawnEgg { get; set; }

        public AnimationControllerFile AnimationControllerFile { get; }
        public AnimationTimelineFile AnimationTimelineFile { get; }
        public IList<IAnimation> Animations { get; } = new List<IAnimation>();
        public IList<AnimationBlend> AnimateScripts { get; } = new List<AnimationBlend>();
        public IList<string> InitializeScripts { get; } = new List<string>();
        public IList<string> PreAnimationScripts { get; } = new List<string>();

        public double? GeometryScale { get; set; }
        public bool? EnableAttachables { get; set; }

        internal ClientEntity(Entity parent) {
            Parent = parent;
            RenderControllerFile = new RenderControllerFile(parent.Identifier);
            AnimationControllerFile = new AnimationControllerFile(parent.Identifier);
            AnimationTimelineFile = new AnimationTimelineFile(parent.Identifier);
        }

        public RenderController CreateRenderController(string name) {
            RenderController rc = new RenderController(name);
            RenderControllerFile.Add(rc);
            AddRenderController(rc);
            return rc;
        }

        public void AddGeometry(Geometry geometry) {
            if (Geometries.ContainsKey(geometry.ShortName)) {
                throw new ArgumentException($"Geometry with short name {geometry.ShortName} already exists on this entity.");
            }

            _geometries.Add(geometry.ShortName, geometry);
        }

        public void AddGeometry(string shortName, string longName) => AddGeometry(new Geometry(shortName, longName));

        public void AddGeometryArray(RCArray<Geometry> geometries) {
            foreach (Geometry geometry in geometries.Entries) {
                AddGeometry(geometry);
            }
        }

        public void AddMaterial(Material material) {
            if (Materials.ContainsKey(material.ShortName)) {
                throw new ArgumentException($"Material with short name {material.ShortName} already exists on this entity.");
            }

            _materials.Add(material.ShortName, material);
        }

        public void AddMaterial(string shortName, string longName) => AddMaterial(new Material(shortName, longName));

        public void AddMaterialArray(RCArray<Material> materials) {
            foreach (Material material in materials.Entries) {
                AddMaterial(material);
            }
        }

        public void AddTexture(Texture texture) {
            if (Textures.ContainsKey(texture.ShortName)) {
                throw new ArgumentException($"Geometry with short name {texture.ShortName} already exists on this entity.");
            }

            _textures.Add(texture.ShortName, texture);
        }

        public void AddTexture(string shortName, string longName) => AddTexture(new Texture(shortName, longName));

        public void AddTextureArray(RCArray<Texture> textures) {
            foreach (Texture texture in textures.Entries) {
                AddTexture(texture);
            }
        }

        public void AddRenderController(IRenderController renderController, string molang = null) {
            RenderControllers.Add(renderController, molang);
        }

        public AnimationController CreateRootController(string shortName, string longName, string query = null) {
            AnimationController ac = new AnimationController(shortName, longName);
            AnimationControllerFile.Add(ac);
            AddRootAnimation(ac, query);
            return ac;
        }

        public AnimationTimeline CreateRootTimeline(string shortName, string longName, double length, bool loop, string query = null) {
            AnimationTimeline at = new AnimationTimeline(shortName, longName, length, loop);
            AnimationTimelineFile.Add(at);
            AddRootAnimation(at, query);
            return at;
        }

        public void AddRootAnimation(IAnimation anim, string query = null) {
            Animations.Add(anim);
            AnimateScripts.Add(new AnimationBlend(anim, query));
        }

        public bool RemoveGeometry(Geometry geometry) => _geometries.Remove(geometry.ShortName);

        public bool RemoveMaterial(Material material) => _materials.Remove(material.ShortName);

        public bool RemoveTexture(Texture texture) => _textures.Remove(texture.ShortName);

        public bool RemoveRenderController(IRenderController renderController) => RenderControllers.Remove(renderController);

        public JObject Generate() {
            JObject jObject = new JObject();

            jObject.Add("format_version", "1.10.0");
            JObject minecraftClientEntity = new JObject();
            jObject.Add(new JProperty("minecraft:client_entity", minecraftClientEntity));

            JObject description = new JObject();
            minecraftClientEntity.Add(new JProperty("description", description));

            description.Add("identifier", FullIdentifier);

            if (Geometries.Count > 0) {
                JObject geometries = new JObject();
                description.Add("geometry", geometries);
                foreach (Geometry geometry in Geometries.Values) {
                    geometries.Add(geometry.ShortName, geometry.LongName);
                }
            }
            if (Materials.Count > 0) {
                JObject materials = new JObject();
                description.Add("materials", materials);
                foreach (Material material in Materials.Values) {
                    materials.Add(material.ShortName, material.LongName);
                }
            }
            if (Textures.Count > 0) {
                JObject textures = new JObject();
                description.Add("textures", textures);
                foreach (Texture texture in Textures.Values) {
                    textures.Add(texture.ShortName, texture.LongName);
                }
            }

            Dictionary<string, string> particleNames = new Dictionary<string, string>();
            foreach (IAnimation animation in Animations) {
                foreach (ParticleDescription pd in AnimationUtil.GetNestedParticles(animation)) {
                    if (!particleNames.ContainsKey(pd.ShortName)) {
                        particleNames.Add(pd.ShortName, pd.LongName);
                    } else if (particleNames[pd.ShortName] != pd.LongName) {
                        throw new Exception($"Particles with short name {pd.ShortName} refer to different particle effects ({particleNames[pd.ShortName]}, {pd.LongName}).");
                    }
                }
            }
            if (particleNames.Count > 0) {
                description.Add(new JProperty("particle_effects", JObject.FromObject(particleNames)));
            }

            JObject scripts = EntityUtil.AddAnimations(description, Animations, AnimateScripts);

            if (scripts == null) {
                scripts = new JObject();
            }

            scripts.AddIfNotNull("scale", GeometryScale);

            if (InitializeScripts.Count > 0) {
                JArray initialize = new JArray();
                scripts.Add("initialize", initialize);
                foreach (string initializeScript in InitializeScripts) {
                    initialize.Add(initializeScript);
                }
            }

            if (PreAnimationScripts.Count > 0) {
                JArray preAnimation = new JArray();
                scripts.Add("pre_animation", preAnimation);
                foreach (string preAnimationScript in PreAnimationScripts) {
                    preAnimation.Add(preAnimationScript);
                }
            }

            if (scripts.Count > 0 && !description.ContainsKey("scripts")) {
                description.Add(new JProperty("scripts", scripts));
            }

            if (RenderControllers.Count > 0) {
                JArray renderControllers = new JArray();
                description.Add("render_controllers", renderControllers);
                foreach ((IRenderController renderController, string blendQuery) in RenderControllers) {
                    if (blendQuery == null) {
                        renderControllers.Add(renderController.Name);
                    } else {
                        renderControllers.Add(new JObject() { { renderController.Name, blendQuery } });
                    }
                }
            }

            description.AddIfNotNull("spawn_egg", SpawnEgg);
            description.AddIfNotNull("enable_attachables", EnableAttachables);

            return jObject;
        }
    }
}
