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

            //Для ввода русских имен из консоли
            //Console.InputEncoding = Encoding.Unicode;

            #region Ключевые переменные
            // Содержит имена игроков
            string[] playersNames;
            // Количество игроков - задается в начале игры
            int numberOfPlayers;
            // Имя победившего для вывода в конце игры
            string winner = "";
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
            // Статус всей игры, для выхода из цикла при выигрыше одного из участников
            bool endGameStatus = true;
            // Статус текущей игры, текущая игра заканчивается после достижения нуля
            bool newGameStatus = true;
            // Раундов с начала игры
            int raundsNumber = 0;
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
                Console.WriteLine("Количество игроков должно быть в диапазоне от 1 до 10\n" +
                    "Попробуйте еще раз");
                numberOfPlayers = int.Parse(Console.ReadLine());
            }

            //Ввод имен игроков
            //если игра с компьютерным противником
            if (numberOfPlayers == 1)
            {
                playersNames = new string[2];
                Console.WriteLine("Вы будете играть с компьютерным противником\n" +
                    "введите его имя:");
                playersNames[0] = Console.ReadLine();
                Console.WriteLine("Теперь введите свое имя:");
                playersNames[1] = Console.ReadLine();
            }
            else
            {
                // и если игра с живими игроками
                playersNames = new string[numberOfPlayers];
                int playerNumber = 1;
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    Console.WriteLine("Введите имя игрока " + playerNumber);
                    playerNumber++;
                    playersNames[i] = Console.ReadLine();
                }
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
            gameNumber = randomize.Next(minGameNumber, maxGameNumber * difficultyLevel);
            #endregion

            #region Цикл игры
            Console.Clear();

            while (endGameStatus)
            {
                while (newGameStatus)
                {
                    //Ходы игроков
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        //Вывод информации о ходе, игровом числе и статистика
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Прошло раундов - " + raundsNumber);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Сейчас загаданное число = " + gameNumber + "\n");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        //проверка на игрока-ИИ
                        if (numberOfPlayers == 1)
                        {
                            //ход игрока ИИ
                            if(maxUserTry + difficultyLevel >= gameNumber)
                            {
                                userTry = gameNumber;
                            } else
                            {
                                userTry = randomize.Next(minUserTry, maxUserTry + difficultyLevel);
                            }
                            Console.WriteLine("Ход игрока " + playersNames[i]);
                            Console.WriteLine("Он выбрал " + userTry);
                            gameNumber -= userTry;
                            Console.WriteLine("Теперь заданное число равно " + gameNumber + "\n");

                            //проверка условия выигрыша после хода ИИ
                            if (gameNumber <= 0)
                            {
                                winner = playersNames[i];
                                newGameStatus = false;
                                break;
                            }
                            i++;
                        }

                        //ход игрока - человека или кота
                        Console.WriteLine("Ход игрока " + playersNames[i]);
                        Console.WriteLine("Введите число, которое хотите вычесть");
                        Console.WriteLine("Оно должно быть в диапазоне от {0} до {1}", minUserTry, maxUserTry + difficultyLevel);

                        //Считываем ход игрока и проверяем его на вхождение в диапазон
                        userTry = int.Parse(Console.ReadLine());

                        while ((userTry < minUserTry) || (userTry > (maxUserTry + difficultyLevel)))
                        {
                            Console.WriteLine("Число не входит в указанный диапазон\n" +
                                "попробуйте еще раз");
                            userTry = int.Parse(Console.ReadLine());
                        }

                        Console.Clear();

                        //вычитаем введеное число из gameNumber и проверяем условие выигрыша

                        gameNumber -= userTry;

                        if (gameNumber <= 0)
                        {
                            winner = playersNames[i];
                            newGameStatus = false;
                            break;
                        }
                    }
                    raundsNumber++;
                }
                //Поздравляем победителя, желаете сыграть еще?
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("На {0} раунде победил игрок {1}\n", raundsNumber, winner);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Еще одна игра? (yes/no)");

                string answer = Console.ReadLine();

                if ((answer == "no") || (answer == "No") || (answer == "n"))
                {
                    endGameStatus = false;
                }
                else
                {
                    raundsNumber = 0;
                    gameNumber = randomize.Next(minGameNumber, maxGameNumber * difficultyLevel);
                    newGameStatus = true;
                    Console.Clear();
                }
            }
            #endregion
        }
    }
}
