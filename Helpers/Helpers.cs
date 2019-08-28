using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Helpers
{
    class Helpers
    {
        public static String generateEmail()
        {
            Random rnd = new Random();
            int usernameber = rnd.Next(1, 100000);
            String fuser = "user" + usernameber;
            String emailtxt = fuser + "@gmail.com";
            return emailtxt;
        }
    }
}
