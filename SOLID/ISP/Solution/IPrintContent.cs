using System;

namespace ISP.Problem
{
    public interface IPrintContent
    {
        bool FaxContent(string content);
        bool PhotoCopyContent(string content);
        bool PrintContent(string content);
        bool ScanContent(string content);
    }

    public class HPPrint : IPrintContent
    {
        public bool FaxContent(string content)
        {
            Console.WriteLine("Fax functionality");
            return true;
        }

        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy functionality");
            return true;
        }

        public bool PrintContent(string content)
        {
            Console.WriteLine("Print functionality");
            return true;
        }

        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan functionality");
            return true;
        }
    }
}
