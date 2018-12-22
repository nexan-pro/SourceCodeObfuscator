using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using SRCFU5C4T0R.Core.API;
using SRCFU5C4T0R.Obfuscation;
using SRCFU5C4T0R.Obfuscation.Renamers;

namespace SRCFU5C4T0R {
class Example {
  static void main(string[] args) {
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
        int v = 4;
        var = 21 + 71;
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
    obj.getArrayOfVarsInitAndOperations(resultOfOurMethod);
    foreach(string word in resultOfOurMethod) {
      if(word == null) break;
      Console.WriteLine(word);
      }
    }
  }
}