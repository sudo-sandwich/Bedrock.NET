using Bedrock.Entities.Client;
using Bedrock.Entities.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities {
    public class Entity {
        public string Prefix { get; set; }
        public string Identifier { get; set; }
        public string FullIdentifier => $"{Prefix}:{Identifier}";

        public ServerEntity Server { get; set; }
        public ClientEntity Client { get; set; }

        public Entity(string prefix, string identifier) {
            Prefix = prefix;
            Identifier = identifier;
        }

        public ServerEntity CreateServer() {
            if (Server != null) {
                throw new Exception("Server entity already exists.");
            }

            Server = new ServerEntity(this);
            return Server;
        }

        public ClientEntity CreateClient() {
            if (Client != null) {
                throw new Exception("Client entity already exists.");
            }

            Client = new ClientEntity(this);
            return Client;
        }
    }
}
