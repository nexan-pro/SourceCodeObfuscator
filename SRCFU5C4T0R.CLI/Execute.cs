using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Obfuscation;
using SRCFU5C4T0R.Obfuscation.Renamers;
using SRCFU5C4T0R.Core.API;
using Microsoft.CodeAnalysis;
using System.IO;

namespace SRCFU5C4T0R.CLI {
class Execute {
  public bool process() {
    APIAnalyze api = new APIAnalyze();
    var solution = api.CreateSolution("ObfuscatedProject");
    if (Config.isRenameClasses) {
      Classes obfClasses = new Classes();
      solution = obfClasses.renameClasses(solution);
    }
    if (Config.isRenameMethodParams) {
      MethodParams obfMethodParams = new MethodParams();
      solution = obfMethodParams.renameParams(solution);
    }
    if (Config.isRenameMethods) {
      Methods obfMethods = new Methods();
      solution = obfMethods.renameMethods(solution);
    }
    if (Config.isRenameNamespaces) {
      Namespaces obfNamespaces = new Namespaces();
      solution = obfNamespaces.renameNamespaces(solution);
    }
    if (Config.isRenameVars) {
      VarsIdentifiers obfVarsIdentifiers = new VarsIdentifiers();
      solution = obfVarsIdentifiers.renameVarsIdentifier(solution);
    }

    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    string[] src = new string[0x1337];
    DocumentId documentId = documents.First();
    Console.WriteLine("Count of docs in array: " + documents.Count);
    int i = 0;
    //foreach(var documentId in documents) {
    var document = solution.GetDocument(documentId);
    var model = document.GetSemanticModelAsync().Result;
    var syntax = document.GetSyntaxRootAsync().Result;
    src[0] += syntax.SyntaxTree;
    ++i;
    //}
    Console.WriteLine("Lines in doc: " + syntax.SyntaxTree.GetText().Lines.Count);
    File.WriteAllText(Config.pathToObfuscated, src[0]);
    return true;
  }
  }
}
