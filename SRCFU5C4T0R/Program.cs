using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRCFU5C4T0R.Core.API;
using SRCFU5C4T0R.Obfuscation;

namespace SRCFU5C4T0R {
    class Program {
        static void Main(string[] args) {
            const string src = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg
{
class Program
    {
        static void Main(string[] args)
        {
            string str = ""de"";
        }
    }
}
";
            RenameVarsIdentifer obj = new RenameVarsIdentifer();
            Console.WriteLine(obj.renameVarsIdentifer("qwe"));
            //Console.WriteLine(Obfuscation.Utils.String.getRandomStr(5));
        }
    }
}
