using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Rename;
using SRCFU5C4T0R.Core.Kernel.API;
using SRCFU5C4T0R.Core.Obfuscation;
using srclib.Helpers;

namespace SRCFU5C4T0R.Core.Obfuscation {
/// <summary>
/// This class provide to encrypt string
/// </summary>
class EncryptStrings {
  public Solution encryptStrings(Solution solution) {
    var projId = APIAnalyze.projId;
    MSBuildWorkspace wspLoading = MSBuildWorkspace.Create();
    var prjLoading = wspLoading.OpenProjectAsync(Config.pathToOriginal).Result;
    Solution slnLoading = wspLoading.CurrentSolution;
     Solution newSolution = wspLoading.CurrentSolution;
    foreach(var prjId in slnLoading.GetProjectDependencyGraph().GetTopologicallySortedProjects()) {
      var prj = slnLoading.GetProject(prjId);
    foreach(var doc in prj.Documents)
      solution = solution.AddDocument(DocumentId.CreateNewId(projId), doc.Name, doc.GetTextAsync().Result);
      }

    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    Console.WriteLine("-------------------------------------------------------------------------------------");        
    foreach(var documentId in documents) {
      List<LocalDeclarationStatementSyntax> vars;
      List<InvocationExpressionSyntax> callable;
      int i, z; // !< counters
      do {
        var doc = solution.GetDocument(documentId);
        var editor = DocumentEditor.CreateAsync(doc).Result;
        var model = doc.GetSemanticModelAsync().Result;
        var syntax = doc.GetSyntaxRootAsync().Result;
        vars = syntax.DescendantNodes()
               .OfType<LocalDeclarationStatementSyntax>()
               .ToList();
        callable = syntax.DescendantNodes()
               .OfType<InvocationExpressionSyntax>()
               .ToList();
        i = 0;
        foreach (var localDeclarationStatementSyntax in vars) {
          foreach (VariableDeclaratorSyntax variable in localDeclarationStatementSyntax.Declaration.Variables) {
            if (variable.Initializer == null) continue;
            var stringKind = variable.Initializer.Value.Kind();
            
            if (stringKind == SyntaxKind.StringLiteralExpression) {
                var newVariable = SyntaxFactory.ParseStatement($"string {variable.Identifier.ValueText} = a1f95c1bb38e78c13308.__0xᵉ7ᵉ371ᶠ3ᶠ8ᵃᵃ56895ᵉ9ᵃᵈ4790ᵃ53432ᶠ2ᵈᵇᶜᵃ362ᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉ_(\"{a1f95c1bb38e78c13308.__0x3442496ᵇ96ᵈᵈ01591ᵃ8ᶜᵈ44ᵇ1ᵉᵉᶜ1368ᵃᵇ728ᵃᵇᵃᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉ_(variable.Initializer.Value.ToString())}\");");
              newVariable.NormalizeWhitespace();
                
              editor.ReplaceNode(variable, newVariable);

              Console.WriteLine($"Key: {variable.Identifier.Value} Value:{variable.Initializer.Value}");
            }
          }
        doc = editor.GetChangedDocument();
        Console.WriteLine(doc.GetSyntaxTreeAsync().Result);
        i++;
       }

       z = 0;
       foreach (var invocationExpressionSyntax in callable) {
         if (invocationExpressionSyntax.ArgumentList.Arguments.Any(x =>
           x.Expression.Kind() == SyntaxKind.StringLiteralExpression)) {
         var stringList = new List<string>();

         for (int x = 0; x < invocationExpressionSyntax.ArgumentList.Arguments.Count(); x++)
           if (invocationExpressionSyntax.ArgumentList.Arguments[x].Expression.Kind() == SyntaxKind.StringLiteralExpression)
                  stringList.Add("a1f95c1bb38e78c13308.__0xᵉ7ᵉ371ᶠ3ᶠ8ᵃᵃ56895ᵉ9ᵃᵈ4790ᵃ53432ᶠ2ᵈᵇᶜᵃ362ᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉ_(\"" + a1f95c1bb38e78c13308.__0x3442496ᵇ96ᵈᵈ01591ᵃ8ᶜᵈ44ᵇ1ᵉᵉᶜ1368ᵃᵇ728ᵃᵇᵃᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉᵈᵉᵃᵈᶜᵒᵈᵉ_(invocationExpressionSyntax.ArgumentList.Arguments[x].Expression.GetFirstToken().ValueText) + "\")");
                else
                stringList.Add(invocationExpressionSyntax.ArgumentList.Arguments[x].Expression
                    .GetFirstToken().ValueText);

        SeparatedSyntaxList<ArgumentSyntax> arguments = new SeparatedSyntaxList<ArgumentSyntax>().AddRange
        (new ArgumentSyntax[]
            {
                SyntaxFactory.Argument(SyntaxFactory.ParseExpression($"{string.Join(",", stringList)}")),
            }
        );

        var newMethodWithStringObfuscation =
            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName(invocationExpressionSyntax.Expression.ToString()))
                .WithArgumentList(SyntaxFactory.ArgumentList().WithOpenParenToken(SyntaxFactory.Token(SyntaxKind.OpenParenToken))
                .WithArguments(arguments).WithCloseParenToken(SyntaxFactory.Token(SyntaxKind.CloseParenToken)));

        Console.WriteLine($"Replacing values for method {invocationExpressionSyntax.Expression.GetFirstToken().ValueText}");

        editor.ReplaceNode(invocationExpressionSyntax, newMethodWithStringObfuscation);
        } 
        z++;
      }

       File.WriteAllText(Config.pathToObfuscated + doc.Name, editor.GetChangedRoot().SyntaxTree.ToString()); // TODO: 
       } while(i < vars.Count && z < callable.Count);
     }


    Console.WriteLine("-------------------------------------------------------------------------------------");
    return solution;
    }
  }
}
