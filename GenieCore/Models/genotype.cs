using System;
using System.Collections.Generic;
using System.Text;

namespace GenieCore.Models
{
    public class genotypes : List<snp_match>
    {
        public DateTime data_export_date;
    }

    public class genotypes_human : genotypes
    {
        public genotypes_human()
        {

        }
    }

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

    public class snp_match
    {
        public snp info;
        public string genotypes = String.Empty;
    }
}
