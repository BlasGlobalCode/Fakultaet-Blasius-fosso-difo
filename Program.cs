using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät_Lb09_Blasius
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte die Untergrenze wählen: ");
            int lower = int.Parse(Console.ReadLine());
            Console.Write("Bitte die Obergrenze wählen: ");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine("Bitte erraten Sie die gesuchte Zahl, sie befindet sich zwischen {0} und {1}.", lower, upper);
            int random = GetRandom(lower, upper);
            int versuch = 5;
            List<int> eingaben = new List<int>();

            do
            {
                Console.Write("Ihr {0:00}. Versuch: ", versuch);
                string input = Console.ReadLine();
                int eingabe = 0;

                bool isZahl = int.TryParse(input, out eingabe);
                if (isZahl)
                {
                    if (eingabe < lower || eingabe > upper)
                    {
                        Console.WriteLine("Die eingegebene Zahl befindet sich außerhalb des von Ihnen definierten Bereichs.");
                    }
                    else
                    {
                        if (eingaben.Contains(eingabe))
                        {
                            Console.WriteLine("Mit dieser Zahl haben Sie es schon einmal versucht!");
                        }
                        else
                        {
                            eingaben.Add(eingabe);
                            if (eingabe > random)
                            {
                                Console.WriteLine("Die gesuchte Zahl ist kleiner.");
                            }
                            else if (eingabe < random)
                            {
                                Console.WriteLine("Die gesuchte Zahl ist größer.");
                            }
                            else
                            {
                                Console.WriteLine("Glückwunsch die von Ihnen eingegebene Zahl ({0}) stimmt mit der gesuchten Zahl überein.", random);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bitte nur Z A H L E N eingeben.");
                }
                versuch++;
            } while (eingaben.LastOrDefault() != random);
        }

        private static int GetRandom(int lower, int upper)
        {
            Random r = new Random();
            return r.Next(lower, upper);
        }
    }
    
}

 