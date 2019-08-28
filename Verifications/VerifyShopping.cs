using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Verifications
{
    class VerifyShopping
    {
        public static void Verifytxt(String text)
        {
            
                Assert.IsTrue(text.Contains("Your order on My Store is complete."));
           
           }
    }
}
