using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Rideable : IComponent {
        public string Name {
            get {
                return "minecraft:rideable";
            }
        }

        public int? SeatCount { get; set; }
        public bool? CrouchingSkipInteract { get; set; }
        public string InteractText { get; set; }
        public IList<string> FamilyTypes { get; set; } = new List<string>();
        public int? ControllingSeat { get; set; }
        public bool? PullInEntities { get; set; }
        public bool? RiderCanInteract { get; set; }
        public IList<RideableSeat> Seats { get; set; } = new List<RideableSeat>();

        public Rideable(params RideableSeat[] seats) {
            Seats.AddRange(seats);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("seat_count", SeatCount);
            jObject.AddIfNotNull("crouching_skip_interact", CrouchingSkipInteract);
            jObject.AddIfNotNull("interact_text", InteractText);
            jObject.AddIfNotNull("controlling_seat", ControllingSeat);
            jObject.AddIfNotNull("pull_in_entities", PullInEntities);
            jObject.AddIfNotNull("rider_can_interact", RiderCanInteract);
            if (FamilyTypes != null && FamilyTypes.Count > 0) jObject.Add("family_types", new JArray(FamilyTypes));

            if (Seats != null && Seats.Count > 0) {
                jObject.Add("seats", Seats.ToJArray());
            }

            return new JProperty(Name, jObject);
        }
    }
}
