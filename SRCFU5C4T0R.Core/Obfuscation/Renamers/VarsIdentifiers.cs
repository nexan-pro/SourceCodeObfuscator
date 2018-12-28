using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.Kernel.API;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.MSBuild;
using System.IO;

namespace SRCFU5C4T0R.Core.Obfuscation.Renamers {
/// <summary>
/// Class of renaming variables identifiers
/// </summary>
class VarsIdentifiers {
  /// <summary>
  /// Renaming variables identifiers
  /// </summary>
  /// <param name="solution">Solution, which will be contained projects for rename variables</param>
  /// <returns>Resulting solution</returns>
  public Solution renameVarsIdentifier(Solution solution) {
    var projId = APIAnalyze.projId;
    MSBuildWorkspace wspLoading = MSBuildWorkspace.Create();
    var prjLoading = wspLoading.OpenProjectAsync(Config.pathToOriginal).Result;
    Solution slnLoading = wspLoading.CurrentSolution;
    foreach(var prjId in slnLoading.GetProjectDependencyGraph().GetTopologicallySortedProjects()) {
      var prj = slnLoading.GetProject(prjId);
    
    foreach(var doc in prj.Documents)
      solution = solution.AddDocument(DocumentId.CreateNewId(projId), doc.Name, doc.GetTextAsync().Result);
      }

    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    Console.WriteLine("-------------------------------------------------------------------------------------");        
    foreach(var documentId in documents) {
      List<VariableDeclarationSyntax> vars;
      int i;
      do {
        var doc = solution.GetDocument(documentId);
        var model = doc.GetSemanticModelAsync().Result;
        var syntax = doc.GetSyntaxRootAsync().Result;
        vars = syntax.DescendantNodes()
               .OfType<VariableDeclarationSyntax>()
               .Where(x => x.Variables.Count(z => !z.Identifier.ValueText.StartsWith("__0x")) > 0)
               .ToList();

        for(i = 0; i < vars.Count; i++) {
          foreach(var vr in vars[i].Variables) {
            var symbol = model.GetDeclaredSymbol(vr);
            var newName = "__0x" + Utils.String.to_Tiny(Utils.String.to_SHA1(vr.Identifier.ValueText));
            Console.WriteLine("Renaming variable: " + vr.Identifier.ValueText + " to " + newName + $" {vr.Kind()}");
            solution = Renamer.RenameSymbolAsync(solution, symbol, newName, null).Result;
            break;
            }
            break;
        }
        } while(i < vars.Count);
        }
      Console.WriteLine("-------------------------------------------------------------------------------------");
      return (solution);
    }
  }
}
