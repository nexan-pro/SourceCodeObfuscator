using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRCFU5C4T0R.Core.Obfuscation;
using SRCFU5C4T0R.Core.Kernel.API;

namespace UnitTest {
[TestClass]
public class Mutation_test {
  [TestMethod]
  public void confExpr() {
    Config.pathToOriginal = @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp\ConsoleApp_CSharp.csproj";
    APIAnalyze api = new APIAnalyze();
    Mutation mut = new Mutation();
    var sln = api.createSolution("src_sln");
    sln = mut.confuseExpressions(sln);
    Console.WriteLine("Current documents in main sln contain: ");
    var documents = sln.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    foreach (var doc in documents) {
      var syntax = sln.GetDocument(doc).GetSyntaxRootAsync().Result;
      Console.WriteLine(syntax.SyntaxTree);
    }
  }
}
}
