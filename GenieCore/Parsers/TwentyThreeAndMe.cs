﻿using GenieCore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GenieCore.Parsers
{
    public class TwentyThreeAndMe : Parser
    {
        public new genotypes Parse(string[] lines)
        {
            genotypes genomedata = new genotypes();
            /*
             * # This data file generated by 23andMe at: Mon Jun 21 10:14:14 2021

                # rsid	chromosome	position	genotype
                rs548049170	1	69869	TT
                rs9283150	1	565508	AA
                rs116587930	1	727841	GG
                rs3131972	1	752721	GG
                rs12184325	1	754105	CC
                rs12567639	1	756268	AA
             */

            bool gotDate = false;
            bool gotHeader = false;

            foreach (var line in lines)
            {
                string dateStart = "# This data file generated by 23andMe at: ";

                if (gotHeader)
                {
                    // snp line
                    string sep = "\t";
                    string[] ss = line.Split(sep.ToCharArray());
                    if (ss.Length != 4)
                    {
                        throw new ApplicationException("File read error - not enough column data.");
                    }

                    string rs = ss[0];
                    string cs = ss[1];
                    string pos = ss[2];
                    string gt = ss[3];

                    snp snpv = new snp()
                    {
                        position = int.Parse(pos),
                        chromosone = cs,
                        rsid = rs
                    };

                    snp_match snpm = new snp_match()
                    {
                        genotypes = gt,
                        info = snpv
                    };

                    genomedata.Add(snpm);

                }else if(line.StartsWith("# rsid"))
                {
                    gotHeader = true;
                }

                if (!gotDate && line.StartsWith(dateStart))
                {
                    gotDate = true;
                    genomedata.data_export_date = DateTime.ParseExact(line.Substring(dateStart.Length), "ddd MMM d hh:mm:ss yyyy", CultureInfo.InvariantCulture);
                    int x = 1;
                }
            }
            return genomedata;
        }
    }
}
