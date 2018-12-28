using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.Obfuscation;
using SRCFU5C4T0R.Core.Obfuscation.Renamers;
using SRCFU5C4T0R.Core.Kernel.API;
using Microsoft.CodeAnalysis;
using System.IO;

namespace SRCFU5C4T0R.CLI {
class Execute {
  public bool process() {
    int ecx = 0;
    APIAnalyze api = new APIAnalyze();
    var solution = api.CreateSolution("ObfuscatedProject");
    Config.pathToObfuscated = Directory.GetParent(Config.pathToOriginal).FullName + @"\";
    if (Config.isRenameClasses) {
      Classes obfClasses = new Classes();
      solution = obfClasses.renameClasses(solution);
      ecx++;
    }
    if (Config.isRenameMethodParams) {
      MethodParams obfMethodParams = new MethodParams();
      solution = obfMethodParams.renameParams(solution);
      ecx++;
    }
    if (Config.isRenameMethods) {
      Methods obfMethods = new Methods();
      solution = obfMethods.renameMethods(solution);
      ecx++;
    }
    if (Config.isRenameNamespaces) {
      Namespaces obfNamespaces = new Namespaces();
      solution = obfNamespaces.renameNamespaces(solution);
      ecx++;
    }
    if (Config.isRenameVars) {
      VarsIdentifiers obfVarsIdentifiers = new VarsIdentifiers();
      solution = obfVarsIdentifiers.renameVarsIdentifier(solution);
      ecx++;
    }
    

    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    string[] src = new string[0x1337];
    int i = 0;
    Console.WriteLine("Count of docs in array: " + documents.Count);
    foreach(var documentId in documents) {
      var document = solution.GetDocument(documentId);
      var model = document.GetSemanticModelAsync().Result;
      var syntax = document.GetSyntaxRootAsync().Result;
      src[i] += syntax.SyntaxTree;
      if(i < documents.Count / ecx) // !< 
        File.WriteAllText(Config.pathToObfuscated + document.Name,src[i]);
      Console.WriteLine("doc name is: " + document.Name);
      Console.WriteLine("Lines in doc: " + syntax.SyntaxTree.GetText().Lines.Count);
      ++i;
      }
    if (Config.isEncryptStrings) {
      EncryptStrings obfEncryptStrings = new EncryptStrings();
      obfEncryptStrings.encryptStrings(solution);
    }
    return true;
  }
  }
}
