using System;

namespace TCG_UML.ConfigurableParser.SyntaxAnalyzer
{
    public enum SYMBOL_TYPE
    {
        NON_TERMINAL,
        TERMINAL
    };

    public partial class SYMBOL : IEquatable<SYMBOL>
    {
        public string id;
        public SYMBOL_TYPE type;

        public SYMBOL(string id, SYMBOL_TYPE type)
        {
            this.id = id;
            this.type = type;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SYMBOL);
        }

        public bool Equals(SYMBOL s)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(s, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, s))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != s.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (id == s.id) && (type == s.type);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(SYMBOL lhs, SYMBOL rhs)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SYMBOL lhs, SYMBOL rhs)
        {
            return !(lhs == rhs);
        }

    }
}