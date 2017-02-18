using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostageCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            entryChanged();
        }

        private void entryChanged()
        {
            // Check if required entries are filled
            if (!entrySelected()) return;
            
            // Get the volume
            int volume = 0;
            if (!getVolume(out volume)) return;

            // multiplier
            double postageMultiplier = getPostageMultiplier();

            // Calculate the cost
            double cost = volume * postageMultiplier;
            // Display the price
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", cost);
        }

        private bool entrySelected()
        {
            // check if required entries are filled and radio buttons are selected
            if (!airRadioButton.Checked
                && !groundRadioButton.Checked
                && !nextDayRadioButton.Checked)
                return false;

            if (widthTextBox.Text.Trim().Length == 0
                || heightTextBox.Text.Trim().Length == 0)
                return false;

            return true;
        }

        private bool getVolume(out int volume)
        {
            // get the volume
            // initial values
            volume = 0;
            int width = 0;
            int height = 0;
            int length = 0;

            // set length = 1 if no entry for length
            if (!int.TryParse(widthTextBox.Text.Trim(), out width)) return false;
            if (!int.TryParse(heightTextBox.Text.Trim(), out height)) return false;
            if (!int.TryParse(lengthTextBox.Text.Trim(), out length)) length = 1;

            // calculate the volume
            volume = width * height * length;

            return true;
        }

        
        private double getPostageMultiplier()
        {
            if (groundRadioButton.Checked) return 0.15;
            else if (airRadioButton.Checked) return 0.25;
            else if (nextDayRadioButton.Checked) return 0.45;
            else return 0;
        }
    }
}