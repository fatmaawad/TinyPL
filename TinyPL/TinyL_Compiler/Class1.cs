using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public enum TOKEN_ENUM
{

    STATE_READY = -1,
    STATE_ACCEPT = -2,
    STATE_FAIL = -3,

    TOKEN_SKIP = -1,
    TOKEN_EOF = -2,

    TOKEN_INT = 0,
    TOKEN_STRING = 1,
    TOKEN_FLOAT = 2,
    TOKEN_IDENTIFIER = 3,
    TOKEN_RPAREN = 4,
    TOKEN_LBRACE = 5,
    TOKEN_RBRACE = 6,

    TOKEN_PLUS_OPERATOR = 7,  //+
    TOKEN_MINUS_OPERATOR = 8, //-
    TOKEN_DIVIDE_OPERATOR = 9, // /
    TOKEN_MULTIPLY_OPERATOR = 10, //*
    TOKEN_COMMA = 11,//,
    TOKEN_BINDING = 12,//:=
    TOKEN_EQUALITY_OPERATOR = 13,//=
    TOKEN_LESS_THAN = 14, //<
    TOKEN_ANDING = 15,//&&
    TOKEN_ORING = 16,//||
    TOKEN_IF = 17,//
    TOKEN_THEN = 18,
    TOKEN_ELSE = 19,//
    TOKEN_ElseIf = 20,//
    TOKEN_EndL = 21, //
    TOKEN_READ = 22,
    TOKEN_WRITE = 23,
    TOKEN_REPEAT = 24,
    TOKEN_UNTIL = 25,
    TOKEN_RETURN = 26,
    TOKEN_SEMICOLON=27,
    TOKEN_DOT=28,
        TOKEN_GREATER_THAN=30,
        TOKEN_NOT_EQUAL=31


}


namespace TinyL_compiler
{
    public struct Token  //Calss or Struct???
    {
        public string _lexeme;
        public TOKEN_ENUM _type;
    }

    public class Scanner
    {
        string SourceCode; //input
        int _p1, _p2;
        int _state;

        public List<Token> _Tokens= new List<Token>();
        Dictionary<string, TOKEN_ENUM> ReservedWords = new Dictionary<string, TOKEN_ENUM>();
        Dictionary<string, TOKEN_ENUM> Operators = new Dictionary<string, TOKEN_ENUM>();

        //regular expressions
        readonly Regex NumberRegex = new Regex(@"^[0-9]+(\.[0-9]*)?$", RegexOptions.Compiled);
        readonly Regex StringRegex = new Regex("^\"[^\"]*\"$", RegexOptions.Compiled);
        readonly Regex CommentRegex = new Regex(@"^/\*([^*]|(\*+[^/]))*\*/$", RegexOptions.Compiled); /**/ /*/**/
        readonly Regex IdentifierRegex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$", RegexOptions.Compiled);


        //Ctor
        public Scanner()
        {
            ReservedWords.Add("IF", TOKEN_ENUM.TOKEN_IF);
            ReservedWords.Add("ELSE", TOKEN_ENUM.TOKEN_ELSE);
            ReservedWords.Add("ELSEIF", TOKEN_ENUM.TOKEN_ElseIf);
            ReservedWords.Add("ENDL", TOKEN_ENUM.TOKEN_EndL);
            ReservedWords.Add("FLOAT", TOKEN_ENUM.TOKEN_FLOAT);
            ReservedWords.Add("INTEGER", TOKEN_ENUM.TOKEN_INT);
            ReservedWords.Add("STRING", TOKEN_ENUM.TOKEN_STRING);
            ReservedWords.Add("READ", TOKEN_ENUM.TOKEN_READ);
            ReservedWords.Add("WRITE", TOKEN_ENUM.TOKEN_WRITE);
            ReservedWords.Add("THEN", TOKEN_ENUM.TOKEN_THEN);
            ReservedWords.Add("UNTIL", TOKEN_ENUM.TOKEN_UNTIL);
            ReservedWords.Add("REPEAT", TOKEN_ENUM.TOKEN_REPEAT);
            ReservedWords.Add("RETURN", TOKEN_ENUM.TOKEN_RETURN);

            Operators.Add(".", TOKEN_ENUM.TOKEN_DOT);
            Operators.Add(";", TOKEN_ENUM.TOKEN_SEMICOLON);
            Operators.Add(",", TOKEN_ENUM.TOKEN_COMMA);
            Operators.Add("{", TOKEN_ENUM.TOKEN_LBRACE);
            Operators.Add("}", TOKEN_ENUM.TOKEN_RBRACE);
            Operators.Add(":=", TOKEN_ENUM.TOKEN_BINDING); //Assignment
            Operators.Add("=", TOKEN_ENUM.TOKEN_EQUALITY_OPERATOR);
            Operators.Add("<", TOKEN_ENUM.TOKEN_LESS_THAN);
            Operators.Add(">", TOKEN_ENUM.TOKEN_GREATER_THAN);
            Operators.Add("<>", TOKEN_ENUM.TOKEN_NOT_EQUAL);
            Operators.Add("+", TOKEN_ENUM.TOKEN_PLUS_OPERATOR);
            Operators.Add("-", TOKEN_ENUM.TOKEN_MINUS_OPERATOR);
            Operators.Add("*", TOKEN_ENUM.TOKEN_MULTIPLY_OPERATOR);
            Operators.Add("/", TOKEN_ENUM.TOKEN_DIVIDE_OPERATOR);
            Operators.Add("&&", TOKEN_ENUM.TOKEN_ANDING);
            Operators.Add("||", TOKEN_ENUM.TOKEN_ORING);



        }

        //checks if the 1st ptr reached the end of the input
        bool HasMoreTokens() 
        {
            return _p1 < SourceCode.Length - 1;
        }

        char Read()
        {
            char c = SourceCode[_p2];
            _p2++;
            return c;
        }
        void Retract()
        {
            _p2--;

        }

        void Reset()
        {
            _p2 = _p1;
        }

        Token Accept(TOKEN_ENUM Type)
        {
            string lexeme = SourceCode.Substring(_p1, _p2);
            _p1 = _p2;
            Token ret = new Token();
            ret._lexeme = lexeme;
            ret._type = Type;
            _state =(int) TOKEN_ENUM.STATE_READY;//STATE_READY
            return ret;
        }

        Token NextToken()
        {
            char c;
            int acceptType;

            while(_p2<SourceCode.Length)
            {
                c = Read();
                _state
            }
        }



    }
}
