using Bedrock.Entities;
using Bedrock.Functions.Commands;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class TargetSelector {
        public static TargetSelector AllPlayers { get; } = new TargetSelector(Target.AllPlayers);
        public static TargetSelector AllEntities { get; } = new TargetSelector(Target.AllEntities);
        public static TargetSelector ClosestPlayer { get; } = new TargetSelector(Target.ClosestPlayer);
        public static TargetSelector RandomPlayer { get; } = new TargetSelector(Target.RandomPlayer);
        public static TargetSelector Self { get; } = new TargetSelector(Target.Self);

        public Target Target { get; set; }

        public int? Count { get; set; }
        public int? DeltaX { get; set; }
        public int? DeltaY { get; set; }
        public int? DeltaZ { get; set; }
        public IList<string> Families { get; set; } = new List<string>();
        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }
        public Mode? GameMode { get; set; }
        public string Name { get; set; }
        public double? MinRadius { get; set; }
        public double? MaxRadius { get; set; }
        private double? _minRotX;
        public double? MinRotX {
            get {
                return _minRotX;
            }
            set {
                if (value < -90 || value > 90) {
                    throw new ArgumentOutOfRangeException("MinRotX", "Must be between -90 and 90.");
                }
                _minRotX = value;
            }
        }
        private double? _maxRotX;
        public double? MaxRotX {
            get {
                return _maxRotX;
            }
            set {
                if (value < -90 || value > 90) {
                    throw new ArgumentOutOfRangeException("MaxRotX", "Must be between -90 and 90.");
                }
                _maxRotX = value;
            }
        }
        private double? _minRotY;
        public double? MinRotY {
            get {
                return _minRotY;
            }
            set {
                if (value < -180 || value > 180) {
                    throw new ArgumentOutOfRangeException("MinRotY", "Must be between -180 and 180.");
                }
                _minRotY = value;
            }
        }
        private double? _maxRotY;
        public double? MaxRotY {
            get {
                return _maxRotY;
            }
            set {
                if (value < -180 || value > 180) {
                    throw new ArgumentOutOfRangeException("MaxRotY", "Must be between -180 and 180.");
                }
                _maxRotY = value;
            }
        }
        public IList<ScoreSelector> Scores { get; set; } = new List<ScoreSelector>();
        public IList<Tag> Tags { get; set; } = new List<Tag>();
        private Entity _type;
        public Entity Type {
            get {
                return _type;
            }
            set {
                _type = value;
                _typeString = value?.FullIdentifier;
            }
        }
        private string _typeString;
        public string TypeString { 
            get {
                return _typeString;
            }
            set {
                _type = null;
                _typeString = value;
            }
        }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }

        public string RawValue { get; set; }

        public TargetSelector(Target target) {
            Target = target;
        }

        //short for new TargetSelector(Target.AllEntities) { Type = type }
        public TargetSelector(Entity type) {
            if (type == null) {
                throw new Exception("Type is null.");
            }
            Target = Target.AllEntities;
            Type = type;
        }

        //short for new TargetSelector(Target.AllEntities) { Type = type }
        public TargetSelector(string type) {
            if (type == null) {
                throw new Exception("Type is null.");
            }
            Target = Target.AllEntities;
            TypeString = type;
        }

        public override string ToString() {
            if (Target != Target.Raw) {
                IList<string> arguments = new List<string>();
                if (Count != null) arguments.Add("c = " + Count);
                if (DeltaX != null) arguments.Add("dx = " + DeltaX);
                if (DeltaY != null) arguments.Add("dy = " + DeltaY);
                if (DeltaZ != null) arguments.Add("dz = " + DeltaZ);
                if (MaxLevel != null) arguments.Add("l = " + MaxLevel);
                if (MinLevel != null) arguments.Add("lm = " + MinLevel);
                if (GameMode != null) arguments.Add("m = " + GameMode);
                if (Name != null) arguments.Add("name = " + Name);
                if (MaxRadius != null) arguments.Add("r = " + MaxRadius);
                if (MinRadius != null) arguments.Add("rm = " + MinRadius);
                if (MaxRotX != null) arguments.Add("rx = " + MaxRotX);
                if (MinRotX != null) arguments.Add("rxm = " + MinRotX);
                if (MaxRotY != null) arguments.Add("ry = " + MaxRotY);
                if (MinRotY != null) arguments.Add("rym = " + MinRotY);
                if (TypeString != null) arguments.Add("type = " + TypeString);
                if (X != null) arguments.Add("x = " + X);
                if (Y != null) arguments.Add("y = " + Y);
                if (Z != null) arguments.Add("z = " + Z);

                foreach (string family in Families) {
                    arguments.Add("family = " + family);
                }
                foreach (string tag in Tags) {
                    arguments.Add("tag = " + tag);
                }

                if (Scores.Count > 0) {
                    StringBuilder stringBuilder = new StringBuilder("scores = {");
                    foreach (ScoreSelector score in Scores) {
                        stringBuilder.Append(score.ToString());
                    }
                    stringBuilder.Append("}");
                    arguments.Add("scores = {" + string.Join(", ", Scores.Select(s => s.ToString())) + "}");
                }

                return Target.GetDescription() + (arguments.Count > 0 ? "[" + string.Join(", ", arguments) + "]" : "");
            } else {
                return RawValue;
            }
        }
    }

    public enum Target {
        [Description("@a")]
        AllPlayers,
        [Description("@e")]
        AllEntities,
        [Description("@p")]
        ClosestPlayer,
        [Description("@r")]
        RandomPlayer,
        [Description("@s")]
        Self,
        [Description("NO DESCRIPTION")]
        Raw
    }
}
