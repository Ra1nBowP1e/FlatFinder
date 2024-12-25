using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(Image image)
        {
            InitializeComponent();
            if (image != null)
            {
                pictureBox1.Image = image;
            }
        }
    }
}
