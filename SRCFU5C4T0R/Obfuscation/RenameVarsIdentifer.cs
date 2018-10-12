using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.API;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace SRCFU5C4T0R.Obfuscation
{
    class RenameVarsIdentifer
    {

        //public string renameVarsIdentifer(string src)
        //{
        //    APIAnalyze obj = new APIAnalyze();
        //    obj.LoadCode(src);
        //    var root = (CompilationUnitSyntax)obj.tree.GetRoot();
        //    var nameOfVars = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
        //    var newVar = "num";
        //    VariableDeclaratorSyntax declarator = node.Declaration.Variables.First();
        //    int ecx = 0;
        //    foreach (var vars in nameOfVars)
        //    {
        //        ecx++;
        //        newVar += ecx;
        //        VariableDeclaratorSyntax newVariable = declarator.WithIdentifier(SyntaxFactory.Identifier(newVar));
        //        var newRoot = root.ReplaceNode(vars, newVariable);
        //        Console.WriteLine(newRoot.SyntaxTree);
        //    }
            
        //    return (src);
        //}
       
    }
}
