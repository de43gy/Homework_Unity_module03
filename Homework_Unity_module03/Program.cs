using System;

namespace Homework_Unity_module03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)Подумать над возможностью реализации разных уровней сложности.
            // 

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером
            #endregion

            #region Ключевые переменные
            // Содержит имена игроков
            string[] playerName;
            // Количество игроков - задается в начале игры
            int numberOfPlayers;
            // Уровень сложности - меняется в начале игры
            int difficultyLevel;
            // Генерация псевдослучайного значения
            Random randomize = new Random();
            // Случайное число - зависит от уровня сложности
            int gameNumber;
            // Минимальное значение случайного числа, не меняется
            int minGameNumber = 12;
            // Максимальное значение случайного числа по умолчанию, изменяется при выборе уровня сложности
            int maxGameNumber = 120;
            // Вычитается из gameNumber, значения зависят от уровня сложности
            int userTry;
            // Минимальное значение userTry, не меняется
            int minUserTry = 1;
            // Максимальное значение userTry, изменяется при выборе уровня сложности
            int maxUserTry = 3;
            // Статус игры, для выхода из цикла при выигрыше одного из участников
            bool gameStatus = true;
            // Ходов с начала игры
            int turnsNumber = 0;
            #endregion

            #region Условия игры
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Игра \"ОБНУЛИ МЕНЯ ПЕРВЫМ\"\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Правила игры:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Игра загадывает число и выводит его на экран.\n" +
                "Вам нужно по очереди вводить числа, которые будут вычитаться из него.\n" +
                "Выигрывает тот, кто первый дойдет до 0\n");
            #endregion

            #region Количество игроков
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Количество игроков:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Введите число от 1 до 10\n" +
                "Если выбран один игрок, игра будет проходить с компьютерным противником");

            //Ввод и проверка правильности ввода количества игроков
            numberOfPlayers = int.Parse(Console.ReadLine());
            while ((numberOfPlayers < 1) || (numberOfPlayers > 10))
            {
                Console.WriteLine("Количество игроков должно быть больше 0 и меньше 11\n" +
                    "Попробуйте еще раз");
                numberOfPlayers = int.Parse(Console.ReadLine());
            }

            //Ввод имен игроков
            playerName = new string[numberOfPlayers];
            int playerNumber = 1;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Введите имя игрока №" + playerNumber);
                playerNumber++;
                playerName[i] = Console.ReadLine();
            }
            #endregion

            #region Уровень сложности
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сложность игры:");
            Console.ForegroundColor = ConsoleColor.Gray;
            string difficultyLevelPattern = "{0} - Случайное число от {1} до {2}, вычитать можно числа от {3} до {4}";
            Console.WriteLine(difficultyLevelPattern, 1, minGameNumber, maxGameNumber, minUserTry, maxUserTry + 1);
            Console.WriteLine(difficultyLevelPattern, 2, minGameNumber, maxGameNumber * 2, minUserTry, maxUserTry + 2);
            Console.WriteLine(difficultyLevelPattern, 3, minGameNumber, maxGameNumber * 3, minUserTry, maxUserTry + 3);

            //Ввод уровня сложности и проверка
            difficultyLevel = int.Parse(Console.ReadLine());
            while ((difficultyLevel < 1) || (difficultyLevel > 3))
            {
                Console.WriteLine("Вы ввели неправильный уровень сложности\n" +
                    "Попробуйте еще раз");
                difficultyLevel = int.Parse(Console.ReadLine());
            }

            //создание случайного числа
            gameNumber = randomize.Next(minGameNumber, maxGameNumber);
            #endregion

            #region Ход игры
            Console.Clear();

            while (gameStatus)
            {
                //Вывод информации о ходе, игровом числе и статистика
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ходов с начала игры - " + turnsNumber);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Сейчас загаданное число = " + gameNumber);
            }
            #endregion
            Console.ReadKey();
        }
    }
}
