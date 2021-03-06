using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fourth_Lab
{
    public partial class MainForm : Form
    {
        public Random rnd = new Random();
        List<Movie> movieList = new List<Movie>();
        public MainForm()
        { 
            InitializeComponent();
            ShowInfo();
        }

        //Перезаполнение списка
        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.movieList.Clear();
            for(var i = 0; i < 10; i++)
            {
                switch(rnd.Next() % 3)
                {
                    case 0:
                        this.movieList.Add(Film.Generate());
                        break;
                    case 1:
                        this.movieList.Add(Serial.Generate());
                        break;
                    case 2:
                        this.movieList.Add(TVShow.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        //Отображение текущей информации о списке
        private void ShowInfo()
        {
            listQueue.Items.Clear();
            int filmsCount = 0;
            int serialsCount = 0;
            int tvshowsCount = 0;

            foreach (var movie in this.movieList)
            {
                if (movie is Film)
                {
                    listQueue.Items.Add("Фильм");
                    filmsCount++;
                }
                else if (movie is Serial)
                {
                    listQueue.Items.Add("Сериал");
                    serialsCount++;
                }
                else if (movie is TVShow)
                {
                    listQueue.Items.Add("TV передача");
                    tvshowsCount++;
                }
            }

            txtInfo.Text = "Фильмы\t\tСериалы\t\tTV передачи";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", filmsCount, serialsCount, tvshowsCount);
        }

        //Получение первого объекта в списке
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.movieList.Count == 0)
            {
                txtOut.Text = "Пусто :(";
                icon.Image = Properties.Resources.none;
                return;
            }

            var movie = this.movieList[0];
            this.movieList.RemoveAt(0);

            txtOut.Text = movie.GetInfo();
            icon.Image = movie.GetIcon();

            ShowInfo();
        }
    }
}
