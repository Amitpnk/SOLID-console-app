using System;

namespace ISP.Problem
{
    public interface IPrintContent
    {
        bool PrintContent(string content);
    }

    public interface IFaxContent
    {
        bool FaxContent(string content);
    }

    public interface IPhotoCopyContent
    {
        bool PhotoCopyContent(string content);
        bool ScanContent(string content);
    }

    public class HPPrint : IPrintContent, IFaxContent, IPhotoCopyContent
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
