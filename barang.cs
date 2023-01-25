using System;
using System.Collections.Generic;
using System.Text;

namespace KasirMinimarket
{
    class manajemenbarang
    {
        static int nomer = 0;
        struct Barang
        {
            public int kode,harga;
            public string nama;
        }
        static Barang[] barang = new Barang[1000];
        public static void tambah()
        {
            tool.clear();
            tool.gotoxy(15, 7);tool.print("Masukkan Barcode Barang");
            tool.kotak(8); int kode = int.Parse(Console.ReadLine());
            for(int i = 0; i < nomer; i++)
            {
                while(kode == barang[i].kode)
                {
                    tool.gotoxy(15, 14);tool.print("Barcode yang anda masukkan telah tersedia");
                    Console.ReadKey();
                    tool.clear();
                    tool.gotoxy(15, 7); tool.print("Masukkan kembali Barcode Barang");
                    tool.kotak(8); kode = int.Parse(Console.ReadLine());
                    i = 0;
                }
            }
            barang[nomer].kode = kode;
            tool.gotoxy(15, 17); tool.print("Masukkan Nama Barang");
            tool.kotak(18); barang[nomer].nama = Console.ReadLine();
            tool.gotoxy(15, 27); tool.print("Masukkan Harga Barang");
            tool.kotak(28); barang[nomer].harga = int.Parse(Console.ReadLine());
            tool.gotoxy(15,34); tool.print("Data telah berhasil dimasukkan");
            Console.ReadKey();
            nomer++;
        }
        public static void hapus()
        {
            tool.clear();
            tool.gotoxy(15, 7); tool.print("Masukkan Barcode Barang");
            tool.kotak(8); int kode = int.Parse(Console.ReadLine());
            for (int i = 0; i < nomer; i++)
            {
                if (kode == barang[i].kode)
                {
                    tool.gotoxy(15, 14); tool.print("Barang telah berhasil dihapus");
                    Console.ReadKey();
                    for (int j = i; j < nomer; j++)
                    {
                        barang[j].kode = barang[j + 1].kode;
                        barang[j].nama = barang[j + 1].nama;
                        barang[j].harga = barang[j + 1].harga;
                    }
                    break;
                }
                while(kode != barang[i].kode && i == nomer - 1)
                {
                    tool.gotoxy(15, 14); tool.print("Kode yang anda masukkan tidak ditemukan");
                    Console.ReadKey();
                    tool.clear();
                    tool.gotoxy(15, 7); tool.print("Masukkan kembali Barcode Barang");
                    tool.kotak(8); kode = int.Parse(Console.ReadLine());
                    i = 0;
                }
            }
            nomer--;
        }
        public static void daftar()
        {
            int x = nomer / 20;
            for(int i = 0; i <= x; i++)
            {
                tool.clear();
                tool.gotoxy(25, 3); tool.print("Daftar Barang");
                tool.gotoxy(2, 5); tool.print("No. Barcode");
                tool.gotoxy(25, 5); tool.print("Nama Barang");
                tool.gotoxy(45, 5); tool.print("Harga Barang");
                for (int j = i * 20; j < (i + 1) * 20; j++)
                {
                    tool.gotoxy(2, 6 + (j % 20));if(barang[j].kode != 0) tool.print(barang[j].kode.ToString());
                    tool.gotoxy(25, 6 + (j % 20)); tool.print(barang[j].nama);
                    tool.gotoxy(45, 6 + (j % 20)); if (barang[j].harga != 0) tool.print(barang[j].harga.ToString());
                }
                Console.ReadKey();
            }
        }
        public static void main()
        {
            char c = '1';
            while (c != 'X' && c != 'x')
            {
                tool.clear();
                tool.gotoxy(15, 3); tool.print("Manajemen Barang");
                tool.kotak(8); tool.print("Tambah Barang");
                tool.kotak(18); tool.print("Hapus Barang");
                tool.kotak(28); tool.print("Daftar Barang");
                c = Console.ReadKey().KeyChar;
                while (c != '1' && c != '2' && c != '3' && c != 'x' && c != 'X') { tool.gotoxy(99, 99); c = Console.ReadKey().KeyChar; }
                switch (c)
                {
                    case '1':
                        tambah();
                        break;
                    case '2':
                        hapus();
                        break;
                    case '3':
                        daftar();
                        break;
                    case 'x':
                    case 'X':
                        tool.main();
                        break;
                }
            }
        }
        public static int cekharga(int no)
        {
            for(int i = 0; i < nomer; i++)
            {
                if (no == barang[i].kode) return barang[i].harga;
            }
            return -1;
        }
        public static string ceknama(int no)
        {
            for (int i = 0; i < nomer; i++)
            {
                if (no == barang[i].kode) return barang[i].nama;
            }
            return null;
        }
    }
}
