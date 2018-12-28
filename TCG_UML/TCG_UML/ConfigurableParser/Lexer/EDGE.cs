using System;

namespace TCG_UML.ConfigurableParser.Lexer
{
    public partial class EDGE : IDisposable
    {
        public char transitionCharacter = 'e';
        public NODE nextNode;

        public EDGE(char transitionChar, NODE next)
        {
            this.transitionCharacter = transitionChar;
            this.nextNode = next;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispossing)
        {
            if (dispossing)
            {
                //nextNode.Dispose();
            }
        }

        ~EDGE()
        {
            Dispose(false);
        }

    }
}
