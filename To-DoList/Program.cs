using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = new List<string>();

        list.Add("Makan");
        list.Add("Minum");
        list.Add("Tidur");
        list.Add("Mandi");

        Console.WriteLine(list.Count);

        int pilihan, hapus;
        string tambah, kondisi;
        bool play = true; 

        while (play == true)
        {
            Console.WriteLine("Selamat datand di To-Do List sederhana");
            Console.WriteLine("1.Tambah tugas \n 2.Lihat Daftar \n 3.Hapus Tugas \n 4.Keluar");
            Console.Write("Pilih yang ingin anda lakukan (pilih nomer) : ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    Console.Write("Masukan tugas yang anda ingin tambah : ");
                    tambah = Console.ReadLine();
                    list.Add(tambah);
                    break;
                case 2:
                    Console.WriteLine("Berikut adalah daftar yang ada : ");
                    int nomer = 0;
                    foreach (string lists in list)
                    {
                        nomer ++;
                        Console.WriteLine(nomer +" "+lists);
                    }
                    break;
                case 3:
                    Console.Write("Masukan nomer tugas yang anda ingin hapus : ");
                    int nomerHapus = int.Parse(Console.ReadLine()) -1;
                    if(nomerHapus > list.Count)
                    {
                        Console.WriteLine("Daftar tidak sampe sebanyak itu");
                    }
                    else
                    {
                    list.RemoveAt(nomerHapus);
                    }
                    break;
                case 4:
                    Console.WriteLine("Terimakasih, Selamat datang kembali!");
                    break;
            }

            Console.WriteLine("Apakah anda ingin melakukannya lagi? (Y/N) : ");
            kondisi = Console.ReadLine().ToUpper();

            if (kondisi == "Y")
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
