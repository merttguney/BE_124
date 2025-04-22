namespace App.WebApi
{
    public abstract class Hayvan
    {
        public string Renk { get; set; }
        public int AyakSayisi { get; set; }

        public void OzelIsim(string isim)
        {
            //Console.WriteLine("Bu hayvanın ismi: " + isim);
            Console.WriteLine($"Bu hayvanın ismi: {isim}"); // string interpolation
        }

        public abstract void SesCikar(); // contract
        public abstract void HareketEt(); // contract

    }

    public class Kedi : Hayvan
    {
        public override void SesCikar() // polymorphism
        {
            Console.WriteLine("Miyav");
        }
        public override void HareketEt()
        {
            Console.WriteLine("Kedi yürüyor");
        }
    }
    public class Kus : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine("Cik");
        }
        public override void HareketEt()
        {
            Console.WriteLine("Kuş uçuyor");
        }
    }


    public interface IUcan
    {
        void Uc(); // contract
    }
    public interface ISurungen
    {
        void Surun(); // contract
    }
    public interface ICanli
    {
        void NeredeYasar(); // contract
    }


    public class Yilan : Hayvan, ISurungen, ICanli
    {
        public override void SesCikar()
        {
            Console.WriteLine("Tıss");
        }
        public override void HareketEt()
        {
            Console.WriteLine("yılan sürünüyor");
        }
        public void Surun()
        {
            Console.WriteLine("yihuuuu");
        }
        public void NeredeYasar()
        {
            Console.WriteLine("Dünya");
        }
    }

    public class At : Hayvan, ICanli
    {
        public override void SesCikar()
        {
            Console.WriteLine("asdasd");
        }
        public override void HareketEt()
        {
            Console.WriteLine("At koiuyor");
        }

        public void NeredeYasar()
        {
            Console.WriteLine("Ahır");
        }
    }
}
