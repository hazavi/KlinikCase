using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KlinikCase.Codes
{
    public class Patient : Person
    {
        public List<Læge> TildelteLæge { get; } = new List<Læge>();

        public Patient(string fornavn, string efternavn, int tlfnr) : base(fornavn,efternavn,tlfnr)
        {
            TildelteLæge = new List<Læge>();

        }

        public void TildelLæge(Læge læge)
        {
            // Tjek for kombinationen af Kirurgi og Onkologi
            if ((TildelteLæge.Exists(l => l.Specialitet == "Kirurgi") || TildelteLæge.Exists(l => l.Specialitet == "Onkologi")) &&
                (læge.Specialitet == "Kirurgi" || læge.Specialitet == "Onkologi"))
            {
                throw new Exception("Advarsel: En patient kan ikke have både Kirurgi og Onkologi læger tildelt samtidig.");
            }

            // Tjek antallet af patienter tildelt lægen
            if (TildelteLæge.FindAll(l => l.ForNavn == læge.ForNavn).Count >= 3)
            {
                throw new Exception("Advarsel: Lægen har allerede 3 eller flere patienter.");
            }

            TildelteLæge.Add(læge);
        }

        public override string ShowInfo()
        {
            string patientInfo = $"\nPatient: {ForNavn} {EfterNavn}\nTlf: {TlfNr} \nTilknyttede læger:\n";


            foreach (var læge in TildelteLæge)
            {
                patientInfo += $"- {læge.ForNavn} {læge.EfterNavn} ({læge.Specialitet})\n";
            }

            return patientInfo;
        }
    }
}
