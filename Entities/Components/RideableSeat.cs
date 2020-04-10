using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class RideableSeat : IJToken {
        public Vector3 Position { get; set; }
        public int? MinRiderCount { get; set; }
        public int? MaxRiderCount { get; set; }
        public double? RotateRiderBy { get; set; }
        public double? LockRiderRotation { get; set; }

        public RideableSeat(Vector3 position) {
            Position = position;
        }

        public RideableSeat(double x, double y, double z) : this(new Vector3(x, y, z)) { }

        public static implicit operator JObject(RideableSeat rs) {
            return rs?.ToJObject();
        }

        public static implicit operator JToken(RideableSeat rs) {
            return rs?.ToJToken();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.Add(new JProperty("position", new JArray(Position.X, Position.Y, Position.Z)));
            if (MinRiderCount != null) jObject.Add(new JProperty("min_rider_count", MinRiderCount));
            if (MaxRiderCount != null) jObject.Add(new JProperty("max_rider_count", MaxRiderCount));
            if (RotateRiderBy != null) jObject.Add(new JProperty("rotate_rider_by", RotateRiderBy));
            if (LockRiderRotation != null) jObject.Add(new JProperty("lock_rider_rotation", LockRiderRotation));

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}
