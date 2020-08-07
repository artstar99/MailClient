using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security;

namespace TestConsole
{
    class Program
    {
        //private static string password = "adey687#kRi)";
        
        static void Main(string[] args)
        {


            string s = "sghj@.com";

            if (s.Contains("@."))

            Console.WriteLine($"Добро");
            else Console.WriteLine("Зло");


            //string password = "azZ~dey687#kRi)";

            //string b = "azZ~dey687#kRi)";

            //PasswordEncrypter encrypter = new PasswordEncrypter(password);

            //Console.WriteLine($"Исходный пароль:\t{password}");

            //Console.WriteLine($"Зашифрованный пароль:\t{ encrypter.encryptedPassword}");

            //Console.WriteLine($"Расшифрованый пароль:\t{encrypter.Decrypt()}");


            //string tmp = encrypter.Decrypt();


            //Console.WriteLine(tmp.Equals(password));
            //Console.WriteLine($"{tmp}\n{password}");


            //Console.WriteLine(Equals(password, tmp));

            Console.ReadKey();
        }


    }
}
