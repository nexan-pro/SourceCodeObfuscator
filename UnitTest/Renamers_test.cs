using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using srclib.Helpers;
using SRCFU5C4T0R.Core.Obfuscation;
using SRCFU5C4T0R.Core.Obfuscation.Renamers;
using SRCFU5C4T0R.Core.Kernel.API;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace UnitTest {
[TestClass]
public class Renamers_test {
  [TestMethod]
  public void renamers() {
    Config.pathToOriginal = @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp\ConsoleApp_CSharp.csproj";
    Config.pathToObfuscated = Directory.GetParent(Config.pathToOriginal).FullName + @"\";
    Console.WriteLine("path to obf " + Config.pathToObfuscated);
    APIAnalyze api = new APIAnalyze();
    Methods obj = new Methods();
    Classes obj_classes = new Classes();
    VarsIdentifiers obj_vars = new VarsIdentifiers();
    Namespaces obj_namespaces = new Namespaces();
    MethodParams obj_methodParams = new MethodParams();
    var solution = api.createSolution("qwerty");
    solution = obj.renameMethods(solution);
    solution = obj_vars.renameVarsIdentifier(solution);
    solution = obj_classes.renameClasses(solution);
    solution = obj_namespaces.renameNamespaces(solution);
    solution = obj_methodParams.renameParams(solution);
    int i = 0;
    var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    string[] src = new string[0x1337];
    //Config.pathToObfuscated += @"SRCFU5C4T3D\";
    //Directory.CreateDirectory(Config.pathToObfuscated);
    Console.WriteLine("Count of docs in array: " + documents.Count);
    foreach(var documentId in documents) {
      var document = solution.GetDocument(documentId);
      var syntax = document.GetSyntaxRootAsync().Result;
      src[i] += syntax.SyntaxTree;
      if (i < documents.Count / 5) // because our solution has been modified 5 times (--rm, --rv, --rc, --rn, --rp) 
        File.WriteAllText(Config.pathToObfuscated + document.Name, src[i]);
      Console.WriteLine("doc name is: " + document.Name);
      Console.WriteLine("Lines in doc: " + syntax.SyntaxTree.GetText().Lines.Count);
      ++i;
    }

    //assert
    //Assert.AreEqual(true, isCheck(Config.pathToObfuscated));
  }
  bool isCheck(string path) {
    byte[] content = File.ReadAllBytes(path);
    if ((content[0] == 0x00) || (!File.Exists(path)))
      return false;
    return true;
  }
 }
}
