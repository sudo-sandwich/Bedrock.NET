using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class SetBlock : Command {
        public Position Position { get; private set; }
        public string TileName { get; private set; }
        public int? TileData { get; private set; }
        public OldBlockHandling? Mode { get; private set; }

        public SetBlock(Position position, string tileName, int? tileData = null, OldBlockHandling? mode = null) {
            Position = position;
            TileName = tileName;
            TileData = tileData;
            Mode = mode;
        }

        public override string ToString() {
            return CommandHelper.Build("setblock", Position, TileName, TileData, Mode?.GetDescription());
        }
    }

    public enum OldBlockHandling {
        [Description("replace")]
        Replace,
        [Description("destroy")]
        Destroy,
        [Description("keep")]
        Keep
    }
}
