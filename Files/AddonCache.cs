using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files
{
    public class AddonCache
    {
        public int CacheID { get; set; }
        public IList<string> Functions { get; set; } = new List<string>();
        public IList<string> Entities { get; set; } = new List<string>();
        public IList<string> ServerAnimationControllers { get; set; } = new List<string>();
        public IList<string> ServerAnimationTimelines { get; set; } = new List<string>();
        public IList<string> ClientAnimationControllers { get; set; } = new List<string>();
        public IList<string> ClientAnimationTimelines { get; set; } = new List<string>();
        public IList<string> RenderControllers { get; set; } = new List<string>();
        public AddonContent AddonContent { get; set; }
    }
}
