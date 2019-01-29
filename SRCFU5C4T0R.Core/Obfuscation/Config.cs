using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Core.Obfuscation {
static class Config {
  #region Keywords for options/modes
    public static readonly string KEY_LITE_MODE = "--lite";
    public static readonly string KEY_NORMAL_MODE = "--normal";
    public static readonly string KEY_RENAME_VARS_OPT = "--pv";
    public static readonly string KEY_RENAME_NAMESPACES_OPT = "--rn";
    public static readonly string KEY_RENAME_CLASSES_OPT = "--rc";
    public static readonly string KEY_RENAME_METHODS_OPT = "--rm";
  #endregion
  #region File structure
    public static string pathToOriginal;
    public static string pathToObfuscated;
  #endregion
  #region Renamers (like easy mode)
    public static bool isRenameVars;
    public static bool isRenameMethods;
    public static bool isRenameNamespaces;
    public static bool isRenameClasses;
    public static bool isRenameMethodParams;
  #endregion
  #region  (like medium mode)
    public static bool isEncryptStrings;
    public static bool isMutate;
  #endregion
  }
}
