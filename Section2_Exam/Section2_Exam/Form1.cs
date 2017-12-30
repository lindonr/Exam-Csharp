using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section2_Exam
{
    public partial class Form1 : Form
    {
        public int processed = 0;
        public int granted = 0;
        public int denied = 0;

        public bool correct_input;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Exit_Msg = "Total Processed: "+ Convert.ToString(processed) 
                + Environment.NewLine + "Total Credits Granted: " + Convert.ToString(granted)
                + Environment.NewLine + "Total Credits Denied: " + Convert.ToString(denied);
            MessageBox.Show(Exit_Msg);
            this.Close();
        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            if ((TOFYearstextBox.BackColor == System.Drawing.Color.GreenYellow) 
                && (TOFMonthstextBox.BackColor == System.Drawing.Color.GreenYellow) 
                && (IncometextBox.BackColor == System.Drawing.Color.GreenYellow)
                && (ExpensetextBox.BackColor == System.Drawing.Color.GreenYellow)
                && (CredCardtextBox.BackColor == System.Drawing.Color.GreenYellow))
            {
                processed++;
                if (CreditDecision() == true)
                {
                    granted++;
                    Eligibilitylabel.Text = "Eligible";
                    Eligibilitylabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    denied++;
                    Eligibilitylabel.Text = "Not Eligible";
                    Eligibilitylabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                int count = 1;
                string ErrorMsg = "Fields Required: " + Environment.NewLine;
                if(string.IsNullOrWhiteSpace(FirstNametextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". First Name." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(LastNametextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Last Name." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(AddresstextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Adderss." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(CitytextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". City." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(StatetextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". State." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(ZipCodetextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Zip Code." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(TOFYearstextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Years of Residense." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(TOFMonthstextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Months of Residense." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(IncometextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Monthly Income." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(ExpensetextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Monthly Expense." + Environment.NewLine;
                    count++;
                }
                if (string.IsNullOrWhiteSpace(CredCardtextBox.Text))
                {
                    ErrorMsg = ErrorMsg + count + ". Credit Card." + Environment.NewLine;
                    count++;
                }

                ErrorMsg = ErrorMsg + Environment.NewLine + "Invalid Data in: " + Environment.NewLine;
                count = 0;

                if (TOFYearstextBox.BackColor != System.Drawing.Color.GreenYellow
                    && TOFMonthstextBox.BackColor != System.Drawing.Color.GreenYellow)
                {
                    ErrorMsg = ErrorMsg + count + ". Years and/or Months(Total Months either too high or too low)." + Environment.NewLine;
                    count++;
                }
                if (IncometextBox.BackColor != System.Drawing.Color.GreenYellow)
                {
                    ErrorMsg = ErrorMsg + count + ". Monthly Income." + Environment.NewLine;
                    count++;
                }
                if(ExpensetextBox.BackColor != System.Drawing.Color.GreenYellow)
                {

                    ErrorMsg = ErrorMsg + count + ". Monthly Expense." + Environment.NewLine;
                    count++;
                }
                if(CredCardtextBox.BackColor != System.Drawing.Color.GreenYellow)
                {
                    ErrorMsg = ErrorMsg + count + ". Number of Credit Cards." + Environment.NewLine;
                    count++;
                }

                MessageBox.Show(ErrorMsg);
            }
            
        }
        private bool CreditDecision()
        {            
            double monthlyIncome = Convert.ToDouble(IncometextBox.Text);
            double monthlyExpense = Convert.ToDouble(ExpensetextBox.Text);
            double residency_months = Convert.ToDouble(TOFMonthstextBox.Text) + 12 * Convert.ToDouble(TOFYearstextBox.Text);
            bool is_eligible = false;

            if (monthlyIncome > 500)
            {
                if (monthlyExpense > (0.36 * monthlyIncome))
                {
                    if (residency_months > 18)
                    {
                        is_eligible = true;
                    }
                    else
                    {
                        is_eligible = false;
                    }
                }
                else
                {
                    is_eligible = true;
                }
            }
            else
            {
                if (monthlyExpense > (0.18 * monthlyIncome))
                {
                    is_eligible = false;
                }
                else
                {
                    if (residency_months>54)
                    {
                        is_eligible = true;
                    }
                    else
                    {
                        is_eligible = false;
                    }
                }
            }
            return is_eligible;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            FirstNametextBox.Text = "";            
            LastNametextBox.Text = "";
            AddresstextBox.Text = "";
            CitytextBox.Text = "";
            StatetextBox.Text = "";
            ZipCodetextBox.Text = "";
            TOFMonthstextBox.Text = "";
            TOFYearstextBox.Text = "";
            IncometextBox.Text = "";
            ExpensetextBox.Text = "";
            CredCardtextBox.Text = "";
            
            TOFMonthstextBox.BackColor = System.Drawing.Color.Empty;
            TOFYearstextBox.BackColor = System.Drawing.Color.Empty;
            IncometextBox.BackColor = System.Drawing.Color.Empty;
            ExpensetextBox.BackColor = System.Drawing.Color.Empty;
            CredCardtextBox.BackColor = System.Drawing.Color.Empty;
        }

        private void IncometextBox_Enter(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(TOFMonthstextBox.Text) + 12 * (Convert.ToInt32(TOFYearstextBox.Text));
            if (month > 0 && month <= 1440)
            {
                TOFMonthstextBox.BackColor = System.Drawing.Color.GreenYellow;
                TOFYearstextBox.BackColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                TOFMonthstextBox.BackColor = System.Drawing.Color.Red;
                TOFYearstextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void IncometextBox_Leave(object sender, EventArgs e)
        {
            int income = Convert.ToInt32(IncometextBox.Text);

            if (income>0)
            {

                IncometextBox.BackColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                IncometextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void ExpensetextBox_Leave(object sender, EventArgs e)
        {
            int expense = Convert.ToInt32(ExpensetextBox.Text);

            if (expense > 0)
            {

                ExpensetextBox.BackColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                ExpensetextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void CredCardtextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void CredCardtextBox_TextChanged(object sender, EventArgs e)
        {
            int cred = Convert.ToInt32(CredCardtextBox.Text);

            if(string.IsNullOrWhiteSpace(CredCardtextBox.Text))
            {
                CredCardtextBox.BackColor = System.Drawing.Color.Empty;
            }
            else if (cred >= 0)
            {

                CredCardtextBox.BackColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                CredCardtextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button3_Click(sender, e);
            }
        }
    }    
}
