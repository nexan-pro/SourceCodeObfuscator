using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using SRCFU5C4T0R.Core.Kernel.API;

namespace SRCFU5C4T0R.Core.Obfuscation {
/// <summary>
/// This class provide to mutation expressions
/// </summary>
class Mutation {
  public Solution confuseExpressions(Solution sln) {
    var projId = APIAnalyze.projId;
    MSBuildWorkspace wspLoading = MSBuildWorkspace.Create();
    var prjLoading = wspLoading.OpenProjectAsync(Config.pathToOriginal).Result;
    Solution slnLoading = wspLoading.CurrentSolution;
    foreach (var prjId in slnLoading.GetProjectDependencyGraph().GetTopologicallySortedProjects()) {
      var prj = slnLoading.GetProject(prjId);
      foreach (var doc in prj.Documents)
        sln = sln.AddDocument(DocumentId.CreateNewId(projId), doc.Name, doc.GetTextAsync().Result);
    }

    var documents = sln.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    foreach (var documentId in documents) {
      List<LocalDeclarationStatementSyntax> vars;
      List<FieldDeclarationSyntax> fields; //TODO: fields
      List<AssignmentExpressionSyntax> expr; //TODO: expressions
      int i = 0;
      do {
        var current_doc = sln.GetDocument(documentId);
        var editor = DocumentEditor.CreateAsync(current_doc).Result;
        var model = current_doc.GetSemanticModelAsync().Result;
        var syntax = current_doc.GetSyntaxRootAsync().Result;
        vars = syntax.DescendantNodes().OfType<LocalDeclarationStatementSyntax>()
              .Where(x => x.Declaration.Variables.Last().Initializer.Value.Kind() == SyntaxKind.NumericLiteralExpression)
              .ToList();
        fields = syntax.DescendantNodes().OfType<FieldDeclarationSyntax>()
                 .Where(x => x.Declaration.Variables.Last().Initializer.Value.Kind() == SyntaxKind.NumericLiteralExpression)
                 .ToList();
        
       
        foreach (var var_declorator in vars) {
          foreach (var vr in var_declorator.Declaration.Variables) {
            if (vr.Initializer == null) continue;
            string formattedInitializer = vr.Initializer.Value.ToString() + vr.Initializer.Value.ToString();
            var newVariable = SyntaxFactory.ParseStatement($"{var_declorator.Declaration.Type} {vr.Identifier} = {formattedInitializer};");
            newVariable.NormalizeWhitespace();
            editor.ReplaceNode(vr, newVariable);
            Console.WriteLine($"[MUTATION] Key: {vr.Identifier} replaced with value: {formattedInitializer}");
          }
          current_doc = editor.GetChangedDocument();
          Console.WriteLine(current_doc.GetSyntaxRootAsync().Result);
          i++;
        }
      } while (i < vars.Count);
    }
    return sln;
  }
  }
} 
