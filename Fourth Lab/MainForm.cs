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
        List<Movie> movieList = new List<Movie>();
        public MainForm()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.movieList.Clear();
            var rnd = new Random();
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

            txtInfo.Text = "Фильмы\tСериалы\tTV передачи";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", filmsCount, serialsCount, tvshowsCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.movieList.Count == 0)
            {
                txtOut.Text = "Пусто :(";
                return;
            }

            var movie = this.movieList[0];
            this.movieList.RemoveAt(0);

            txtOut.Text = movie.GetInfo();

            ShowInfo();
        }
    }
}
