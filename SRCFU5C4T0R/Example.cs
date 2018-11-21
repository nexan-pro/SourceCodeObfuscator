using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.API;
using SRCFU5C4T0R.Obfuscation;

namespace SRCFU5C4T0R {
class Example {
  static void Main(string[] args) {
    const string src = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3 {
class Program {
  public static string surname;
  static void Main(string[] args) {
    Console.WriteLine(""Hello, what's your name ?"");
    string name = readName("""");
    setSurname();
    Console.WriteLine(""Hello, "" + name + "" "" + surname);
    int var = 10;
    var +=5;
  }

  static string readName(string name) {
   name = Console.ReadLine();
   return name;
  }

  static void setSurname() {
   surname = ""qwe"";
  }
 }
}
";
    APIAnalyze obj = new APIAnalyze();
    obj.LoadCode(src);
    string[] resultOfOurMethod = new string[0x1337];
    obj.getArrayOfVariableExpressions(resultOfOurMethod);
    foreach (string word in resultOfOurMethod) {
      if(word == null) break;
      Console.WriteLine(word);
    }
  }
 }
}
