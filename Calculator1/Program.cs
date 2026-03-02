internal class Program
{
    private static void Main(string[] args)
    {
        double angka1, angka2, hasil = 0;
        string operasi, konfirmasi;

        bool play = true;


        while (play == true)
        {
            Console.WriteLine("Selamat Datang di Kalkulator Sederhana");
            Console.Write("Masukan angak pertama: ");
            angka1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Masukan Operasi nya:");
            Console.WriteLine("+ = Tambah \n- = kurang\n/ = bagi\n* = kali");
            operasi = Console.ReadLine();

            Console.Write("Masukan angak Kedua: ");
            angka2 = double.Parse(Console.ReadLine());

            switch (operasi)
            {
                case "+":
                    hasil = angka1 + angka2;
                    break;
                case "-":
                    hasil = angka1 - angka2;
                    break;
                case "/":
                    if( angka2 != 0)
                    {
                    hasil = angka1 / angka2;
                    }
                    else
                    {
                        Console.WriteLine("Error angka tidak bisa dibagi dengan 0");
                        hasil = 0;
                    }
                    break;
                case "*":
                    hasil = angka1 * angka2;
                    break;
            }

            Console.WriteLine($"Hasilnya adalah {hasil} ");

            Console.WriteLine("Apakah anda ingin menghitung kembali?");
            Console.Write("Y = ya, N = tidak :");
            konfirmasi =Console.ReadLine().ToUpper();


            if (konfirmasi == "Y")
            {
                play = true;
            }
            else
            {
                play = false;
            }
        }



        Console.ReadKey();
    }

}