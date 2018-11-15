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
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.MSBuild;
using System.IO;

namespace SRCFU5C4T0R.Obfuscation {
    /// <summary>
    /// Class of renamin variables identifer
    /// </summary>
    class RenameVarsIdentifer {
        /// <summary>
        /// Renaming variables identifer 
        /// </summary>
        /// <param name="projName">Project name</param>
        public string renameVarsIdentifer(string projName) {
            MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            var projId = ProjectId.CreateNewId();
            var versionStamp = VersionStamp.Create();
            var projectInfo = ProjectInfo.Create(projId, versionStamp, projName, projName, LanguageNames.CSharp);
            var solution = workspace.CurrentSolution.AddProject(projectInfo);
            string projectPath = @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp\ConsoleApp_CSharp.csproj"; //!< Your path to source project
            //TODO: UI
            MSBuildWorkspace wspLoading = MSBuildWorkspace.Create();
            var prjLoading = wspLoading.OpenProjectAsync(projectPath).Result;
            Solution slnLoading = wspLoading.CurrentSolution;

            solution = solution.WithProjectCompilationOptions(projId, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            foreach(var prjId in slnLoading.GetProjectDependencyGraph().GetTopologicallySortedProjects()) {
                var prj = slnLoading.GetProject(prjId);

                foreach(var doc in prj.Documents)
                    solution = solution.AddDocument(DocumentId.CreateNewId(projId), doc.Name, doc.GetTextAsync().Result);
                solution = solution.AddMetadataReferences(projId, prj.MetadataReferences);
            }

            var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
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

                            var newName = Utils.String.getRandomStr(300);
                            Console.WriteLine("Renaming variable: " + vr.Identifier.ValueText + " to " + newName + $" {vr.Kind()}");
                            solution = Renamer.RenameSymbolAsync(solution, symbol, newName, null).Result;
                            break;
                        }
                        break;
                    }
                } while(i < vars.Count);
            }
            string src = "";
            foreach(var documentId in documents) {
                var document = solution.GetDocument(documentId);
                var model = document.GetSemanticModelAsync().Result;
                var syntax = document.GetSyntaxRootAsync().Result;
                src += syntax.SyntaxTree;
                Console.WriteLine(syntax.SyntaxTree);
            }
            return (src);
        }
    }
}
