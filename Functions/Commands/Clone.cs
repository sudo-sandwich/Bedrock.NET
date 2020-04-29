using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Clone : Command {
        public Position Begin { get; private set; }
        public Position End { get; private set; }
        public Position Destination { get; private set; }
        public MaskMode? MaskMode { get; private set; }
        public CloneMode? CloneMode { get; private set; }
        public string TileName { get; set; }
        public int? TileData { get; set; }

        public Clone(Position begin, Position end, Position destination, MaskMode? maskMode = null, CloneMode? cloneMode = null, string tileName = null, int? tileData = null) {
            Begin = begin;
            End = end;
            Destination = destination;
            MaskMode = maskMode;
            CloneMode = cloneMode;
            TileName = tileName;
            TileData = tileData;
        }

        public override string ToString() {
            return CommandHelper.Build("clone", Begin, End, Destination, MaskMode?.GetDescription(), CloneMode?.GetDescription(), TileName, TileData);
        }
    }

    public enum MaskMode {
        [Description("replace")]
        Replace,
        [Description("masked")]
        Masked,
        [Description("filtered")]
        Filtered
    }

    public enum CloneMode {
        [Description("force")]
        Force,
        [Description("move")]
        Move,
        [Description("normal")]
        Normal,
    }
}
