using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCFU5C4T0R.Obfuscation.Utils {
    class String {
        public static string getRandomStr(int count) {
            string symbols = "AaBbCcDdEeFfGgHhIiJjKkLlMmN0nOo1PpQq2RrSs3Tt4Uu5Vv6W7wX8xY9yZz";
            string randomString = "__0x" + count;
            Random rand = new Random();
            for (UInt16 i = 0; i < count; i++)
                randomString += symbols[rand.Next(symbols.Length)];
            return (randomString);
        }
    }
}
