using System.Security.Principal;
using System.Text;

namespace Stream.Ops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                writer.Write("Hello, World!");
                writer.Flush();

                stream.Position = 0;

                byte[] bytes = stream.ToArray();

                var byteString = string.Join(", ", bytes);

                Console.WriteLine(byteString);


                char[] chars = Encoding.UTF8.GetChars(bytes);

                var charString = string.Join(", ", chars);


                Console.WriteLine(charString);

            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var fileContents = ReadAllFileContents("Students.txt");
            //Console.WriteLine(fileContents);


            Console.WriteLine("Dosya içeriğini giriniz: ");

            string fileContents = Console.ReadLine();

            Console.WriteLine($"{fileContents.Length} karakter girdiniz...");

            CreateTextFile("inputs.txt", fileContents);

            Console.WriteLine("Dosya oluşturuldu, içeriğini görmek için enter'a basınız");

            var key = Console.ReadKey();

            if (key.Key != ConsoleKey.Enter)
            {
                return;
            }

            var fileContents2 = ReadAllFileContents("inputs.txt");

            Console.WriteLine(fileContents2);



        }

        static string ReadAllFileContents(string path)
        {
            using (var stream = new FileStream(path,FileMode.Open,FileAccess.Read) )
            {
                List<byte> bytes = new();

                stream.Position = 0;

                while (stream.Position < stream.Length)
                {
                    bytes.Add((byte)stream.ReadByte());
                }

                string fileContent = Encoding.UTF8.GetString(bytes.ToArray());

                return fileContent;

            }
        }

        static void CreateTextFile(string path, string fileContents)
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write) )
            {
                byte[] bytes = Encoding.UTF8.GetBytes(fileContents);
                stream.Write(bytes);
                stream.Flush();

            }
        }


    }
}
