
namespace TCG_UML.ConfigurableParser.Lexer
{
    public class TOKEN
    {
        public string type;
        public string lexeme;

        public TOKEN(string type, string lexeme)
        {
            this.type = type;
            this.lexeme = lexeme;
        }
    }
}