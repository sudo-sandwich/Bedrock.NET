using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public static class CommandHelper {
        //builds a command, adding spaces between each argument until it reaches a null argument, then stops
        public static string Build(params object[] arguments) {
            StringBuilder stringBuilder = new StringBuilder();
            IEnumerator enumerator = arguments.GetEnumerator();
            while (enumerator.MoveNext() && enumerator.Current != null) {
                stringBuilder.Append(enumerator.Current.ToString() + " ");
            }
            stringBuilder.Length--; //remove the last space from the string
            return stringBuilder.ToString();
        }
    }
}
