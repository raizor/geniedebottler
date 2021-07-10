using System;
using System.Collections.Generic;
using System.Text;

namespace GenieCore.Models
{
    public enum genotype
    {
        U = 0,
        A = 1,
        C = 2,
        G = 3,
        T = 4
    }

    public class chromosone
    {

    }

    public class chromosone_human : chromosone
    {

    }

    class snp
    {
        string rsid;
        List<genotype> genotypes = new List<genotype>();
    }

    class snp_match : snp
    {        
        int position;        
    }

    class genome : List<snp_match>
    {
    }
}
