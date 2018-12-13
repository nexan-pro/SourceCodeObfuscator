using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Rename;
using SRCFU5C4T0R.Core.API;

namespace SRCFU5C4T0R.Obfuscation.Renamers {
/// <summary>
/// Class of renaming methods identifiers
/// </summary>
class Methods {
/// <summary>
/// Renaming methods identifiers
/// </summary>
/// <param name="solution">Solution, which will be contained projects for rename methods identifiers</param>
/// <returns>Resulting solution</returns>
  public Solution renameMethods(Solution solution) {
    MSBuildWorkspace workspace = MSBuildWorkspace.Create();
    var projId = APIAnalyze.projId;

    MSBuildWorkspace wspLoading = MSBuildWorkspace.Create();
    var prjLoading = wspLoading.OpenProjectAsync(APIAnalyze.path).Result;
    Solution slnLoading = wspLoading.CurrentSolution;
    foreach(var prjId in slnLoading.GetProjectDependencyGraph().GetTopologicallySortedProjects()) {
      var prj = slnLoading.GetProject(prjId);

      foreach(var doc in prj.Documents)
        solution = solution.AddDocument(DocumentId.CreateNewId(projId),doc.Name,doc.GetTextAsync().Result);
      }

      var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();

    foreach(var documentId in documents) {
      List<MethodDeclarationSyntax> methods;
      int i;
      do {
        var doc = solution.GetDocument(documentId);
        var model = doc.GetSemanticModelAsync().Result;
        var syntax = doc.GetSyntaxRootAsync().Result;
        methods = syntax.DescendantNodes().OfType<MethodDeclarationSyntax>().Where(x => !x.Identifier.ValueText.StartsWith("__0x") && !x.Identifier.ValueText.Equals("Main")).ToList(); // !<!~!

        for(i = 0; i < methods.Count; ++i) {
          foreach(var mth in methods) {
            var symbol = model.GetDeclaredSymbol(mth);
            var newName = "__0x" + Utils.String.to_Tiny(Utils.String.to_SHA1(mth.Identifier.ValueText));
            Console.WriteLine("Renaming variable: " + mth.Identifier.ValueText + " to " + newName + $" {mth.Kind()}");
            solution = Renamer.RenameSymbolAsync(solution, symbol, newName, null).Result;
            break;
          }
          break;
        }
      } while(i < methods.Count);
      }
      return solution;
  }
 }
}
