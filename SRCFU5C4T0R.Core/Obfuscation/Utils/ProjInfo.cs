using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.Kernel.API;

namespace SRCFU5C4T0R.Core.Obfuscation.Utils {
class ProjInfo : APIAnalyze {
  void printProjInfo() {
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Info about project ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("List of declared vars: ");
    printDeclareVariablesIdentifer();
  }
 }
}
