using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRCFU5C4T0R.Core.Obfuscation;
using SRCFU5C4T0R.Core.Kernel.API;

namespace UnitTest {                                                                                                                             
[TestClass]
public class Mutation_test {
  [TestMethod]
  public void num_protection() {
    Config.pathToOriginal = @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp\ConsoleApp_CSharp.csproj";
    APIAnalyze api = new APIAnalyze();
    NumProtection mut = new NumProtection();
    var sln = api.createSolution("src_sln");
    sln = mut.confuseExpressions(sln);
    Console.WriteLine("Modified solution contain: ");
    var documents = sln.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
    foreach (var doc in documents) {
      Console.WriteLine("-------------------------------------------------\n" +
                              $"Document name is: { sln.GetDocument(doc).Name }\n" + 
                              "-------------------------------------------------\n");
      var syntax = sln.GetDocument(doc).GetSyntaxRootAsync().Result;
      Console.WriteLine(syntax.SyntaxTree);
    }
  }
}
}
