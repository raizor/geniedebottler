using GenieCore.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GenieCore
{
    public enum snp_fetch_result
    {
        Unset,
        Found,
        NotFound
    }

    public class snp_fetch_data
    {
        public snp snp_data;
        public snp_fetch_result result;

        public snp_fetch_data()
        {
            snp_data = new snp();
        }
    }

    /*
    public class snp_property
    {
        public string genotypes = String.Empty;
        public float magnitude = 0.0f;
        public string summary = String.Empty;
    }

    public class snp
    {
        public int position = -1;
        public string rsid = string.Empty;
        public string prev_rsid = string.Empty;
        public string description = string.Empty;
        public string gene = string.Empty;
        public List<snp_property> properties = new List<snp_property>();
        public string chromosone = string.Empty;
        public bool plusOrientation = false;
        public bool plusStabilized = false;
        public string reference = string.Empty;
        public float max_magnitude = 0.0f;
        public float gmaf = 0.0f;
        public string notes_html = string.Empty;
    }     
     */

    public class SnpGrabber
    {
        public static snp_fetch_data GetSnp()
        {
            snp_fetch_data data = new snp_fetch_data();

            try
            {
                var url = "https://www.snpedia.com/index.php/Rs1815739";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                data.result = snp_fetch_result.Found;

                // chrome:      /html/body/div[1]/div[6]/div/div/div[3]/div[1]/div
                // htmlagility: /html[1]/body[1]/div[1]/div[6]/div[1]/div[1]/div[3]/div[1]

                // get SNP RSID
                string rsid = doc.GetElementbyId("firstHeading").InnerText;
                data.snp_data.rsid = rsid;

                // get SNP desc.
                HtmlNode node_td_description = doc.DocumentNode.SelectSingleNode("//*[@id=\"mw-content-text\"]/div/div[1]/table[1]/tbody/tr/td");
                data.snp_data.description = node_td_description.InnerText;

                // get geno table items
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div/div[1]/table[4]/tbody/tr");

                for (int r = 1; r < nodes.Count; r++)
                {
                    HtmlNodeCollection cols = nodes[r].SelectNodes("td");
                    string gt = cols[0].InnerText;
                    gt = "" + gt[1] + gt[3];

                    snp_property prop = new snp_property()
                    {
                        genotypes = gt,
                        magnitude = float.Parse(cols[1].InnerText),
                        summary = cols[2].InnerText,
                    };
                    data.snp_data.properties.Add(prop);

                }
              

                // //*[@id="mw-content-text"]/div/div[1]/table[4]

                // //*[@id="mw-content-text"]/div/div[1]/table[4]/tbody/tr[1]
                int x = 1;
            }
            catch(Exception ex)
            {
                Debugger.Break();
            }
            return data;
        }

    }
}
