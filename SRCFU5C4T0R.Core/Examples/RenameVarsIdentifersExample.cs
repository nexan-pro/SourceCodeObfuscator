using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using SRCFU5C4T0R.Core.Kernel.API;
using SRCFU5C4T0R.Core.Obfuscation.Renamers;

namespace SRCFU5C4T0R.Core.Examples {
class RenameVarsIdentifersExample {
  static void main(string[] args) {
    APIAnalyze api = new APIAnalyze();
    var solution = api.createSolution("RenameVarsIdentifiers");
    VarsIdentifiers obj = new VarsIdentifiers();
    solution = obj.renameVarsIdentifier(solution);

    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    string[] src = new string[0x1337];
    DocumentId documentId = documents.First();
    var document = solution.GetDocument(documentId);
    var model = document.GetSemanticModelAsync().Result;
    var syntax = document.GetSyntaxRootAsync().Result;
    src[0] += syntax.SyntaxTree;
    Console.WriteLine(src[0]);
  }  
 }
}