namespace CaesarCypherCode1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // CaesarCypher.Encode("Zob", 3);
        string answer = CaesarCypher.Crack("Xli ibxirhih evq wepyxmrk kiwxyvi aew eppikih xs fi fewih sr er ergmirx Vsqer " +
                           "gywxsq, fyx rs orsar Vsqer asvo sj evx hitmgxw mx, rsv hsiw erc ibxerx Vsqer xibx " +
                           "higmfi mx. Lmwxsmerw lezi mrwxieh hixivqmrih xlex xli kiwxyvi svmkmrexih jvsq " +
                           "Neguyiw-Psymw Hezmh'w 1784 temrxmrk Sexl sj xli Lsvexmm, almgl hmwtpecih e" +
                           "vemwih evq wepyxexsvc kiwxyvi mr er ergmirx Vsqer wixxmrk. Xli kiwxyvi erh mxw" +
                           "mhirmjmgexmsr amxl ergmirx Vsqi aew ehzergih mr sxliv Jvirgl risgpewwmg evx.");
        string answer2 =
            CaesarCypher.Crack(
                "Bpx fivvwi lezi mwx gsqtpixr xmppmrk! Lsa xlmw hi sj wxs qegmgxmrk sj xli wmziivmrk! Hievsyx lezi mr wxs mwx xlmw, tpevi xlmw mwx qmqip.");
    }
}