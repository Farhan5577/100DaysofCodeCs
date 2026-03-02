
internal class Program
{
    private static void Main(string[] args)
    {
        string binner;
        int totalDesimal = 0;


        Console.WriteLine("Selamat datang di program binner to desimal");
        Console.Write("Masukan angka biner MAX 8 :");
        binner = Console.ReadLine();

        if (binner.Length > 8)
        {
            Console.WriteLine("Maaf binner yang anda masukan terlalu banyak");
            return;
        }
        int pangkat = binner.Length - 1;

        foreach (char binners in binner)
        {
            if (binners != '0' && binners != '1')
            {
                Console.WriteLine("Masukan hanya angka 0 dan 1");
                return;
            }
            if (binners == '1')
            {
                totalDesimal += (int)Math.Pow(2, pangkat);
            }
                pangkat--;

        }
            Console.WriteLine($"Hasil desimalnya adalah : {totalDesimal}");
    }
}