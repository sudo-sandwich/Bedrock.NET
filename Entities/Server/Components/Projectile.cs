using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Projectile : IComponent {
        public string Name => "minecraft:projectile";

        // all of these are copied directly from the 1.16.20.3 documentation, but in classic mojang fashion the actual usage of this component is very different from what the documentation states, so I'm only going to add what I need, when I need it.
        //public double? AngleOffset { get; set; }
        //public bool? CatchFire { get; set; }
        //public bool? CritParticleOnHurt { get; set; }
        //public bool? DestroyOnHurt { get; set; }
        //public string Filter { get; set; }
        //public bool? FireAffectedByGriefing { get; set; }
        public double? Gravity { get; set; }
        //public string HitSound { get; set; }
        //public bool? Homing { get; set; }
        public double? Inertia { get; set; }
        //public bool? IsDangerous { get; set; }
        //public bool? Knockback { get; set; }
        //public bool? Lightning { get; set; }
        public double? LiquidInertia { get; set; }
        //public bool? MultipleTargets { get; set; }
        public Vector3? Offset { get; set; }
        //public double? OnFireTime { get; set; }
        //public string Particle { get; set; }
        //public int? PotionEffect { get; set; }
        public double? Power { get; set; }
        //public bool? ReflectOnHurt { get; set; }
        //public bool? SemiRandomDiffDamage { get; set; }
        //public string ShootSound { get; set; }
        //public bool? ShootTarget { get; set; }
        public bool? ShouldBounce { get; set; }
        //public bool? SplashPotion { get; set; }
        //public double? SplashRange { get; set; }
        //public double? UncertaintyBase { get; set; }
        //public double? UncertaintyMultiplier { get; set; }
        
        // these are components not listed in the documentation, but are used in the vanilla behavior pack
        public int? Anchor { get; set; }
        public JObject OnHit { get; set; } // this component seems really complicated and there's no documentation for it so we'll just have to hard code every time we want to use it

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("gravity", Gravity);
            jObject.AddIfNotNull("inertia", Inertia);
            jObject.AddIfNotNull("liquid_inertia", LiquidInertia);
            jObject.AddIfNotNull("offset", Offset?.ToJArray());
            jObject.AddIfNotNull("power", Power);
            jObject.AddIfNotNull("should_bounce", ShouldBounce);

            jObject.AddIfNotNull("anchor", Anchor);
            jObject.AddIfNotNull("on_hit", OnHit);

            return new JProperty(Name, jObject);
        }
    }
}
