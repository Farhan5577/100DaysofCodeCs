using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        var manager = new TodoManager();
        bool play = true;


        while (play == true)
        {
            Console.WriteLine("Selamat datand di To-Do List sederhana");
            Console.WriteLine("1.Tambah tugas \n 2.Lihat Daftar \n 3.Hapus Tugas \n 4.Keluar");
            Console.Write("Pilih yang ingin anda lakukan (pilih nomer) : ");
            var pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    Console.Write("Masukan tugas yang anda ingin tambah : ");
                    string j = Console.ReadLine();
                    Console.WriteLine("Masukan angka deadline (hari) : ");
                    int.TryParse(Console.ReadLine(), out int i);
                    manager.Tambah(j,i);
                    break;
                case 2:
                    Console.WriteLine("Berikut adalah daftar yang ada : ");
                    manager.Tampilkan();

                    break;
                case 3:
                    Console.Write("Masukan nomer tugas yang anda ingin hapus : ");
                    if (int.TryParse(Console.ReadLine(), out int nomerHapus))
                    {
                        manager.Hapus(nomerHapus - 1);
                    }

                    break;
                case 4:
                    Console.WriteLine("Terimakasih, Selamat datang kembali!");
                    return;
            }

            Console.WriteLine("Apakah anda ingin melakukannya lagi? (Y/N) : ");
            var kondisi = Console.ReadLine().ToUpper();

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


public class Tugas
{
    public string judul;
    public int deadLine;
    public bool IsSelesai;

    public Tugas(string judul, int deadLine)
    {
        this.judul = judul;
        this.deadLine = deadLine;
        this.IsSelesai = false;
    }
}

public class TodoManager
{
    private List<Tugas> _listTugas = new List<Tugas>();
    private string _path = "target.json";

    public TodoManager()
    {
        Muat();
    }

    public void Tambah(string judul, int deadLine)
    {
        _listTugas.Add(new Tugas(judul, deadLine));
        Console.WriteLine("Data berhasil ditambahkan!");
        Simpan();
    }

    private void Muat()
    {
        if (File.Exists(_path))
        {
            string json = File.ReadAllText(_path);
            _listTugas = JsonSerializer.Deserialize<List<Tugas>>(json) ?? new List<Tugas>();
        }
    }
        public void Hapus(int index)
        {
            if (index >= 0 && index < _listTugas.Count)
            {
                _listTugas.RemoveAt(index);
                Console.WriteLine("Tugas berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("Tugas yang ingin dihapus tidak ada");
            }
        }

        public void Tampilkan()
        {
            if (_listTugas.Count == 0)
            {
                Console.WriteLine("Daftar masih kosong, isi dulu!");
                return;
            }

            for (int i = 0; i < _listTugas.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_listTugas[i].judul} {_listTugas[i].deadLine} hari");
            }
        }

        private void Simpan()
        {
        string json = JsonSerializer.Serialize(_listTugas, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_path, json);
            Console.WriteLine("Data berhasil disimpan");
        }
    }
