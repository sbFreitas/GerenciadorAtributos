using System;
using System.IO;

namespace GerenciadorAtributos
{
    public class Program
    {
        private static string file;

        static void Main(string[] args)
        {
            bool haveFile;

            {
                Console.Write("Qual arquivo você gostaria de modificar? ");
                file = Console.ReadLine();
                haveFile = File.Exists(file);
            }
            while (!haveFile);

            while(true)
            {
                Console.WriteLine("\nO que você gostaria de fazer com o arquivo?");
                Console.WriteLine("1- Mudar data de criação.");
                Console.WriteLine("2- Mudar data do último acesso.");
                Console.WriteLine("3- Mudar data da última modificação.");
                Console.WriteLine("4- Sair.");
                Console.Write("Resposta: ");

                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        SetCreatedDate(file);
                        break;

                    case 2:
                        SetLastAccessedDate(file);
                        break;

                    case 3:
                        SetLastModifiedDate(file);
                        break;

                    case 4:
                        Console.WriteLine("Alterações salvas com sucesso!");
                        System.Threading.Thread.Sleep(3000);
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void SetLastModifiedDate(string file)
        {
            Console.WriteLine("\nAlterando a data da última modificação do arquivo.");
            DateTime newDate = GetNewDate();
            File.SetLastWriteTime(file, newDate);
            Console.WriteLine("Data da última modificação alterada para: " + newDate + " com sucesso! \n");
        }

        private static void SetLastAccessedDate(string file)
        {
            Console.WriteLine("\nAlterando a data do último acesso do arquivo.");
            DateTime newDate = GetNewDate();
            File.SetLastAccessTime(file, newDate);
            Console.WriteLine("Data do último acesso alterada para: " + newDate + " com sucesso! \n");
        }

        private static void SetCreatedDate(string file)
        {
            Console.WriteLine("\nAlterando a data da criação do arquivo.");
            DateTime newDate = GetNewDate();
            File.SetCreationTime(file, newDate);
            Console.WriteLine("Data de criação alterada para: " + newDate + " com sucesso! \n");
        }

        private static DateTime GetNewDate()
        {
            //Year
            int year;
            {
                Console.Write("Informe o ano: ");
                year = int.Parse(Console.ReadLine());
            }

            //Month
            int month;
            {
                Console.Write("Informe o mês: ");
                month = int.Parse(Console.ReadLine());
            }

            //Day
            int day;
            {
                Console.Write("Informe o dia: ");
                day = int.Parse(Console.ReadLine());
            }

            //Hour
            int hour;
            {
                Console.Write("Informe a(s) hora(s): ");
                hour = int.Parse(Console.ReadLine());
            }

            //Minute
            int min;
            {
                Console.Write("Informe o(s) minuto(s): ");
                min = int.Parse(Console.ReadLine());
            }

            try
            {
                Random sec = new Random();
                return new DateTime(year, month, day, hour, min, sec.Next(0, 59));
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(1);
            }

            return new DateTime();
        }
    }
}
