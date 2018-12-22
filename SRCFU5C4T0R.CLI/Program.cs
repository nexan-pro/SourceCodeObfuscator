using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Obfuscation;

namespace SRCFU5C4T0R.CLI {
class Program {
  static void Main(string[] args) {
  try {
    Console.ForegroundColor = ConsoleColor.Green;
    Config.pathToOriginal = args[0];
    Config.pathToObfuscated = args[args.Length - 1];
    if (args[1] == "--lite" || args[1] == "--normal") {
      Config.isRenameClasses = true;
      Config.isRenameMethods = true;
      Config.isRenameVars = true;
      Config.isRenameNamespaces = true;
      Config.isRenameMethodParams = true;
      if (args[1] == "--normal") {
        Config.isMutate = true;
        Config.isEncryptStrings = true;
      }
    }
    for (uint i = 1; i < args.Length - 1; ++i) {
      if (args[i] == "--rv")
        Config.isRenameVars = true;
      if (args[i] == "--rn")
        Config.isRenameNamespaces = true;
      if (args[i] == "--rc")
        Config.isRenameClasses = true;
      if (args[i] == "--rm")
        Config.isRenameMethods = true;
    }
    Execute start = new Execute();
    start.process();
    Console.ResetColor();
    }
    catch {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(
@"
Template: SRCFU5C4T0R [input project] [mode or options] [output file]
------------------------------------------------------------------------------
=========================== Modes ============================================
--lite - this mode contain all renamers @see...
--normal - this mode contain all renamers, mutation and encrypt string @see...
------------------------------------------------------------------------------
========================== Options ===========================================
--rv - rename variables identifiers
--rn - rename namespaces
--rm - rename methods
--rp - rename methods parameters
--rc - rename classes
"
      );
      Console.ResetColor();
    }
   }
  }
}
