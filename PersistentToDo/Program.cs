using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "target.txt";
        List<string> list = new List<string>();

        if (File.Exists(path))
        {
            string[] isiFile = File.ReadAllLines(path);
            list = new List<string>(isiFile);
            Console.WriteLine("Data berhasil di tambahkan");
        }

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
                    File.WriteAllLines(path, list);
                    break;
                case 2:
                    Console.WriteLine("Berikut adalah daftar yang ada : ");
                    int nomer = 0;
                    foreach (string lists in list)
                    {
                        nomer++;
                        Console.WriteLine(nomer + " " + lists);
                    }
                    break;
                case 3:
                    Console.Write("Masukan nomer tugas yang anda ingin hapus : ");
                    int nomerHapus = int.Parse(Console.ReadLine()) - 1;
                    if (nomerHapus >= list.Count || nomerHapus < 0)
                    {
                        Console.WriteLine("Daftar tidak sampe sebanyak itu");
                    }
                        
                    {
                        list.RemoveAt(nomerHapus);
                        Console.WriteLine("Tugas berhasil dihapus");
                    }
                        File.WriteAllLines(path, list);
                    break;
                case 4:
                    Console.WriteLine("Terimakasih, Selamat datang kembali!");
                    return;
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
