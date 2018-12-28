using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Core.Obfuscation.Utils {
class String {
  public static string to_SHA1(string sample) {
    byte[] hash;
    using(var sha1 = new SHA1CryptoServiceProvider())
      hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(sample));
    var sb = new StringBuilder();
    foreach(byte current in hash)
      sb.AppendFormat("{0:x2}", current);
      string tmp = sb.ToString();
    for (uint i = 0; i < 8; ++i) {
      tmp += "ᵈᵉᵃᵈᶜᵒᵈᵉ";
      }
    return tmp;
  }

  public static string to_Tiny(string str) {
    char[] characters = str.ToCharArray();
    string tmp = null;
    for (uint i = 0; i < str.Length; ++i) {
      switch(characters[i]) {
        case 'a': characters[i] = 'ᵃ'; break;
        case 'b': characters[i] = 'ᵇ'; break;
        case 'c': characters[i] = 'ᶜ'; break;
        case 'd': characters[i] = 'ᵈ'; break;
        case 'e': characters[i] = 'ᵉ'; break;
        case 'f': characters[i] = 'ᶠ'; break;
        case 'g': characters[i] = 'ᵍ'; break;
        case 'h': characters[i] = 'ʰ'; break;
        case 'i': characters[i] = 'ᶦ'; break;
        case 'j': characters[i] = 'ʲ'; break;
        case 'k': characters[i] = 'ᵏ'; break;
        case 'l': characters[i] = 'ˡ'; break;
        case 'm': characters[i] = 'ᵐ'; break;
        case 'n': characters[i] = 'ⁿ'; break;
        case 'o': characters[i] = 'ᵒ'; break;
        case 'p': characters[i] = 'ᵖ'; break;
        case 'q': characters[i] = 'ᵠ'; break;
        case 'r': characters[i] = 'ʳ'; break;
        case 's': characters[i] = 'ˢ'; break;
        case 't': characters[i] = 'ᵗ'; break;
        case 'u': characters[i] = 'ᵘ'; break;
        case 'v': characters[i] = 'ᵛ'; break;
        case 'w': characters[i] = 'ʷ'; break;
        case 'x': characters[i] = 'ˣ'; break;
        case 'y': characters[i] = 'ʸ'; break;
        case 'z': characters[i] = 'ᶻ'; break;
       }
       tmp += characters[i];
    }
    return tmp;
  }
}
}
