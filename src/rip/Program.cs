using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace rip
{
    class Program
    {
        static bool Agro = false;
        static int Count = 101;
        static bool Remove = false;
        static bool Verbose = false;
        static bool Zero = false;
        static bool Banner = true;
        static List<string> Files = new List<string>();
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            try
            {
                if (args.Length > 0)
                {
                    foreach (string arg in args)
                    {
                        if (arg == "-h" || arg == "--help")
                        {
                            PrintHelp();
                            return;
                        }
                        if (arg == "-a" || arg == "--agro")
                            Agro = true;
                        if (arg == "-r" || arg == "--remove")
                            Remove = true;
                        if (arg == "-v" || arg == "--verbose")
                            Verbose = true;
                        if (arg == "-z" || arg == "--zero")
                            Zero = true;
                        if (arg == "-n" || arg == "--no-banner")
                            Banner = false;
                        if (arg.StartsWith("-c=") || arg.StartsWith("--count="))
                        {
                            string c = arg.Substring(arg.IndexOf('=') + 1);
                            try
                            {
                                Count = int.Parse(c) + 1;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }

                        }
                        else
                        {
                            if (!arg.StartsWith("-"))
                                Files.Add(arg);
                        }
                    }
                    if (Banner)
                        Console.WriteLine("{0} v{1}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                    foreach (string f in Files)
                    {
                        if (Verbose)
                            Console.WriteLine("Getting File Size");
                        long l = new FileInfo(f).Length;
                        if (Verbose)
                            Console.WriteLine("File is {0} Bytes.", l);
                        if (Verbose)
                            Console.WriteLine("Initial Overwrite");
                        try
                        {
                            if (l <= 10)
                            {
                                byte[] fill = new byte[l*4];
                                new Random((int)(0xFF + (l / 2)) * DateTime.Now.Millisecond).NextBytes(fill);
                                File.WriteAllBytes(f,fill);
                                l = new FileInfo(f).Length;
                            }
                            for (int i = 0; i < Count; i++)
                            {
                                byte[] bar = new byte[l];
                                new Random((int)((16 + l) * DateTime.Now.Millisecond)).NextBytes(bar);
                                for (int k = 0; k < bar.Length -1; k++)
                                {
                                    bar[k] = (byte)new Random((int)bar[k] * 0xf8).Next(0, 256);
                                }
                                File.WriteAllBytes(f, bar);
                                if (Verbose)
                                {
                                    StringBuilder sb = new StringBuilder(20);
                                    for (int j = 0; j < 10; j++)
                                    {
                                        sb.AppendFormat("  0x{0:x2}", bar[j]);
                                    }
                                    Console.WriteLine("Pass: {0} First 10 Bytes {1}", i, sb.ToString().ToUpperInvariant());
                                }
                                if (Agro)
                                {
                                    byte[] agrp = new byte[] { 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0xAF, 0xBE, 0xCD };
                                    if (Verbose)
                                        Console.WriteLine("{0} {1} Passes'", l, "Fixed Pattern");
                                    for (int m = 0; m < l; m++)
                                    {
                                        File.WriteAllBytes(f, agrp);
                                    }
                                    if (Verbose)
                                        Console.WriteLine("35 Double Size Passes");
                                    for (int n = 0; n < 35; n++)
                                    {
                                        byte[] buf = new byte[l * 2];
                                        new Random((int)((16 + l) * DateTime.Now.Millisecond)).NextBytes(buf);
                                        for (int k = 0; k < buf.Length - 1; k++)
                                        {
                                            buf[k] = (byte)new Random((int)buf[k] * 0xf8).Next(0, 256);
                                        }
                                        File.WriteAllBytes(f, buf);
                                    }
                                    if (Verbose)
                                        Console.WriteLine("{0} Odd Man Out Passes'", (l / 2));
                                    for (int o = 0; o < (l / 2); o++)
                                    {
                                        byte[] odd = new byte[l + 2];
                                        new Random((int)((16 + l) * DateTime.Now.Millisecond)).NextBytes(odd);
                                        for (int k = 0; k < odd.Length; k++)
                                        {
                                            odd[k] = (byte)new Random((int)odd[k] * 0xE2).Next(0, 256);
                                            if (odd[k] % 2 == 0)
                                            {
                                                int v = ((odd[k] % 1 == 0)) ? (byte)(odd[k] % 1) + 1 : (byte)(odd[k] % 3);
                                                odd[k] = (byte)v;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                            return;
                        }
                        if (Zero)
                        {
                            if (Verbose)
                                Console.WriteLine("Zeroing Out");
                            byte[] zip = new byte[l];
                            for (int i = 0; i < zip.Length; i++)
                            {
                                zip[i] = 0x00;
                            }
                            File.WriteAllBytes(f, zip);
                        }
                        if (Remove)
                        {
                            if (Verbose)
                                Console.WriteLine("Deleting {0}", f);
                            File.Delete(f);
                        }
                    }
                }
                else
                {
                    PrintHelp();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catastrophic Failure: {0}", ex.Message);
                return;
            }
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Halt Key Pressed. Stopping...");
        }
        static void PrintHelp()
        {
            Console.WriteLine("[*] Usage: rip [OPTIONS] [FILE]");
            Console.WriteLine("[*] Overwrites the specified file repeatedly in order");
            Console.WriteLine("[*] To Make it harder for even the most expensive");
            Console.WriteLine("[*] Data Recovery Tools to recover the data");
            Console.WriteLine();
            Console.WriteLine("[*] Arguments: ");
            Console.WriteLine("[*]  -a, --agro\tHave Rip use The Aggressive Mode, With multiple algorithmic rewrites per pass");
            Console.WriteLine("[*]  -c=N, --count=N\tOverwrite N times instead of the default (100)");
            Console.WriteLine("[*]  -n, --no-banner\t Remove the Rip Banner When Rip Executes"); 
            Console.WriteLine("[*]  -r, --remove\tRemove the File After Shredding");
            Console.WriteLine("[*]  -v, --verbose\tTell's Rip to show Progress");
            Console.WriteLine("[*]  -z, --zero\tOverwrite the File with Zeros to hide shredding");
        }
    }
}
