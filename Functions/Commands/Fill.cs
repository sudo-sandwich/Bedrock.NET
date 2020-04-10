using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Fill : Command {
        public Position From { get; private set; }
        public Position To { get; private set; }
        public string TileName { get; private set; }
        public int? TileData { get; private set; }
        public FillType? Type { get; private set; }
        public string ReplaceTileName { get; private set; }
        public int? ReplaceDataValue { get; private set; }

        public Fill(Position from, Position to, string tileName, int? tileData = null, FillType? type = null, string replaceTileName = null, int? replaceDataValue = null) {
            From = from;
            To = to;
            TileName = tileName;
            TileData = tileData;
            Type = type;
            ReplaceTileName = replaceTileName;
            ReplaceDataValue = replaceDataValue;
        }

        public override string ToString() {
            return CommandHelper.Build("fill", From, To, TileName, TileData, Type?.GetDescription(), ReplaceTileName, ReplaceDataValue);
        }
    }

    public enum FillType {
        [Description("destroy")]
        Destroy,
        [Description("hollow")]
        Hollow,
        [Description("keep")]
        Keep,
        [Description("outline")]
        Outline,
        [Description("replace")]
        Replace
    }
}
