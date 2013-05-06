using System;
using System.Collections.Generic;
using System.Text;

namespace Dnevnik
{
    class Dnevnik
    {
        String naziv;
        String sadrzaj;
        String veza;
        String datum;
        int id;
        public Dnevnik() 
        {
            naziv = "";
            sadrzaj = "";
            veza = "";
            datum = "";
            id = 0;
        }
        public Dnevnik(String n, String s, String v, String d, int i)
        {
            naziv = n;
            sadrzaj = s;
            veza = v;
            datum = d;
            id = i;
        }
        public String dajnaziv() { return naziv; }
        public String dajsadrzaj() { return sadrzaj; }
        public String dajvezu() { return veza; }
        public String dajdatum() { return datum; }
    }
}
