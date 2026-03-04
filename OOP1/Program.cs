using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "target.txt";
        List<Tugas> list = new List<Tugas>();

        if (File.Exists(path))
        {
            string isiFile = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(isiFile))
            {
                list = JsonSerializer.Deserialize<List<Tugas>>(isiFile);
                Console.WriteLine("Data lama berhasil dimuat!");
            }
        }
        int pilihan, hapus,deadLine;
        string judul, kondisi;
        bool play = true;
        

        while (play == true)
        {
            Console.Clear();
            Console.WriteLine("Selamat datand di To-Do List sederhana");
            Console.WriteLine(" 1.Tambah tugas \n 2.Lihat Daftar \n 3.Hapus Tugas \n 4.Konfirmasi tugas selesai \n 5.Keluar");
            Console.Write("Pilih yang ingin anda lakukan (pilih nomer) : ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    Console.Write("Masukan judul tugas yang anda ingin tambah : ");
                    judul = Console.ReadLine();

                    Console.Write("Masukan angka deadline (hari) yang anda ingin tambah : ");
                    deadLine = int.Parse(Console.ReadLine());

                    Tugas tambahTugas = new Tugas();
                    tambahTugas.judul = judul;
                    tambahTugas.deadline = deadLine;
                    tambahTugas.IsSelesai = false;

                    list.Add(tambahTugas);
                    Console.WriteLine("Data berhasil di masukan");
                    Console.ReadKey();
                    break;
                case 2:

                    if (list.Count == 0)
                    {
                        Console.WriteLine("Data masih kosong, masukan jadwal terlebih dahulu");
                        Console.ReadLine();
                    }
                    else
                    {
                    Console.WriteLine("Berikut adalah daftar yang ada : ");
                    Console.WriteLine(" V = Selesai \n X = belum selesai");
                    int nomer = 0;
                    foreach (Tugas lists in list)
                    {
                        nomer++;
                        string status = lists.IsSelesai ? "[V]" : "[X]";
                        Console.WriteLine($"{nomer}. {status} {lists.judul} (DeadLine : {lists.deadline}hari)");
                    }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Masukan nomer tugas yang anda ingin hapus : ");
                    int nomerHapus = int.Parse(Console.ReadLine()) - 1;
                    if (nomerHapus >= list.Count || nomerHapus < 0)
                    {
                        Console.WriteLine("Daftar tidak sampe sebanyak itu");
                        Console.ReadLine();
                    }
                    else
                    {
                        list.RemoveAt(nomerHapus);
                        Console.WriteLine("Tugas berhasil dihapus");
                        Console.ReadLine();

                    }
                    break;
                case 4:
                    Console.Write("Masukan nomer tugas yang sudah selesai : ");
                    int nomerSelesai = int.Parse(Console.ReadLine()) - 1;
                    if (nomerSelesai >= list.Count || nomerSelesai < 0)
                    {
                        Console.WriteLine("Daftar tidak sampe sebanyak itu");
                        Console.ReadLine();
                    }
                    else
                    {
                        list[nomerSelesai].IsSelesai = true ;
                        Console.WriteLine("Tugas berhasil dikonfirmasi");
                        Console.ReadLine();

                    }

                    break;
                case 5:
                    Console.WriteLine("Terimakasih, Selamat datang kembali!");
                    return;
            }
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonString);


        }
        Console.ReadKey();
    }
}

public class Tugas
{
    public string judul {  get; set; }
    public int deadline {  get; set; }
    public bool IsSelesai { get; set; }


}