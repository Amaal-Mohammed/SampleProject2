using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Testdata
{
    class ReadData
    {
        public static String Customerfirstname;
        public static String Customerlastname;
        public static String Password;
        public static String FirstName;
        public static String LastName;
        public static String Company;
        public static String Address;
        public static String City;
        public static String State;
        public static String Postal;

        public static String Phone;
        public static String Mobile;
        public static String Shirt;
        public static void setData(String P)
        {
            String path = P + "\\" + Constants.filename;
            List<String> data = ExcelRead.ReadExcel(path, Constants.Sheet);
            Customerfirstname = data[0];
            Customerlastname = data[1];
            Password = data[2];
            FirstName = data[3];
            LastName = data[4];
            Company = data[5];
            Address = data[6];
            City = data[7];
            State = data[8];
            Postal = data[9];

            Phone = data[10];
            Mobile = data[11];
            Shirt = data[12];



        }
    
    }
}
