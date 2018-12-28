using System;
using System.Collections.Generic;
using System.Xml;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class LEXER : IDisposable
    {
        private Dictionary<string, REG_EXP> regularExpresions;

        public LEXER(XmlDocument regEx_Xml)
        {
            getGraphsFromRegularExpresions(regEx_Xml);

            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispossing)
        {
            if (dispossing) {
                foreach (KeyValuePair<string, REG_EXP> pair in regularExpresions)
                {
                    pair.Value.Dispose();
                }
                regularExpresions.Clear();
            }
        }

        ~LEXER()
        {
            Dispose(false);
        }
    }
}
