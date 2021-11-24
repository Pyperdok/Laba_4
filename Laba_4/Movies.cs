using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    //Кино
    abstract class Movie
    {
        protected float _rating;
        abstract public string Print();
        public string Image { get; protected set; }
    }

    //Фильм
    class Film : Movie
    {
        public enum Genre
        {
            Documentary,
            Artistic,
            Adventure
        }
        private string _time;
        private Genre _genre;
        private string GenreName { get
            {
                switch (_genre)
                {
                    case Genre.Documentary:
                        return "Документальный";
                    case Genre.Artistic:
                        return "Художественный";
                    case Genre.Adventure:
                        return "Приключение";
                    default:
                        throw new ArgumentException("Не существующий жанр");
                }
            } }
        public Film(string time, Genre genre, float rating)
        {
            _time = time;
            _genre = genre;
            _rating = rating;

            switch(_genre)
            {
                case Genre.Documentary:
                    Image = "Documentary.png";
                    break;
                case Genre.Artistic:
                    Image = "Artistic.png";
                    break;
                case Genre.Adventure:
                    Image = "Adventure.png";
                    break;
            }
        }
        public override string Print()
        {
            return $"Фильм\nРейтинг: {_rating}\nВремя: {_time}\nЖанр {GenreName}";
        }
    }

    //Сериал
    class Serial : Movie
    {
        private int _series;
        private int _seasons;
        public Serial(int series, int seasons, float rating)
        {
            _series = series;
            _seasons = seasons;
            _rating = rating;
            Image = "Serial.png";
        }
        public override string Print()
        {
            return $"Сериал\nРейтинг: {_rating}\nСезонов: {_seasons}\nСерий: {_series}";
        }
    }

    //Передача
    class TVProgram : Movie
    {
        private string _time;
        private string _start;
        public TVProgram(string time, string start, float rating)
        {
            _time = time;
            _start = start;
            _rating = rating;
            Image = "Tvprogram.png";
        }
        public override string Print()
        {
            return $"ТВ Передача\nРейтинг: {_rating}\nДлительность: {_time}\nЭфирное время: {_start}";
        }
    }
}
