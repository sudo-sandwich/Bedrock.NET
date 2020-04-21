using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public static class FormatStrings {
        //stolen from https://stackoverflow.com/questions/1546113/double-to-string-conversion-without-scientific-notation because double.ToString() will convert to scientific notation, which is fucking annoying
        public const string DoubleFixedPoint = "0.###################################################################################################################################################################################################################################################################################################################################################";
    }
}
