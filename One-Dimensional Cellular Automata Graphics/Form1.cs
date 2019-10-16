using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One_Dimensional_Cellular_Automata_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //int[] ruleSet = { 0, 1, 0, 1, 1, 0, 1, 0 }; //Rule 90
        //int[] ruleSet = { 0, 0, 1, 1, 1, 1, 1, 0 }; //Rule 62
        //int[] ruleSet = { 1, 0, 0, 1, 0, 1, 1, 0 }; //Rule 150
        //int[] ruleSet = { 1, 1, 0, 1, 1, 1, 1, 0 }; //Rule 222
        //int[] ruleSet = { 1, 1, 1, 1, 1, 0, 1, 0 }; //Rule 250
        //int[] ruleSet = { 1, 0, 0, 1, 0, 0, 0, 1 }; //Rule 145
        int[] ruleSet = { 0, 1, 1, 0, 0, 0, 1, 1 }; //Rule 99


        int generations = 1000;
        int size = 500;

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(b);

            Array.Reverse(ruleSet);

            int[] cells = new int[size];

            cells[size / 2] = 1;

            int inc = b.Width / size;
            int yCoord = 0;

            yCoord += inc;
            int[] pastArray;
            for (int gens = 0; gens < generations; gens++)
            {
                pastArray = cells;
                cells = NewArray(pastArray);
                for (int i = 0; i < cells.Length; i++)
                {
                    if(cells[i] == 1)
                        g.FillRectangle(Brushes.White, new Rectangle(i * inc, yCoord, inc, inc));
                    else
                        g.FillRectangle(Brushes.Black, new Rectangle(i * inc, yCoord, inc, inc));
                }

                yCoord += inc;
            }

            pictureBox1.Image = b;
        }

        int[] NewArray(int[] cells)
        {
            int[] newCells = new int[size];

            for(int i = 0; i < newCells.Length; i++)
            {
                int sum = 0;
                int degree = 2;
                for(int x = i - 1; x <= i + 1; x++)
                {
                    if (x >= 0 && x < size)
                    {
                        if(cells[x] == 1)
                            sum += (int)Math.Pow(2, degree);
                    }

                    degree--;
                }

                newCells[i] = ruleSet[sum];
            }

            return newCells;
        }
    }
}
