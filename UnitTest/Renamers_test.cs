using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using srclib.Helpers;
using SRCFU5C4T0R.Obfuscation;
using SRCFU5C4T0R.Obfuscation.Renamers;
using SRCFU5C4T0R.Core.API;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace UnitTest {
[TestClass]
public class Renamers_test {
  [TestMethod]
  public void renamers() {
    APIAnalyze api = new APIAnalyze();
    Methods obj = new Methods();
    Classes obj_classes = new Classes();
    RenameVarsIdentifiers obj_vars = new RenameVarsIdentifiers();
    Namespaces obj_namespaces = new Namespaces();
    var solution = api.CreateSolution("qwerty");
    solution = obj.renameMethods(solution);
    solution = obj_vars.renameVarsIdentifier(solution);
    solution = obj_classes.renameClasses(solution);
    solution = obj_namespaces.renameNamespaces(solution);
    int i = 0;
    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    string[] src = new string[0x1337];
    DocumentId documentId = documents.First();
    Console.WriteLine("Count of docs in array: " + documents.Count);
    //foreach(var documentId in documents) {
    var document = solution.GetDocument(documentId);
    var model = document.GetSemanticModelAsync().Result;
    var syntax = document.GetSyntaxRootAsync().Result;
    src[i] += syntax.SyntaxTree;
    Console.WriteLine("Lines in doc: " + syntax.SyntaxTree.GetText().Lines.Count);
    ++i;
    //}

    string path = @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp\bin\Debug\rez.txt";
    File.WriteAllText(path, src[0]);

    //assert
    Assert.AreEqual(true, isCheck(path));
  }
  bool isCheck(string path) {
    byte[] content = File.ReadAllBytes(path);
    if ((content[0] == 0x00) || (!File.Exists(path))) {
      return false;
    }
    return true;
  }
 }
}
