using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Obfuscation.Utils {
class String {
  public static string to_SHA1(string sample) {
    byte[] hash;
    using(var sha1 = new SHA1CryptoServiceProvider())
      hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(sample));
    var sb = new StringBuilder();
    foreach(byte current in hash)
      sb.AppendFormat("{0:x2}", current);
    return sb.ToString();
  }
 }
}
