using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelForm
{

    public class Racun : Record
    {

        public string rr_siz { get; set ; }
        public string rr_sif { get; set; }
        public string rr_sst { get; set; }
        public string obracunsko_mjerno_mjesto_grijanje { get;  set; }
        public string obracunsko_mjerno_mjesto_voda { get;  set; }
        public string obracunska_mjerna_mjesta { get;  set; }
        public string rr_rn { get;  set; }
        public string interni_broj_racuna { get;  set; }
        public string krajnji_kupac { get;  set; }
        public string OIB { get;  set; }
        public string namjena { get;  set; }
        public string adresa_obracunskog_mjernog_mjesta { get;  set; }
        public string grad_omm{ get; set; }
        public string naziv_toplinskog_sustava { get;  set; }
        public string refundacija_od{ get;  set; }
        public string refundacija_do{ get;  set; }
        public string isporucena_toplinska_energija { get; set; }
        public string tarifni_model{get; set;}
        public string iznos_razlike_jed{get; set;}
        public double iznos_razlike{get; set;}
        public double ukupanIznosRacuna{ get; set; }
        public double ukupanIznosRacunaNakonUmanjenja{get; set;}
        public string napomena{get; set;}
        public string valuta{get; set;}

        public string toplinski_sustav { get; set; }
    }
}
