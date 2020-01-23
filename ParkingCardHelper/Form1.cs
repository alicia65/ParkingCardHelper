using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCardHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool creditValid = Double.TryParse(txtCreditAdded.Text, out double creditAdded);//inline variable creation
            bool costOneParkWithCardValid = Double.TryParse(txtOneParkWithCard.Text, out double costOneParkWithCard);
            bool costOneParkNoCardValid = Double.TryParse(txtOneParkNoCard.Text, out double costOneParkNoCard);


            if (creditValid && costOneParkWithCardValid && costOneParkNoCardValid)//check all are valid
            {
                //Calculate number of times use can park, and any remaining credit
                int daysParking = (int)(creditAdded / costOneParkWithCard);
                double creditRemaining = creditAdded % costOneParkWithCard;
                double oneDaySavings = costOneParkNoCard - costOneParkWithCard;
                double totalSavings = daysParking * oneDaySavings;


                txtDaysParking.Text = daysParking.ToString();
                txtCreditRemaining.Text = creditRemaining.ToString("c");// Use currency formatting
                txtSavings.Text = totalSavings.ToString("c");
            }
            else
            {
                MessageBox.Show("Please enter numbers", "Error");
            }

        }
    }
}
