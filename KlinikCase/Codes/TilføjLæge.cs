using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikCase.Codes
{
    internal class TilføjLæge
    {

        public static void TilføjLægeTilPatient(List<Patient> patienter, List<Læge> læger)
        {
            Console.Clear();

            if (patienter.Count == 0)
            {
                Console.WriteLine("Der er ingen patienter oprettet endnu.");
                return;
            }

            // Vælg en patient
            Console.WriteLine("Vælg en patient:");
            VisPatienter(patienter);

            int patientValg = VælgIndeks(patienter.Count);

            if (patientValg == -1)
            {
                Console.WriteLine("Ugyldigt valg.");
                return;
            }

            // Vælg en læge
            Console.WriteLine("Vælg en læge:");
            VisLæger(læger);

            int lægeValg = VælgIndeks(læger.Count);

            if (lægeValg == -1)
            {
                Console.WriteLine("Ugyldigt valg.");
                return;
            }

            // Tildel lægen til patienten
            Patient valgtPatient = patienter[patientValg];
            Læge valgtLæge = læger[lægeValg];

            valgtPatient.TildelLæge(valgtLæge);

            Console.WriteLine("Lægen er tilføjet til patienten.");
        }

        // Metode til at vise patienter
        public static void VisPatienter(List<Patient> patienter)
        {
            for (int i = 0; i < patienter.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {patienter[i].ForNavn} {patienter[i].EfterNavn}");
            }
        }

        // Metode til at vælge en indeks
        public static int VælgIndeks(int maxIndeks)
        {
            int valg = Int32.Parse(Console.ReadLine()) - 1;

            if (valg < 0 || valg >= maxIndeks)
            {
                return -1; // Ugyldigt valg
            }

            return valg;
        }

        // Metode til at vise læger
        public static void VisLæger(List<Læge> læger)
        {
            for (int i = 0; i < læger.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {læger[i].ForNavn} ({læger[i].Specialitet})");
            }
        }


    }
}
