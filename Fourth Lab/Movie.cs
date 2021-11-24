using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fourth_Lab
{
    public enum FilmType
    {
        Художественный,
        Документальный
    }

    public abstract class Movie
    {
        public static Random rnd = new Random();
        public int Rating = 0;

        public virtual string GetInfo()
        {
            var str = String.Format("\nРейтинг: {0}", this.Rating);
            return str;
        }
        public abstract Bitmap GetIcon();
    }

    public class Film : Movie
    {
        public int Length = 0;
        public int CountOfAwards = 0;
        public FilmType Type = FilmType.Документальный;
        public static Film Generate()
        {
            return new Film
            {
                Rating = rnd.Next() % 11,
                Length = 60 + rnd.Next() % 90,
                CountOfAwards = rnd.Next() % 11,
                Type = rnd.Next() % 1 == 0 ? FilmType.Документальный : FilmType.Художественный
            };
        }
        public override string GetInfo()
        {
            var str = "Фильм";
            str += base.GetInfo();
            str += String.Format("\nДлина: {0} мин.", this.Length);
            str += String.Format("\nПолучено наград: {0}", this.CountOfAwards);
            str += String.Format("\nТип: {0}", this.Type);
            return str;
        }
        public override Bitmap GetIcon()
        {
            return Properties.Resources.film;
        }
    }

    public class Serial : Movie 
    {
        public int Episodes = 0;
        public int Seasons = 0;
        public static Serial Generate()
        {
            return new Serial
            {
                Rating = rnd.Next() % 11,
                Episodes = 20 + rnd.Next() % 6,
                Seasons = 3 + rnd.Next() % 5
            };
        }
        public override string GetInfo()
        {
            var str = "Сериал";
            str += base.GetInfo();
            str += String.Format("\nКол-во серий: {0}", this.Episodes);
            str += String.Format("\nКол-во сезонов: {0}", this.Seasons);
            return str;
        }
        public override Bitmap GetIcon()
        {
            return Properties.Resources.serial;
        }
    }

    public class TVShow : Movie
    {
        public int Duration = 0;
        public int Airtime = 0;
        public static TVShow Generate()
        {
            return new TVShow
            {
                Rating = rnd.Next() % 11,
                Duration = 5 + rnd.Next() % 20,
                Airtime = 30 + rnd.Next() % 31
            };
        }
        public override string GetInfo()
        {
            var str = "TV передача";
            str += base.GetInfo();
            str += String.Format("\nДлительность: {0}", this.Duration);
            str += String.Format("\nЭкранное время: {0} мин.", this.Airtime);
            return str;
        }
        public override Bitmap GetIcon()
        {
            return Properties.Resources.tvshow;
        }
    }
}
