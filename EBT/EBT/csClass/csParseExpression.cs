using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class csParseExpression
{
    public static string[] ParseExpression(string strExpr)
    {
        string[] strNode = new string[3]; // Op-Left-Right

        if (strExpr.Length == 0)
        { 
            strExpr = "0";
            strNode[0] = "";
            strNode[1] = "";
            strNode[2] = "";
            return strNode;
        }

        // If the first thing is + or -, it's unary.
        bool is_unary = true;
        int best_prec = 9;
        int open_parens = 0;
        int best_i = -1;

        string Op = "";
        string strLeftChild = "";
        string strRightChild = "";

        for (int i = 0; i < strExpr.Length; i++)
        {
            bool next_unary = false;
            string ch = strExpr.Substring(i, 1);
            if (ch == " ")
            { }
            else if (ch == "(")
            { 
                open_parens += 1;
                next_unary = true;
            }
            else if (ch == @")")
            {
                open_parens -= 1;
                next_unary = false;

                if (open_parens < 0)
                { throw new Exception("Parse error. Too many )s in expression '" + strExpr + "'"); }
            }
            else if (open_parens == 0)
            {
                if (
                   ch == "^" || ch == "*" ||
                   ch == "/" || ch == @"\" ||
                   ch == "%" || ch == "+" ||
                   ch == "-"
                    )
                {
                    next_unary = true;
                    switch (ch)
                    {
                        case "^":
                            if (best_prec >= 9)
                            {
                                best_prec = 9;
                                best_i = i;
                            }
                            break;
                        case "*":
                        case @"/":
                            if (best_prec >= 8)
                            {
                                best_prec = 8;
                                best_i = i;
                            }
                            break;
                        case @"\":
                            if (best_prec >= 6)
                            {
                                best_prec = 6;
                                best_i = i;
                            }
                            break;
                        case "%":
                            if (best_prec >= 5)
                            {
                                best_prec = 5;
                                best_i = i;
                            }
                            break;
                        case "+":
                        case "-":
                            if (best_prec >= 4)
                            {
                                best_prec = 4;
                                best_i = i;
                            }
                            break;
                    }

                }
            }
            is_unary = next_unary;
        }

        if (open_parens != 0)
        { throw new Exception("Parse error. Missing ) in expression '" + strExpr + "'"); }

        if (strExpr.StartsWith("(") && strExpr.EndsWith(")") && best_i <0)
        {
            Op = "( )";
            strLeftChild = strExpr.Substring(1, strExpr.Length - 2);


            strNode[0] = Op;
            strNode[1] = strLeftChild;
            strNode[2] = "";
            return strNode;
        }

        if (best_prec < 11)
        {
            string lexpr = strExpr.Substring(0, best_i);
            string rexpr = strExpr.Substring(best_i + 1);
            Op = strExpr.Substring(best_i, 1);
            strLeftChild = lexpr;
            strRightChild = rexpr;


            strNode[0] = Op;
            strNode[1] = strLeftChild;
            strNode[2] = strRightChild;

        }
        
        if (strExpr.StartsWith("-"))
        {
            Op = "-";
            strLeftChild = strExpr.Substring(1, strExpr.Length - 1);


            strNode[0] = Op;
            strNode[1] = strLeftChild;
            strNode[2] = "";
        }

        if (strExpr.StartsWith("+"))
        {
            Op =  "+";
            strLeftChild = strExpr.Substring(1, strExpr.Length - 1);


            strNode[0] = Op;
            strNode[1] = strLeftChild;
            strNode[2] = "";

        }
        return strNode;

    }
}