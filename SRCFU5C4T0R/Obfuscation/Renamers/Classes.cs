using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;

namespace SRCFU5C4T0R.Obfuscation.Renamers {
/// <summary>
/// Class of renaming classes identifiers
/// </summary>
class Classes {
/// <summary>
/// Renaming classes identifiers
/// </summary>
/// <param name="solution">Solution, which will be contained projects for rename classes identifiers</param>
/// <returns>Resulting solution</returns>
  public Solution renameClasses(Solution solution) {
    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
      foreach(var documentId in documents) {
        while(true) {
          var doc = solution.GetDocument(documentId);
          var model = doc.GetSemanticModelAsync().Result;
          var syntax = doc.GetSyntaxRootAsync().Result;
          var classes = syntax.DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .Where(x => !x.Identifier.ValueText.StartsWith("_0x"))
            .ToList();

          var cl = classes.FirstOrDefault();
          if(cl == null)
            break;
          var symbol = model.GetDeclaredSymbol(cl);
          var newName = "_0x" + Utils.String.to_Tiny(Utils.String.to_SHA1(cl.Identifier.ValueText));
          Console.WriteLine("Renaming class: " + cl.Identifier.ValueText + " to " + newName);
          solution = Renamer.RenameSymbolAsync(solution,symbol,newName,null).Result;
          }
        }
        return solution;
    }
  }
}
