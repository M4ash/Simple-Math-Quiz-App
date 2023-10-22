using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1, addend2, minus1, minus2, multi1, multi2, timeLeft;
        decimal div1, div2;

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)

        {          
            if (timeLeft > 0)
            {
                
                timeLeft = timeLeft - 1;
                if(timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeLabel.Text = timeLeft + " seconds";

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time is up!";
                

                if (CheckTheAnswer())
                {
                    MessageBox.Show("Congratulations! You Got All the Answers Right");
                }
                else if(!CheckTheAnswer())
                {
                    MessageBox.Show("Sorry! Your answers were not Correct");
                }

                sum.Value = addend1 + addend2;
                difference.Value = minus1 - minus2;
                product.Value = multi1 * multi2;
                quotient.Value = Math.Round(div1/div2);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            addend1 = randomizer.Next(0, 51);
            addend2 = randomizer.Next(0, 51);

            minus1 = randomizer.Next(0, 101);
            minus2 = randomizer.Next(0, minus1);

            multi1 = randomizer.Next(0, 51);
            multi2 = randomizer.Next(0, 11);

            div2 = randomizer.Next(1, 13);
            
            int temp = randomizer.Next(2, 11);
            div1 = div2 * temp;

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minusLeftLabel.Text = minus1.ToString();
            minusRightLabel.Text = minus2.ToString();

            timesLeftLabel.Text = multi1.ToString();
            timesRightLabel.Text = multi2.ToString();

            dividedLeftLabel.Text = div1.ToString();
            dividedRightLabel.Text = div2.ToString();

            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;


            timeLeft = 45;
            timeLabel.Text = "45 seconds";
            timer1.Start();
            
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minus1 - minus2 == difference.Value) && (multi1 * multi2 == product.Value) && (Math.Round(div1/div2) == quotient.Value))
            {
            return true;
            }
            else { return false; }
        }
          
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
