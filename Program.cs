//****************************************
//* Практическая_работа № 8              *
//* Выполнил: Истомин Е. А., группа 2ИСПд*
//****************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Практическая_работа_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.CursorVisible = false;
                int totalCoins = 0;
                int maxCoinsOnLevel = 50;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В SUPER MARIO COIN COLLECTOR ===");
                Console.ResetColor();
                Console.WriteLine("Нажимайте [ПРОБЕЛ], чтобы бежать и собирать монеты!");
                Console.WriteLine("Каждая 5-я монета принесет +3 бонуса вместо +1.\n");
                Console.WriteLine("Нажмите любую клавишу для старта...");
                Console.ReadKey(true);

                int i = 1;
                do
                {
                    Console.Clear();

                    //Отрисовка интерфейса
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Монет в банке: {totalCoins}   |   Текущая монета на уровне: {i}/{maxCoinsOnLevel}");
                    Console.ResetColor();
                    Console.WriteLine("--------------------------------------------------");

                    //подсчет
                    int isBonus = 1 - ((i % 5 + 4) / 5);
                    int pointsEarned = 1 + isBonus * 2;

                    //Анимация персонажа и монеты
                    string[] coinText = { "\n      ( 0 )    <- Обычная монета (+1)", "      ( O )  <- Мега-монета! (+3)" };
                    ConsoleColor[] coinColors = { ConsoleColor.DarkYellow, ConsoleColor.Magenta };

                    Console.ForegroundColor = coinColors[isBonus];
                    Console.WriteLine(coinText[isBonus]);


                    // отрисовка
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     [O_O]   <- Марио бежит!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("============= (ЗЕМЛЯ) =============\n");
                    Console.ResetColor();

                    Console.WriteLine("--> Нажмите [ПРОБЕЛ], чтобы схватить её!");

                    // Ожидание нажатия пробела 
                    while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                    // Начисление очков    
                    totalCoins += pointsEarned;   

                    i++;
                }
                while (i <= maxCoinsOnLevel);

                // Финал игры
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== УРОВЕНЬ ПРОЙДЕН! ===");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Поздравляем! Марио добежал до финиша и собрал: {totalCoins} монет!");
                Console.ResetColor();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Перехват любых критических ошибок во время работы всей программы
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Произошла ошибка в работе игрового движка Марио!");
                Console.WriteLine($"Текст ошибки: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}


