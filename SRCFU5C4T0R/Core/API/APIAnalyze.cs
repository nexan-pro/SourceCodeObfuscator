using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using SRCFU5C4T0R.Core.API;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SRCFU5C4T0R.Core.API
{
    class APIAnalyze : IAnalyze
    {
        public SyntaxTree tree;
        public CompilationUnitSyntax root;
        int ecx = 0; //HACK: 
        /// <summary>
        /// Implementation of method for load C# code from string variable
        /// </summary>
        /// <param name="src"></param>
        /// <returns>Our loaded tree</returns>
        public SyntaxTree LoadCode(string src)
        {
            tree = CSharpSyntaxTree.ParseText(src);
            return (tree);
        }
        /// <summary>
        /// Print all names of methods in loaded source code
        /// </summary>
        public void printDeclareMethodsIdentifer()
        {
            Console.WriteLine("Name of declare methods: ");
            IEnumerable<MethodDeclarationSyntax> dst = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (MethodDeclarationSyntax method in dst)
            {
                SyntaxToken id = method.Identifier;
                Console.WriteLine("{0}", id);
            }
        }
        /// <summary>
        /// Print all names of variables in loaded source code
        /// </summary>
        public void printDeclareVariablesIdentifer()
        {
            root = (CompilationUnitSyntax)tree.GetRoot();
            var nameOfVars = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            foreach (var vars in nameOfVars)
                Console.WriteLine(vars.Variables.First().Identifier.Value);
        }
        /// <summary>
        /// Get 1-rank string array of methods (one method = one element of array)
        /// </summary>
        /// <param name="src">Input string array which will be modified</param>
        /// <returns>Array of methods</returns>
        public string[] getArrayOfDeclareMethods(string[] src)
        {
            IEnumerable<MethodDeclarationSyntax> dst = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            for (UInt16 i = 0; i < dst.Count(); ++i)
                src[i] = dst.ElementAt(i).ToString();
            return (src);
        }
        /// <summary>
        /// Write all methods in 1-rank string array
        /// </summary>
        /// <param name="src">Input 1-rank string array</param>
        /// <returns>1-rank string array with all name of methods</returns>
        public string[] getArrayOfDeclareMethodsIdentifer(string[] src)
        {
            ecx = 0;
            IEnumerable<MethodDeclarationSyntax> dst = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (MethodDeclarationSyntax method in dst)
            {
                SyntaxToken id = method.Identifier;
                src[ecx] = id.ToString();
                ecx++;
            }
            return (src);
        }
        /// <summary>
        /// Method which write all name of variables in 1-rank string array
        /// </summary>
        /// <param name="src">Input 1-rank string array, which will be modified and store name of declare variables</param>
        /// <returns>1-rank modified string array</returns>
        public string[] getArrayOfDeclareVariables(string[] src)
        {
            root = (CompilationUnitSyntax)tree.GetRoot();
            var varDeclorations = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            for (UInt16 i = 0; i < varDeclorations.Count(); ++i)
                src[i] = varDeclorations.ElementAt(i).ToString();
            return (src);
        }
        /// <summary>
        /// Method which write all declare variables identificators in 1-rank string array
        /// </summary>
        /// <param name="src">Input 1-rank string array, which will be modified and store name of declare variables</param>
        /// <returns>1-rank modified string array</returns>
        public string[] getArrayOfDeclareVariablesIdentifer(string[] src)
        {
            ecx = 0;
            root = (CompilationUnitSyntax)tree.GetRoot(); //HACK: f1x th15, 0fc m4ny 1n1t14l
            var nameOfVars = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            foreach (var vars in nameOfVars) {
                src[ecx] = vars.Variables.First().Identifier.Value.ToString();
                ecx++;
            }
            return (src);
        }
        /// <summary>
        /// Print all expressions which use declaration variables
        /// </summary>
        public void printVariableExpressions()
        {
            root = (CompilationUnitSyntax)tree.GetRoot();
            var varsExpr = root.DescendantNodes().OfType<AssignmentExpressionSyntax>();
            foreach (var expr in varsExpr)
                Console.WriteLine(expr);
        }
        /// <summary>
        /// Write to array all variables expressions 
        /// </summary>
        /// <param name="src">Array which will be modified</param>
        /// <returns>String array which contains all variables expressions of source code</returns>
        public string[] getArrayOfVariableExpressions(string[] src)
        {
            ecx = 0;
            root = (CompilationUnitSyntax)tree.GetRoot();
            var varsExpr = root.DescendantNodes().OfType<AssignmentExpressionSyntax>();
            foreach (var expr in varsExpr)
            {
                src[ecx] = expr.ToString();
                ecx++;
            }
            return (src);
        }
        /// <summary>
        /// Get all ecntry point parameters
        /// </summary>
        /// <param name="src">Array which you want to write parameters of entry point</param>
        /// <returns>Modified string array</returns>
        public string[] getListOfParameters(string[] src)
        {
            ecx = 0;
            root = (CompilationUnitSyntax)tree.GetRoot();
            IEnumerable<MethodDeclarationSyntax> dst = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (MethodDeclarationSyntax method in dst)
            {
                ParameterListSyntax id = method.ParameterList;
                src[ecx] = id.ToString();
                ecx++;
            }
            return (src);
        }
        public string[] getDeclareMethodPrototype(string[] src)
        {
            root = (CompilationUnitSyntax)tree.GetRoot();
            IEnumerable<MethodDeclarationSyntax> ty = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (MethodDeclarationSyntax method in ty)
            {
               // SyntaxTokenList id = method.;
               // Console.WriteLine("{0} ", id);
            }
            //TODO
            return (src);
        }
    }
}
