using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Laba_4
{
    //Для раздачи кино(рейтинг)
    //Фильм(хронометраж, количество наград, тип (художественный, документальный и т.п.))
    //Сериал(общее количество серий, количество сезонов)
    //Телепередача(продолжительность, эфирное время)
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private List<Movie> movies = new List<Movie>();
        private float RandomRating { get { return (float)random.Next(0, 100) / 10; } }
        private int filmCount;
        private int serialCount;
        int tvProgramCount;

        delegate Movie MovieDelegate(); //Делегает возращающий фильм или сериал или передачу

        //Заполняет массив кино фильмами, сериалами, передачами
        private void Fill(int movieCount, MovieDelegate movie)
        {
            for (int i = 0; i < movieCount; i++)
            {
                movies.Add(movie());
            }
        }

        //Перезаполняет машину, загружая кино
        private void BT_InitMovies(object sender, RoutedEventArgs e)
        {
            MovieLabel.Content = string.Empty;
            BitmapImage none = new BitmapImage(new Uri("/Images/None.png", UriKind.Relative));
            IMG_Icon.Source = none;

            movies.Clear();
            //Заполнение кино-автомата(Фильмы)
            filmCount = random.Next(3, 12);
            L_FilmCount.Content = $"Фильмов: {filmCount}";
            //Заполнение кино-автомата(Сериалы)
            serialCount = random.Next(2, 20);
            L_SerialCount.Content = $"Сериалов: {serialCount}";
            //Заполнение кино-автомата(ТВ Передача)
            tvProgramCount = random.Next(1, 15);
            L_TvCount.Content = $"Передач: {tvProgramCount}";

            Fill(filmCount, () =>
            {
                string time = $"{random.Next(0, 60):D2}:{random.Next(0, 60):D2}";
                return new Film(time, (Film.Genre)random.Next(0, 3), RandomRating);
            });

            Fill(serialCount, () =>
            {
                int series = random.Next(2, 20);
                int seasons = random.Next(1, 12);
                return new Serial(series, seasons, RandomRating);
            });

            Fill(tvProgramCount, () =>
            {
                string time = $"{random.Next(0, 24):D2}:{random.Next(0, 60):D2}";
                string start = $"{random.Next(0, 24):D2}:{random.Next(0, 60):D2}";
                return new TVProgram(time, start, RandomRating);
            });
        }

        public MainWindow()
        {
            InitializeComponent();
            BT_InitMovies(null, null);
        }

        //Достает одно кино из массива
        private void BT_Take(object sender, RoutedEventArgs e)
        {
            if(movies.Count == 0)
            {
                MessageBox.Show("Кино закончились");
                return;
            }

            int index = random.Next(0, movies.Count - 1);
            if (movies[index] is Film)
            {
                filmCount--;               
                L_FilmCount.Content = $"Фильмов: {filmCount}";
            }
            else if(movies[index] is Serial)
            {
                serialCount--;
                L_SerialCount.Content = $"Сериалов: {serialCount}";
            }
            else if(movies[index] is TVProgram)
            {
                tvProgramCount--;
                L_TvCount.Content = $"Передач: {tvProgramCount}";
            }

            BitmapImage image = new BitmapImage(new Uri("/Images/"+movies[index].Image, UriKind.Relative));
            IMG_Icon.Source = image;
            string item = movies[index].Print();
            MovieLabel.Content = item;
            movies.RemoveAt(index);
        }

        //Отображает задание
        public void BT_Task(object sender, RoutedEventArgs e)
        {
            string task = "Должен быть 1 базовый класс, и 3 класса наследника. У базового класса должно быть, как минимум одно свойство передающиеся по наследству остальным, у каждого из классов наследников должно быть как минимум два уникальных свойства.\n";
            string variant = 
                "Для раздачи кино(рейтинг)\n" +
                "Фильм(хронометраж, количество наград, тип(художественный, документальный и т.п.))\n" +
                "Сериал(общее количество серий, количество сезонов)\n" +
                "Телепередача(продолжительность, эфирное время)";
            MessageBox.Show(task + variant, "Задание. Вариант 10");
        }
    }
}
