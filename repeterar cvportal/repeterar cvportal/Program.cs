using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace repeterar_cvportal
{
    class Program
    {
        static string[] PersonUppgifter = new string[8];
        static int ArrayCounter = 0;
        static string namn, efternamn, yrkesroll, beskrivning;
        static int personNr;
        static int Mobil;
        static string Email;
        static string andringar;
        static string desaign= "===============";


        static void Main(string[] args)
        {
            Console.WriteLine(desaign);
            Console.WriteLine("Hej och välkommen till nabils cv portal");
            Console.WriteLine(desaign);
            Thread.Sleep(3000);
            Console.Clear();
            MenyVal();
        }
        public static void MenyVal()
        {
            Console.WriteLine(desaign);
            Console.WriteLine("Cv Portal");
            Console.WriteLine(desaign);

            bool choose = true;
            while (choose)
            {
                Console.WriteLine("1)Skriv in dina uppgifter");
                Console.WriteLine("2)Ändra dina uppgifter");
                Console.WriteLine("3)Sök efter profil");
                Console.WriteLine("4)Avsluta");

                Int32.TryParse(Console.ReadLine(), out int meny);
                if (meny == 0 || meny > 4)
                {
                    Console.WriteLine("Välj ett nummer mellan 1 och 4!");
                    Thread.Sleep(3000);
                }

                switch (meny)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Skriv in ditt förnamn");
                        namn = Console.ReadLine();

                        Console.WriteLine("\n Skriv in ditt efternamn");
                        efternamn = Console.ReadLine();
                        PersonUppgifter[ArrayCounter] = "Namn" +":" + namn + "" + "Efternamn" + ":" + efternamn;
                        ArrayCounter++;

                        Console.WriteLine("\n Skriv in din yrkesroll (tex Bygg, IT, Sälj osv...");
                        yrkesroll = Console.ReadLine();
                        PersonUppgifter[ArrayCounter] = "Roll" +":"+ yrkesroll;
                        ArrayCounter++;

                        p:
                        try
                        {
                           
                            Console.WriteLine("\n Skriv in ditt personnummer i detta format 2019-05-15");
                            personNr = Convert.ToInt32(Console.ReadLine());
                            PersonUppgifter[ArrayCounter] = "Personnummer" + ":" + personNr;
                            ArrayCounter++;


                        }
                        catch (Exception)
                        {
                           


                                Console.WriteLine("Du skrev fel du skall skriva 8siffor");
                                ArrayCounter--;

                                goto p;
                            
                        }

                        m:
                        try
                        {
                            Console.WriteLine("\n Skriv in ditt mobilnummer");
                            Mobil = Convert.ToInt32(Console.ReadLine());
                            PersonUppgifter[ArrayCounter] = "Mobil nummer +46" + ":" + Mobil;
                            ArrayCounter++;

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Du skrev fel");
                            ArrayCounter--;
                            goto m;
                        }

                        Console.WriteLine("\n Skriv in din Email adress");
                        Email = Console.ReadLine();
                        PersonUppgifter[ArrayCounter] = "Email" + ":" + Email;
                        ArrayCounter++;

                        Console.WriteLine("Berätta kort om dig själv mellan 100-200rader");
                        beskrivning = Console.ReadLine();
                        PersonUppgifter[ArrayCounter] = "Beskrivning" + ":" + beskrivning;
                        ArrayCounter++;

                    stad:
                        Console.WriteLine("\nKontor\n" +
                            "1) Stockholm\n" +
                            "2) Uppsala\n" +
                            "3) Nyköping\n" +
                            "4) Eskilstuna\n");

                        Int32.TryParse(Console.ReadLine(), out int kontor);

                        if (kontor == 0 || kontor > 4)
                        {
                            Console.WriteLine("Fel!, välj mellan alternvativ 1-4");
                            Thread.Sleep(3000);
                            goto stad;
                        }

                        switch (kontor)
                        {
                            case 1:
                                PersonUppgifter[ArrayCounter] = "Kontor i stockholm\n";
                                ArrayCounter++;
                                break;

                            case 2:
                                PersonUppgifter[ArrayCounter] = "Kontor i Uppsala\n";
                                ArrayCounter++;
                                break;
                            case 3:
                                PersonUppgifter[ArrayCounter] = "Kontor i Nyköping\n";
                                ArrayCounter++;
                                break;
                            case 4:
                                PersonUppgifter[ArrayCounter] = "Kontor i Eskilstuna\n";
                                ArrayCounter++;
                                break;

                        }
                        Console.WriteLine("Vi har nu tagit imot din information\n Tillbaka till menyn");
                        Thread.Sleep(3000);

                        break;

                    case 2:
                        Console.Clear();
                        foreach (object listarray in PersonUppgifter)
                        {
                            Console.WriteLine(listarray);
                        }
                        break;

                    case 3:

                        Console.WriteLine("Välj vilka uppgifter du vill ändra på nedan\n"+
                            "1: Namn\n"+
                            "2: Roll\n"+
                            "3: Personnummer\n"+
                            "4: Mobil\n"+
                            "5: Mail\n"+
                            "6: Ändra din beskrivning\n"+
                            "7: Kontors val\n");


                        Int32.TryParse(Console.ReadLine(), out int lillaMenyn);

                        // dubbel kolla och ändra i array index enkel sätt

                        if (lillaMenyn == 1 || lillaMenyn <= 7)
                        {
                            lillaMenyn = lillaMenyn - 1;
                            Console.WriteLine("ändra ditt val på nytt");

                            andringar = Console.ReadLine();

                            PersonUppgifter[lillaMenyn] = andringar;

                            Console.WriteLine("nu har uppgifterna sparats på nytt");
                            Thread.Sleep(6000);


                        }
                        else
                        {
                            Console.WriteLine("Du har matat in något som inte stämmer\n");
                            goto case 3;
                        }
                        break;

                }

            }
        }
    }
}
