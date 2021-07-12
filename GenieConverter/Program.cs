using GenieCore;
using GenieCore.Models;
using GenieCore.Parsers;
using System;
using System.IO;

namespace GenieConverter
{
    class Program
    {
        const string fpath = @"C:\Users\joemc\source\repos\GenieDebottler\data\genome_Joe_M_v5_Full_20210621101411.txt";

        static void Main(string[] args)
        {
            snp_fetch_data result = SnpGrabber.GetSnp();

            Console.WriteLine("Importing: "+ fpath);
            TwentyThreeAndMe t3 = new TwentyThreeAndMe();
            string[] lines = File.ReadAllLines(fpath);
            genotypes data = t3.Parse(lines);
        }
    }
}
