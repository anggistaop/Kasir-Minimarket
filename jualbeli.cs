using System;
using System.IO;
using System.Diagnostics;

namespace KasirMinimarket
{
    class jualbeli
    {
        static int[] jumlah = new int[1000];
        static int[] harga = new int[1000];
        static string[] nama = new string[1000];
        static int total = 0,nomer = 0,bayar;
        static void menu()
        {
            tool.clear();
            tool.gotoxy(2, 2); tool.print("+-----------------------------------------------------------------+");
            tool.gotoxy(2, 8); tool.print("+-----------------------------------------------------------------+");
            for(int i = 0; i < 5; i++)
            {
                tool.gotoxy(2, 3 + i);tool.print("|");
                tool.gotoxy(68, 3 + i); tool.print("|");
            }
            tool.gotoxy(17, 17); tool.print("No. Barang");
            tool.gotoxy(29, 15); tool.print("+--------------------------------------+");
            for (int i = 15 + 1; i < 15 + 4; i++)
            {
                tool.gotoxy(29, i); tool.print("|");
                tool.gotoxy(68, i); tool.print("|");
            }
            tool.gotoxy(29, 15+ 4); tool.print("+--------------------------------------+");
            tool.gotoxy(17, 31); tool.print("Total");
            tool.gotoxy(24, 28); tool.print("+-------------------------------------------+");
            for (int i = 28 + 1; i < 28 + 6; i++)
            {
                tool.gotoxy(24, i); tool.print("|");
                tool.gotoxy(68, i); tool.print("|");
            }
            tool.gotoxy(24, 28 + 6); tool.print("+-------------------------------------------+");
            tool.gotoxy(50, 22); tool.print("Jumlah");
            tool.gotoxy(58, 20); tool.print("+---------+");
            for (int i = 20 + 1; i < 20 + 4; i++)
            {
                tool.gotoxy(58, i); tool.print("|");
                tool.gotoxy(68, i); tool.print("|");
            }
            tool.gotoxy(58, 20 + 4); tool.print("+---------+");
        }
        public static void main()
        {
            string pilihan = "1";
            while(pilihan != "exit")
            {
                menu();
                if (nomer > 0)
                {
                    tool.gotoxy(4, 4); tool.print(nama[nomer - 1]);
                    tool.gotoxy(4, 5); tool.print("@" + harga[nomer - 1].ToString() + " X " + jumlah[nomer - 1].ToString());
                    tool.gotoxy(4, 6); tool.print("= Rp. " + (jumlah[nomer - 1] * harga[nomer - 1]).ToString());
                    tool.gotoxy(26, 31); tool.print("Rp. " + total.ToString());
                }
                tool.gotoxy(31,17);pilihan = Console.ReadLine();
                if (pilihan != "exit")
                {
                    tool.gotoxy(60, 22); jumlah[nomer] = int.Parse(Console.ReadLine());
                    int kode = int.Parse(pilihan);
                    harga[nomer] = manajemenbarang.cekharga(kode);
                    if (harga[nomer] == -1) continue;
                    nama[nomer] = manajemenbarang.ceknama(kode);
                    total += (jumlah[nomer] * harga[nomer]);
                    nomer++;
                }
            }
            pembayaran();
            kwitansi();
        }
        static void pembayaran()
        {
            tool.clear();
            tool.gotoxy(15, 3);tool.print("Total Harga");
            tool.kotak(4);tool.print("Rp. " + total.ToString());
            tool.gotoxy(15, 9); tool.print("Bayar");
            tool.kotak(10);tool.print("Rp. ");bayar = int.Parse(Console.ReadLine());
            tool.gotoxy(15, 19); tool.print("Kembali");
            tool.kotak(20);tool.print("Rp. " + (bayar-total).ToString());

        }
        static void kwitansi()
        {
            string path = @"D:\kwitansi.txt";
            File.Delete(path);
            using (var output = new StreamWriter(path))
            {
                output.WriteLine("Kwitansi TempeMarket");
                output.WriteLine("==================================================");
                for(int i = 0; i < nomer; i++)
                {
                    output.WriteLine(nama[i]);
                    output.WriteLine("@"+harga[i].ToString()+" X "+jumlah[i]);
                }
                output.WriteLine("==================================================");
                output.WriteLine("Total\t:Rp. " + total.ToString());
                output.WriteLine("Bayar\t:Rp. " + bayar.ToString());
                output.WriteLine("Kembali\t:Rp. " + (bayar - total).ToString());
            }
            Process.Start("notepad.exe", path);
        }
    }
}
