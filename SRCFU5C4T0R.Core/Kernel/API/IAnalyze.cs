using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Rename;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Core.Kernel.API {
  /// <summary>
  /// Interface for load and analyze C# code
  /// </summary>
  interface IAnalyze {
    /// <summary>
    /// Create solution in workspace
    /// </summary>
    /// <param name="projName">Project name</param>
    /// <returns>Created solution</returns>
    Solution createSolution(string projName);

    /// <summary>
    /// Method for load C# code from string variable
    /// </summary>
    /// <returns>Loaded SyntaxTree</returns>
    //HACK: Load Code ;(
    SyntaxTree loadCode(string src); //TODO: add API with documents/solutions/workspace/MSBuild/Adhoc/

    /// <summary>
    /// Print all names of methods in loaded source code
    /// </summary>
    void printDeclareMethodsIdentifer();

    /// <summary>
    /// Print all name of declare variables in loaded sorce code
    /// </summary>
    void printDeclareVariablesIdentifer();

    /// <summary>
    /// Print all variables expressions
    /// </summary>
    void printVarsInitAndOperations();

    /// <summary>
    /// Get all callable methods
    /// <param name="src">Array which will be storing all callable methods</param>
    /// <param name="pathToSolution">Path to your solution in which you want to get callable methods</param>
    /// </summary>
    Task<string[]> getCallableMethods(string[] src, string pathToSolution);

    /// <summary>
    /// Get 1 rank string-array with name of declare methods
    /// </summary>
    /// <returns>1 rank string-array</returns>
    string[] getArrayOfDeclareMethods(string[] src);

    /// <summary>
    /// Method which write in your input array name of methods
    /// </summary>
    /// <param name="src">Input string array</param>
    /// <returns>String array</returns>
    string[] getArrayOfDeclareMethodsIdentifer(string[] src);

    /// <summary>
    /// Write in your input array all names of declare variables
    /// </summary>
    /// <param name="src">Array which you want to write names of declare variables</param>
    /// <returns>Modified string array</returns>
    string[] getArrayOfDeclareVariables(string[] src);

    /// <summary>
    /// Get all declare variables identificators
    /// </summary>
    /// <param name="src">Array which you want to write all identificators</param>
    /// <returns>String array with identidicators</returns>
    string[] getArrayOfDeclareVariablesIdentifer(string[] src);

    /// <summary>
    /// Get all variables expressions
    /// </summary>
    /// <param name="src">Array which you want to modifie</param>
    /// <returns>Modified array</returns>
    string[] getArrayOfVarsInitAndOperations(string[] src);

    /// <summary>
    /// Get all ecntry point parameters
    /// </summary>
    /// <param name="src">Array which you want to write parameters of entry point</param>
    /// <returns>Modified string array</returns>
    string[] getListOfParameters(string[] src);

    /// <summary>
    /// Get prototype of decalre method
    /// </summary>
    /// <param name="src">Input array for writing output</param>
    /// <returns>1-rank string array</returns>
    string[] getDeclareMethodPrototype(string[] src);
 }
}
