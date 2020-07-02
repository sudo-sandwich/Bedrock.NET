using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities {
    public class Entity {
        public string Prefix { get; set; }
        public string Identifier { get; set; }
        public string RuntimeIdentifier { get; set; }

        public string FormatVersion { get; set; } = "1.13.0";
        public bool IsSpawnable { get; set; } = true;
        public bool IsSummonable { get; set; } = true;
        public bool? IsExperimental { get; set; }

        public ISpawnEgg SpawnEgg { get; set; }

        public string Geometry { get; set; }
        public string Material { get; set; }
        public string Texture { get; set; }

        public IList<IAnimateScript> BehaviorPackAnimations { get; } = new List<IAnimateScript>();
        public IList<IAnimateScript> ResourcePackAnimations { get; } = new List<IAnimateScript>();
        public IList<string> BehaviorPreAnimationScripts { get; } = new List<string>();
        public IList<string> ResourcePreAnimationScripts { get; } = new List<string>();

        public IList<ComponentGroup> ComponentGroups { get; } = new List<ComponentGroup>();
        public ComponentGroup MainComponents { get; } = new ComponentGroup("components");

        public IList<EntityEvent> Events { get; } = new List<EntityEvent>();

        //built in events
        public EntityEvent EntityBorn { get; } = new EntityEvent("minecraft:entity_born");
        public EntityEvent EntitySpawned { get; } = new EntityEvent("minecraft:entity_spawned");
        public EntityEvent EntityTransformed { get; } = new EntityEvent("minecraft:entity_transformed");
        public EntityEvent OnPrime { get; } = new EntityEvent("minecraft:on_prime");

        //DEPRECATED, use Entity(string prefix, string identifier) instead. THIS WILL BE REMOVED IN A FUTURE UPDATE
        public Entity() { }

        public Entity(string prefix, string identifier) {
            Prefix = prefix;
            Identifier = identifier;
        }

        public bool HasBehaviorPackAnimationTimelines {
            get {
                foreach (IAnimateScript animateScript in BehaviorPackAnimations) {
                    if (animateScript is AnimationTimeline) {
                        return true;
                    }
                    foreach (IAnimation animation in animateScript.Animations) {
                        if (animation is AnimationTimeline) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public bool HasBehaviorPackAnimationControllers {
            get {
                foreach (IAnimateScript animateScript in BehaviorPackAnimations) {
                    if (animateScript is AnimationController) {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool HasResourcePackAnimationControllers {
            get {
                foreach (IAnimateScript animateScript in ResourcePackAnimations) {
                    if (animateScript is AnimationController) {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool HasClientEntity {
            get {
                return Geometry != null && Material != null && Texture != null;
            }
        }
        //for right now, render controllers and client entities should always be created together, so if there is a client entity, there is also a render controller
        public bool HasRenderControllers {
            get {
                return HasClientEntity;
            }
        }

        public string FullIdentifier {
            get {
                return Prefix + ":" + Identifier;
            }
        }

        public ComponentGroup CreateComponentGroup(string name, params IComponent[] components) {
            ComponentGroup cg = new ComponentGroup(name, components);
            ComponentGroups.Add(cg);
            return cg;
        }

        public EntityEvent CreateEvent(string name) {
            EntityEvent ee = new EntityEvent(name);
            Events.Add(ee);
            return ee;
        }

        public EntityEvent CreateEvent(string name, ComponentGroup groupToAdd) {
            EntityEvent ee = new EntityEvent(name, groupToAdd);
            Events.Add(ee);
            return ee;
        }

        public EntityEvent CreateEvent(string name, ComponentGroup groupToAdd, ComponentGroup groupToRemove) {
            EntityEvent ee = new EntityEvent(name, groupToAdd, groupToRemove);
            Events.Add(ee);
            return ee;
        }

        public AnimationTimeline CreateBehaviorAnimationTimeline(string shortName, string longName) {
            AnimationTimeline at = new AnimationTimeline(shortName, longName);
            BehaviorPackAnimations.Add(at);
            return at;
        }

        public AnimationTimeline CreateBehaviorAnimationTimeline(string shortName, string longName, double length, bool loop) {
            AnimationTimeline at = new AnimationTimeline(shortName, longName, length, loop);
            BehaviorPackAnimations.Add(at);
            return at;
        }

        public AnimationController CreateBehaviorAnimationController(string shortName, string longName) {
            AnimationController ac = new AnimationController(shortName, longName);
            BehaviorPackAnimations.Add(ac);
            return ac;
        }

        public AnimationController CreateResourceAnimationController(string shortName, string longName) {
            AnimationController ac = new AnimationController(shortName, longName);
            ResourcePackAnimations.Add(ac);
            return ac;
        }

        public JObject GenerateBehavior() {
            JObject jObject = new JObject();

            jObject.Add("format_version", FormatVersion);
            JObject minecraftEntity = new JObject();
            jObject.Add(new JProperty("minecraft:entity", minecraftEntity));

            JObject description = new JObject();
            minecraftEntity.Add(new JProperty("description", description));
            description.Add("identifier", FullIdentifier);
            description.AddIfNotNull("runtime_identifier", RuntimeIdentifier);
            description.Add("is_spawnable", IsSpawnable);
            description.Add("is_summonable", IsSummonable);
            description.AddIfNotNull("is_experimental", IsExperimental);

            if (BehaviorPackAnimations.Count > 0) {
                JObject animations = new JObject();
                description.Add(new JProperty("animations", animations));

                JObject scripts = new JObject();
                description.Add(new JProperty("scripts", scripts));
                JArray animate = new JArray();
                scripts.Add("animate", animate);

                ISet<IAnimation> animationSet = new HashSet<IAnimation>();
                foreach (IAnimateScript animateScript in BehaviorPackAnimations) {
                    foreach (IAnimation animation in animateScript.Animations) {
                        animationSet.Add(animation);
                    }

                    animate.Add(animateScript.GenerateScript());
                }

                foreach (IAnimation animation in animationSet) {
                    animations.Add(animation.ShortName, animation.LongName);
                }
            }

            if (ComponentGroups.Count > 0) {
                JObject componentGroups = new JObject();
                minecraftEntity.Add(new JProperty("component_groups", componentGroups));
                foreach (ComponentGroup componentGroup in ComponentGroups.OrderBy(cg => cg.Name)) {
                    componentGroups.Add(componentGroup.Generate());
                }
            }

            if (MainComponents.Count > 0) {
                JObject components = new JObject();
                minecraftEntity.Add(new JProperty("components", components));
                foreach (IComponent component in MainComponents.Components.OrderBy(c => c.Name)) {
                    components.Add(component.Generate());
                }
            }

            IList<EntityEvent> events = new List<EntityEvent>();
            if (EntityBorn.ComponentsToAdd.Count > 0 || EntityBorn.ComponentsToRemove.Count > 0) events.Add(EntityBorn);
            if (EntitySpawned.ComponentsToAdd.Count > 0 || EntitySpawned.ComponentsToRemove.Count > 0) events.Add(EntitySpawned);
            if (EntityTransformed.ComponentsToAdd.Count > 0 || EntityTransformed.ComponentsToRemove.Count > 0) events.Add(EntityTransformed);
            if (OnPrime.ComponentsToAdd.Count > 0 || OnPrime.ComponentsToRemove.Count > 0) events.Add(OnPrime);
            events.AddRange(Events);

            if (events.Count > 0) {
                JObject eventsJO = new JObject();
                minecraftEntity.Add(new JProperty("events", eventsJO));
                foreach (EntityEvent eventToAdd in events) {
                    eventsJO.Add(eventToAdd.Generate());
                }
            }

            return jObject;
        }

        //super incomplete
        public JObject GenerateClientEntity() {
            JObject jObject = new JObject();

            jObject.Add("format_version", "1.10.0");
            JObject minecraftClientEntity = new JObject();
            jObject.Add(new JProperty("minecraft:client_entity", minecraftClientEntity));

            JObject description = new JObject();
            minecraftClientEntity.Add(new JProperty("description", description));

            description.Add("identifier", FullIdentifier);
            if (SpawnEgg != null) {
                description.Add(new JProperty("spawn_egg", SpawnEgg.ToJObject()));
            }
            description.Add("render_controllers", new JArray("controller.render." + Identifier));
            description.Add(new JProperty("geometry", new JObject() { { "default", Geometry } }));
            description.Add(new JProperty("materials", new JObject() { { "default", Material } }));
            description.Add(new JProperty("textures", new JObject() { { "default", Texture } }));

            if (ResourcePackAnimations.Count > 0) {
                JObject animations = new JObject();
                description.Add(new JProperty("animations", animations));

                JObject scripts = new JObject();
                description.Add(new JProperty("scripts", scripts));
                JArray animate = new JArray();
                scripts.Add("animate", animate);

                ISet<IAnimation> animationSet = new HashSet<IAnimation>();
                ISet<ParticleDescription> particleSet = new HashSet<ParticleDescription>();
                foreach (IAnimateScript animateScript in ResourcePackAnimations) {
                    foreach (IAnimation animation in animateScript.Animations) {
                        animationSet.Add(animation);

                        if (animation is AnimationController) {
                            foreach (AnimationState state in ((AnimationController)animation).States) {
                                foreach (ParticleEffect effect in state.ParticleEffects) {
                                    particleSet.Add(effect.Particle);
                                }
                            }
                        }
                    }

                    animate.Add(animateScript.GenerateScript());
                }

                if (ResourcePreAnimationScripts.Count > 0) scripts.Add("pre_animation", new JArray(ResourcePreAnimationScripts));

                foreach (IAnimation animation in animationSet) {
                    animations.Add(animation.ShortName, animation.LongName);
                }

                if (particleSet.Count > 0) {
                    JObject particleEffects = new JObject();
                    description.Add(new JProperty("particle_effects", particleEffects));
                    
                    foreach (ParticleDescription particleDescription in particleSet) {
                        particleEffects.Add(particleDescription.ShortName, particleDescription.LongName);
                    }
                }
            }

            return jObject;
        }

        //super incomplete
        public JObject GenerateRenderControllers() {
            JObject jObject = new JObject();

            jObject.Add("format_version", "1.10.0");
            JObject renderControllers = new JObject();
            jObject.Add(new JProperty("render_controllers", renderControllers));

            JObject defaultRenderController = new JObject();
            renderControllers.Add(new JProperty("controller.render." + Identifier, defaultRenderController));

            defaultRenderController.Add("geometry", "Geometry.default");
            defaultRenderController.Add("materials", new JArray(new JObject() { { "*", "Material.default" } }));
            defaultRenderController.Add("textures", new JArray("Texture.default"));

            return jObject;
        }

        public JObject GenerateBehaviorPackAnimationTimelines() {
            JObject jObject = new JObject();
            jObject.Add("format_version", "1.8.0");
            JObject animations = new JObject();
            jObject.Add(new JProperty("animations", animations));

            ISet<AnimationTimeline> animationTimelines = new HashSet<AnimationTimeline>();
            foreach (IAnimateScript animateScript in BehaviorPackAnimations) {
                AnimationTimeline animationTimeline = animateScript as AnimationTimeline;
                if (animationTimeline != null) {
                    animationTimelines.Add(animationTimeline);
                }
                foreach (IAnimation animation in animateScript.Animations) {
                    animationTimeline = animation as AnimationTimeline;
                    if (animationTimeline != null) {
                        animationTimelines.Add(animationTimeline);
                    }
                }
            }

            foreach (AnimationTimeline animationTimeline in animationTimelines) {
                animations.Add(animationTimeline.Generate());
            }

            return jObject;
        }

        public JObject GenerateBehaviorPackAnimationControllers() {
            JObject jObject = new JObject();
            jObject.Add("format_version", "1.10.0");
            JObject animationControllersJObject = new JObject();
            jObject.Add(new JProperty("animation_controllers", animationControllersJObject));

            foreach (IAnimateScript animateScript in BehaviorPackAnimations) {
                AnimationController animationController = animateScript as AnimationController;
                if (animationController != null) {
                    animationControllersJObject.Add(animationController.Generate());
                }
            }

            return jObject;
        }

        public JObject GenerateResourcePackAnimationControllers() {
            JObject jObject = new JObject();
            jObject.Add("format_version", "1.10.0");
            JObject animationControllersJObject = new JObject();
            jObject.Add(new JProperty("animation_controllers", animationControllersJObject));

            foreach (IAnimateScript animateScript in ResourcePackAnimations) {
                AnimationController animationController = animateScript as AnimationController;
                if (animationController != null) {
                    animationControllersJObject.Add(animationController.Generate());
                }
            }

            return jObject;
        }
    }
}
