using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace es_112
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Benvenuto, sorter di parole pronto");
            string swich;
            int n = 0, i;
            char input;
            string[] parole;

            Console.WriteLine("hai un file txt con gia presenti le parole ?(y/n)");
            input = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            Console.WriteLine("");
            if (!File.Exists("testo.txt")&&input=='y')
            {
                Console.WriteLine(" file mancante, procedo all'input manuale ");
                input = 'n';
            }
              Console.WriteLine("");
            if (input != 'y')
            {
                do
                {
                    Console.WriteLine("Quante parole vuoi inserire?");
                    swich = Console.ReadLine();
                }
                while (int.TryParse(swich, out n) == false || n < 0);

                parole = new string[n];

                for (i = 0; i < n; i++)
                {
                    Console.WriteLine("inserisci la parola numero " + (i + 1));
                    parole[i] = Console.ReadLine();
                }
                 sorter(parole);
            }

            else
            {
                using (StreamReader testo = new StreamReader("testo.txt"))
                {
                    while ((swich = testo.ReadLine()) != null)
                    {
                        Console.WriteLine();
                        n++;
                    }
                    testo.BaseStream.Position = 0;
                    parole = new string[n];
                    for (i = 0; i < n; i++)
                    {
                        parole[i] = testo.ReadLine();
                    }
                }
                Console.WriteLine("Schegli il tipo di sort: tramite indice o alfabetico(0,1)");
                if(Console.ReadLine()=="1")
                {
                    sorter(parole);
                }
                else
                {
                    parole=BubbleSort(IXseparator(parole));
                }
                
            }
            Console.WriteLine("vuoi che te le riscrivo in un documento?");        
            input = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            Console.WriteLine("");
            if (input != 'n')
            {
                using (StreamWriter output = new StreamWriter("ordinati.txt"))
                {
                    for (i = 0; i < parole.Length; i++)
                    {
                        output.WriteLine("     " + parole[i]);
                    }
                }
            }
            else
            {
                for (i = 0; i < n; i++)
                {
                    Console.WriteLine("     " + parole[i]);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Finito");
        }

        static void sorter(string[] numeri)
        {
            int i, j,max,c;           
            string bypass, bypass2;
            string temp;
            for (j = 0; j < (numeri.Length - 1); j++)
            {
                
                for (i = 0; i < (numeri.Length - 1); i++)
                {
                    bypass = numeri[i];
                    bypass2 = numeri[i + 1];
                    if(bypass.Length>bypass2.Length)
                    { max = bypass2.Length; }
                    else
                    { max = bypass.Length; }
                    for (c = 0; c < max - 1; c++)
                    {
                        if (bypass[c] > bypass2[c])
                        {
                            temp = numeri[i];
                            numeri[i] = numeri[i + 1];
                            numeri[i + 1] = temp;
                            c = max;
                        }
                        else if (bypass[c] < bypass2[c])                     
                        {
                            c = max;
                        }
                    }
                }
            }
            //return numeri;
        }
        static string[,] IXseparator(string[] word)
        {
            string[,] Sword = new string[word.Length, 2];
            for(int i=0;i<word.Length;i++)
            {       
                string[] btpass = word[i].Split("-->");
                for(int k=0;k<2;k++)
                {
                    Sword[i, k] = btpass[k];
                }
            }
            return Sword;

        }
        static string[] BubbleSort(string[,] words)
        {
            string[] temp = new string[2];
            for (int j = 0; j <= words.GetLength(0) - 2; j++)
            {
                for (int i = 0; i <= words.GetLength(0) - 2; i++)
                {
                    if (Convert.ToInt32(words[i,1]) > Convert.ToInt32(words[i + 1,1]))
                    {
                        for(int s=0;s<2;s++)
                        {
                            temp[s] = words[i+ 1,s];
                        }
                        for (int s = 0; s < 2; s++)
                        {
                            words[i + 1, s] = words[i, s];
                        }
                        for (int s = 0; s < 2; s++)
                        {
                            words[i, s] = temp[s];
                        }                     
                    }
                }
            }
             return words.OfType<string>().ToArray();
        }
       




    }


    }