using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.Obfuscation;

namespace SRCFU5C4T0R.CLI {
class Program {
  static void Main(string[] args) {
    try {
      Console.ForegroundColor = ConsoleColor.Green;
      #region error handler for args
        if (args.Length == 0 || args == null) throw new ArgumentException("Error 0: You must supply an argument.");
        if (!File.Exists(args[0])) throw new ArgumentException($"Error 1: Input project doesn't exist: { args[0] }.");
        if (!args.Contains(Config.KEY_LITE_MODE) && !args.Contains(Config.KEY_NORMAL_MODE) && !args.Contains(Config.KEY_RENAME_CLASSES_OPT)
          && !args.Contains(Config.KEY_RENAME_METHODS_OPT) && !args.Contains(Config.KEY_RENAME_NAMESPACES_OPT) && !args.Contains(Config.KEY_RENAME_VARS_OPT))
          throw new ArgumentException("Error 2: Wrong input arguments!");
      #endregion
      Config.pathToOriginal = args[0];
      if (args[1] == Config.KEY_LITE_MODE || args[1] == Config.KEY_NORMAL_MODE) {
        Config.isRenameClasses = true;
        Config.isRenameMethods = true;
        Config.isRenameVars = true;
        Config.isRenameNamespaces = true;
        Config.isRenameMethodParams = true;
        if (args[1] == Config.KEY_NORMAL_MODE) {
          Config.isMutate = true;
          Config.isEncryptStrings = true;
        }
      }
    
    for (uint i = 1; i < args.Length - 1; ++i) {
      if (args[i] == Config.KEY_RENAME_VARS_OPT)
        Config.isRenameVars = true;
      if (args[i] == Config.KEY_RENAME_NAMESPACES_OPT)
        Config.isRenameNamespaces = true;
      if (args[i] == Config.KEY_RENAME_CLASSES_OPT)
        Config.isRenameClasses = true;
      if (args[i] == Config.KEY_RENAME_METHODS_OPT)
        Config.isRenameMethods = true;
    }
    Execute start = new Execute();
    start.process();
    Console.ResetColor();
    }
    catch(ArgumentException e) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(
$@"------------------------------------------------------------------------------
{ e.Message }
Template: SRCFU5C4T0R [input project] [mode or options]
------------------------------------------------------------------------------

=========================== Modes ============================================
--lite - this mode contain all renamers @see...
--normal - this mode contain all renamers, mutation and encrypt string @see...

========================== Options ===========================================
--rv - rename variables identifiers
--rn - rename namespaces
--rm - rename methods
--rp - rename methods parameters
--rc - rename classes

------------------------------------------------------------------------------
"
      );
      Console.ResetColor();
    }
  }
  }
}
