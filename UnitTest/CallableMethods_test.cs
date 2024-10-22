﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRCFU5C4T0R.Core.Kernel.API;

namespace UnitTest {
[TestClass]
public class CallableMethods_test {
  [TestMethod]
  public void callableMethods() {
    APIAnalyze obj = new APIAnalyze();
    string[] resultOfOurMethod = new string[0x1337];
    string[] rez = Task.Run(() => obj.getCallableMethods(resultOfOurMethod, @"E:\Project vs\ConsoleApp_CSharp\ConsoleApp_CSharp.sln")).Result;
    foreach(string word in rez)
      Console.Write(word);
    Assert.AreNotEqual(null, rez[0]);
    }
  }
}
