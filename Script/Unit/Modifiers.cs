using System;

namespace Miltochess {
    public class Modifiers
    {
        public static Modifier StatModifier(string stat, string expr)
        {
            return new StatModifier();
        }
    }
}