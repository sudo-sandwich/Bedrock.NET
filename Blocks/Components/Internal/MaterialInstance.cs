using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components.Internal
{
    public class MaterialInstance
    {
        public string Texture { get; set; }
        public TerrainDefinition TerrainDefinition { get; set; } = null;
        public string RenderMethod { get; set; }
    }
}
