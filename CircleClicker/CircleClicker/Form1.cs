using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleClicker
{
    public partial class frm : Form
    {
        public List<Object> obj = new List<Object>();

        public frm()
        {
            InitializeComponent();
            RandomizeBeatmap();


        }

        public void RandomizeBeatmap()
        {
            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
                obj.Add(new Object(rnd.NextDouble(), rnd.NextDouble(), i + 20));
        }

        public void Play()
        {
    
        }
    }

    public class Object
    {
        public double x { get; set; }
        public double y { get; set; }
        public int t { get; set; }

        public Object(double x, double y, int t)
        {
            this.x = x;
            this.y = y;
            this.t = t;
        }
    }
}
