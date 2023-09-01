using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikCase.Codes
{
    public class Læge : Person
    {
        public string Specialitet { get; set; }
        public List<Patient> TildeltePatient { get; } = new List<Patient>();

        public Læge(string fornavn, string efternavn, int tlfnr, string specialitet) : base (fornavn, efternavn, tlfnr)
        {
            Specialitet = specialitet;
        }


        public override string ShowInfo()
        {
            List<Patient> patienter = new List<Patient>();
            List<Læge> læger = new List<Læge>();

            string lægeInfo = $"Læge: {ForNavn} {EfterNavn} \nTlf: {TlfNr} \n({Specialitet}) \nTilknyttede patienter:";


            foreach (Læge læge in læger)
            {
                lægeInfo += $"{ForNavn} ({Specialitet}";

                foreach (Patient patient in patienter)
                {

                    lægeInfo += $"- {patient.ForNavn} {patient.EfterNavn}";
                    
                }
            }
            return lægeInfo;
        }


    }
}
