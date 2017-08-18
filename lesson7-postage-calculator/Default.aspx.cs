using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lesson7_postage_calculator
{
    public partial class Default : System.Web.UI.Page
    {
        // Set constant values for shipping multipliers
        private double GROUND_SHIPPING_MULTIPLIER = 0.15;
        private double AIR_SHIPPING_MULTIPLIER = 0.25;
        private double NEXT_DAY_SHIPPING_MULTIPLIER = 0.45;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));           
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayPostageCost(calculatePostageCost(validateData(), determineShippingMultiplier()));
        }

         
        /* Determine if the user has entered valid numbers in the fields for width, height and length. 
           Length is not required so it is set to a default value if not provided.
           The numbers are returned as elements of an array.
        */
        private double[] validateData()
        {
            double[] numberArray = new double[3];
            double width;
            double height;
            double length;

            bool widthValid = double.TryParse(widthTextBox.Text.Trim(), out width);
            bool heightValid = double.TryParse(heightTextBox.Text.Trim(), out height);
            bool lengthValid = double.TryParse(lengthTextBox.Text.Trim(), out length);

            if(!lengthValid)
            {
                length = 1.0;
                lengthValid = true;
            }

            if (widthValid && heightValid && lengthValid)
            {
                numberArray[0] = width;
                numberArray[1] = height;
                numberArray[2] = length;
            }

            return numberArray;
        }

        // Return the appropriate shipping multiplier value based on which radio button is selected
        private double determineShippingMultiplier()
        {
            if (groundRadioButton.Checked)
                return GROUND_SHIPPING_MULTIPLIER;
            else if (airRadioButton.Checked)
                return AIR_SHIPPING_MULTIPLIER;
            else
                return NEXT_DAY_SHIPPING_MULTIPLIER;
        }
        // Calculate and return the total cost of postage based on the width, height and length provided
        // as well as the shipping multiplier determined by the user's choice of shipping method.
        private double calculatePostageCost(double[] numArray, double shippingMultiplier)
        {
            double postageCost = numArray[0] * numArray[1] * numArray[2] * shippingMultiplier;

            return postageCost;
        }

        // Display the calculated cost of postage to the screen formatted as currency.
        private void displayPostageCost(double postageCost)
        {
            if (postageCost != 0)
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", postageCost);
            else
                resultLabel.Text = "";
        }
    }
}