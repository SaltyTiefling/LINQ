using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQT
{
    class Program
    {
        static void Main(string[] args)
        {
            //DATA SOURCE
            string[] namen = { "Latha", "Antal", "Yannick", "Sujithra" };

            //LINQ QUERY
            var mijnQuery = from naam in namen where naam.ToUpper().Contains('T') select naam;

            //NOTEREN
            foreach (var naam in mijnQuery)
            {
                Console.WriteLine(naam);
            }

            Console.WriteLine();

            //NOTEER DE ARRAY IN EEN STRING
            var kommaString = namen.Aggregate((s1, s2) => s1.ToUpper() + ", " + s2);;
            Console.WriteLine(kommaString);
            Console.WriteLine();


            //DATA SOURCE
            int[] getallen = { 10, 20, 30, 40, 50 };
            int[] getallen2 = { 60, 70, 80, 90, 100 };

            //KRIJG DE AVERAGE //MIN, MAX, COUNT, AVERAGE, SUM
            var average = getallen.Min(g => g);
            Console.WriteLine(average);
            Console.WriteLine();

            //First
            var first = getallen.First();
            Console.WriteLine(first);
            Console.WriteLine();

            //Concat
            var getallen3 = getallen.Concat(getallen2);

            foreach (var item in getallen3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //DATA SOURCE
            List<string> mijnList = new List<string>()
            {
                "dit is een leuke les",
                "deze les is stom",
                "het is zonnig vandaag",
                "is de les bijna gedaan",
                "koekjes zijn lekker"
            };

            //LINQ QUERY SYNTAX
            var resultaat = from les in mijnList where les.Contains("les") select les;

            //LINQ QUERY METHOD (LAMBDA)
            var resultaat2 = mijnList.Where(les => les.Contains("les"));

            //NOTEREN
            foreach (var les in resultaat)
            {
                Console.WriteLine(les);
            }

            Console.WriteLine();

            foreach (var les in resultaat2)
            {
                Console.WriteLine(les);
            }

            Console.WriteLine();



            //DATA SOURCE
            List<Student> studentenList = new List<Student>()
            {
                new Student(1, 18, "Jozef"),
                new Student(2, 21, "Rik"),
                new Student(3, 18, "Bart"),
                new Student(4, 21, "Mike"),
                new Student(5, 16, "roel"),
            };

            //Student(1, 18, "Jozef"),
            //Student(3, 18, "Bart"),
            //Student(5, 16, "Roel"),

            //LINQ QUERY SYNTAX
            var teenagers = from s in studentenList where s.Leeftijd >= 15 && s.Leeftijd <= 20 select s
                            into t where t.Naam.StartsWith("B") select t;

            //LINQ QUERY METHOD (LAMBDA)
            var teenagers2 = studentenList.Where(s => s.Leeftijd >= 15 && s.Leeftijd <= 20)/*.ToList<Student>()*/;

            //LINQ QUERY METHOD (LAMBDA)
            var teenagers3 = studentenList.Where((s, i) =>
            {
                //return (i % 2 == 0); doet hetzelfde
                if (i % 2 == 0)
                    return true;
                else
                    return false;
            });

            //LINQ QUERY SYNTAX
            var teenagers4 = from s in studentenList where s.Leeftijd >= 15 where s.Leeftijd <= 20 select s;

            //LINQ QUERY METHOD (LAMBDA)
            var teenagers5 = studentenList.Where(s => s.Leeftijd >= 15).Where(s => s.Leeftijd <= 20);

            //LINQ QUERY SYNTAX
            var teenagers6 = from s in studentenList orderby s.Leeftijd, s.Naam select s;

            //LINQ QUERY METHOD (LAMBDA)
            var teenagers7 = studentenList.OrderByDescending(s => s.Leeftijd).ThenByDescending(s => s.Naam);

            //LINQ QUERY SYNTAX
            var teenagers8 = from s in studentenList group s by s.Leeftijd;

            //LINQ QUERY SYNTAX
            var teenagers9 = from s in studentenList
                             let ls = s.Naam.ToLower() //ls = lowercasestudent
                             where ls.StartsWith("r")
                             select ls;

            //LINQ QUERY METHOD (LAMBDA)
            var volwassen = studentenList.All(s => s.Leeftijd >= 18);
            
            //LINQ QUERY METHOD (LAMBDA)
            var anyVolwassen = studentenList.Any(s => s.Leeftijd < 15);

            Console.WriteLine(volwassen);
            Console.WriteLine();

            Console.WriteLine(anyVolwassen);
            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers)
            {
                Console.WriteLine(s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers2)
            {
                Console.WriteLine(s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers3)
            {
                Console.WriteLine(s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers4)
            {
                Console.WriteLine(s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers5)
            {
                Console.WriteLine(s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers6)
            {
                Console.WriteLine(s.Leeftijd + " " + s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers7)
            {
                Console.WriteLine(s.Leeftijd + " " + s.Naam);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var leeftijdGroep in teenagers8)
            {
                Console.WriteLine("--Leeftijd groep {0}--", leeftijdGroep.Key);

                foreach (Student student in leeftijdGroep)
                {
                    Console.WriteLine(student.Naam);
                }
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var s in teenagers9)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();


            //DATA SOURCES
            List<string> mijnList1 = new List<string>()
            {
                "Een", "Twee", "Drie", "Vier"
            };

            List<string> mijnList2 = new List<string>()
            {
                "Een", "Twee", "Vijf", "Zes"
            };

            //LINQ QUERY METHOD (LAMBDA)
            var joinedList = mijnList1 //EERSTE LIST
                .Join(mijnList2, //TWEEDE LIST
                str1 => str1, //EERSTE LIST KEY
                str2 => str2, //TWEEDE LIST KEY
                (str1, str2) => str1); //RESULTAAT SELECTEREN

            //NOTEREN
            foreach (var value in joinedList)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            //DATA SOURCE
            List<Persoon> personenList = new List<Persoon>()
            {
                new Persoon(1, 1, "Jozef"),
                new Persoon(2, 1, "Rik"),
                new Persoon(3, 2, "Bart"),
                new Persoon(4, 2, "Mike"),
                new Persoon(5, 3, "Roel"),
            };

            List<Badge> badgeList = new List<Badge>()
            {
                new Badge(1, "Parking"),
                new Badge(2, "Gebouw"),
                new Badge(3, "Kantoren")
            };

            //LINQ QUERY SYNTAX
            var joinedList1 = from persoon in personenList
                              join badge in badgeList
                              on persoon.TypeId equals badge.TypeId
                              select new
                              {
                                  PersoonNaam = persoon.Naam,
                                  BadgeOpschrift = badge.Opschrift
                              };

            //LINQ QUERY METHOD (LAMBDA)
            var joinedList2 = personenList //EERSTE LIST
                .Join(badgeList, //TWEEDE LIST
                persoon => persoon.TypeId, //EERSTE LIST 
                badge => badge.TypeId, //TWEEDE LIST
                (persoon, badge) => new //RESULTAAT SELECTEREN
                {
                    PersoonNaam = persoon.Naam,
                    BadgeOpschrift = badge.Opschrift
                });

            var groupJoin = badgeList.GroupJoin(personenList,
                badge => badge.TypeId,
                persoon => persoon.TypeId,
                (badge, IdTier) => new
                {
                    Personen = IdTier,
                    Opschrift = badge.Opschrift
                });



            /*//LINQ QUERY METHOD (LAMBDA)
            var groupJoinedList = personenList
                .GroupJoin(badgeList,
                persoon => persoon.TypeId,
                badge => badge.TypeId,
                (persoon, badgeGroup) => new
                {
                    Personen = badgeGroup,
                    Badgenaam = persoon.Naam
                });*/

            //NOTEREN
            foreach (var value in joinedList1)
            {
                Console.WriteLine(value.PersoonNaam + ": " + value.BadgeOpschrift);
            }

            Console.WriteLine();

            //NOTEREN
            foreach (var value in joinedList2)
            {
                Console.WriteLine(value.PersoonNaam + ": " + value.BadgeOpschrift);
            }

            Console.WriteLine();

            /*//NOTEREN
            foreach (var badgeGroup in groupJoinedList)
            {
                Console.WriteLine("--{0}--",badgeGroup.Badgenaam);
                foreach (var per in badgeGroup.Personen)
                {
                    Console.WriteLine(per.Opschrift);
                }
            }*/

            //NOTEREN
            foreach (var item in groupJoin)
            {
                Console.WriteLine("--" + item.Opschrift + "--");
                foreach (var persoon in item.Personen)
                {
                    Console.WriteLine(persoon.Naam);
                }
            }

            Console.ReadLine();

        }
    }

    class Persoon
    {
        public int PersoonId { get; set; }
        public int TypeId { get; set; }
        public string Naam { get; set; }

        public Persoon(int persoonId, int typeId, string naam)
        {
            PersoonId = persoonId;
            TypeId = typeId;
            Naam = naam;
        }
    }

    class Badge
    {
        public int TypeId { get; set; }
        public string Opschrift { get; set; }

        public Badge(int typeId, string opschrift)
        {
            TypeId = typeId;
            Opschrift = opschrift;
        }
    }

    class Student
    {
        public int StudentId { get; set; }
        public int Leeftijd { get; set; }
        public string Naam { get; set; }

        public Student(int studentId, int leeftijd, string naam)
        {
            StudentId = studentId;
            Leeftijd = leeftijd;
            Naam = naam;
        }
    }
}
