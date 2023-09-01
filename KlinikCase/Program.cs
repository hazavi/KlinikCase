using KlinikCase.Codes;

namespace KlinikCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patienter = new List<Patient>();
            List<Læge> læger = new List<Læge>();

            //Tilføjer Læger til listen
            Læge øjenlæge = new Læge("Peter", "Hansen", 11111111, "Øjenlæge");
            Læge radiologi = new Læge("Martin", "Jensen", 22222222, "Radiologi");
            Læge kirurgi = new Læge("Thomas", "Olsen", 33333333, "Kirurgi");
            Læge onkologi = new Læge("Ole", "Nielsen", 44444444, "Onkologi");

            Læge tandlæge = new Læge("Bruce", "Wayne", 55555555, "TandLæge");
            Læge neurolog = new Læge("Mary", "Jane", 66666666, "Neurolog");

            læger.Add(øjenlæge);
            læger.Add(radiologi);
            læger.Add(kirurgi);
            læger.Add(onkologi);
            læger.Add(tandlæge);
            læger.Add(neurolog);

            while (true)
            {
                Console.WriteLine("Vælg en handling:");
                Console.WriteLine("1. Opret patient");
                Console.WriteLine("2. Tilføj læge til patient");
                Console.Write("3. Vis Patient info \nvalg: ");

                int valg = Int32.Parse(Console.ReadLine());

                // Opret patient
                if (valg == 1)
                {
                    Console.Write("Patient Fornavn: ");
                    string fornavn = Console.ReadLine();

                    Console.Write("Patient Efternavn: ");
                    string efternavn = Console.ReadLine();

                    Console.Write("Patient Tlf.nr.: ");
                    int tlfnr = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Vælg en læge til patienten:");
                    for (int i = 0; i < læger.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {læger[i].ForNavn} ({læger[i].Specialitet})");
                    }

                    int lægeValg = Int32.Parse(Console.ReadLine()) - 1;

                    if (lægeValg < 0 || lægeValg >= læger.Count)
                    {
                        Console.WriteLine("Ugyldigt valg.");
                        break;
                    }

                    Læge valgtLæge = læger[lægeValg];

                    Patient patient = new Patient(fornavn, efternavn, tlfnr);
                    patient.TildelLæge(valgtLæge);
                    patienter.Add(patient);
                    Console.WriteLine(patient.ShowInfo());

                    Console.WriteLine("\nPatienten er oprettet!");
                   
                }
                // Tilføj læge til patient
                if (valg == 2)
                {
                    TilføjLæge.TilføjLægeTilPatient(patienter,læger);
                }

                // Vis patientinfo
                if (valg == 3)
                {
                    Console.Clear();

                    Console.WriteLine("Vælg en patient for at vise info:");
                    for (int i = 0; i < patienter.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {patienter[i].ForNavn} {patienter[i].EfterNavn}");
                    }

                    int infoValg = Int32.Parse(Console.ReadLine()) - 1;

                    if (infoValg < 0 || infoValg >= patienter.Count)
                    {
                        Console.WriteLine("Ugyldigt valg.");
                        break;
                    }

                    Patient valgtPatient = patienter[infoValg];

                    Console.WriteLine(valgtPatient.ShowInfo());

                }
                else if (valg == 4) 
                {
                    return;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}