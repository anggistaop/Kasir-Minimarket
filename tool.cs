using System;
using System.Collections.Generic;

namespace KasirMinimarket
{
    class tool
    {
        public static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public static void print(string s)
        {
            Console.Write(s);
        }
        public static void layout()
        {
            Console.Clear();
            gotoxy(0, 0); print("+---------------------------------------------------------------------+");
            for (int i = 1; i < 35; i++)
            {
                gotoxy(0, i); print("|");
                gotoxy(70, i); print("|");
            }
            gotoxy(0, 35); print("+---------------------------------------------------------------------+");
        }
        public static void clear()
        {
            Console.Clear();
            layout();
        }
        public static void kotak(int y)
        {
            gotoxy(15, y); print("+--------------------------------------+");
            for (int i = y + 1; i < y + 4; i++)
            {
                gotoxy(15, i); print("|");
                gotoxy(54, i); print("|");
            }
            gotoxy(15, y + 4); print("+--------------------------------------+");
            gotoxy(17, y + 2);
        }
        public static int main()
        {
            char c = '1';
            while (c != 'X' && c != 'x')
            {
                clear();
                gotoxy(15, 3); print("Kasir TempeMarket");
                kotak(8); print("Manajemen Barang");
                kotak(20); print("Jual Beli");
                c = Console.ReadKey().KeyChar;
                while (c != '1' && c != '2' && c != 'x' && c != 'X') { tool.gotoxy(99, 99); c = Console.ReadKey().KeyChar; }
                switch (c)
                {
                    case '1':
                        manajemenbarang.main();
                        break;
                    case '2':
                        jualbeli.main();
                        break;
                    case 'x':
                    case 'X':
                        return 0;
                        
                }
            }
            return 0;
        }
    }
}
