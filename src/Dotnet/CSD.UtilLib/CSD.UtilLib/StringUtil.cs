using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.UtilLib
{
    public static class StringUtil
    {
        public static string GetRandomText(Random r, int n, string text)
        {
            string s = "";

            while (n-- > 0)
                s += text[r.Next(text.Length)];

            return s;
        }


        public static string GetRandomTextEN(int n)
        {
            return GetRandomTextEN(new Random(), n);
        }

        public static string GetRandomTextEN(Random r, int n)
        {
            return GetRandomText(r, n, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }
        

        public static string GetRandomTextTR(Random r, int n)
        {
            return GetRandomText(r, n, "abcçdefgğhıijklmnoöprsştuüvyzABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ");
        }
        

        public static string GetRandomTextTR(int n)
        {
            return GetRandomTextTR(new Random(), n);
        }
    }
}
