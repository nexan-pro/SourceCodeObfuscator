using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Obfuscation {
static class Config {
  #region Rename (like easy mode)
  public static bool isRenameVars;
  public static bool isRenameMethods;
  public static bool isRenameNamespaces;
  public static bool isRenameClasses;
  #endregion
  #region (like medium mode)
  public static bool isEncryptStrings;
  public static bool isMutate;
  #endregion
  }
}
