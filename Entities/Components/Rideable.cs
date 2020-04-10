using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Rideable : IComponent {
        public string Name {
            get {
                return "minecraft:rideable";
            }
        }

        public int? SeatCount { get; set; }
        public bool? CrouchingSkipInteract { get; set; }
        public string InteractText { get; set; }
        public string[] FamilyTypes { get; set; }
        public int? ControllingSeat { get; set; }
        public bool? PullInEntities { get; set; }
        public bool? RiderCanInteract { get; set; }
        public RideableSeat[] Seats { get; set; }

        public Rideable(params RideableSeat[] seats) {
            Seats = seats;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("seat_count", SeatCount);
            jObject.AddIfNotNull("crouching_skip_interact", CrouchingSkipInteract);
            jObject.AddIfNotNull("interact_text", InteractText);
            jObject.AddIfNotNull("controlling_seat", ControllingSeat);
            jObject.AddIfNotNull("pull_in_entities", PullInEntities);
            jObject.AddIfNotNull("rider_can_interact", RiderCanInteract);
            if (FamilyTypes != null && FamilyTypes.Length > 0) jObject.Add("family_types", new JArray(FamilyTypes));
            if (Seats != null && Seats.Length > 0) jObject.Add("seats", JArray.FromObject(Array.ConvertAll(Seats, item => (JObject)item)));

            return new JProperty(Name, jObject);
        }
    }
}
