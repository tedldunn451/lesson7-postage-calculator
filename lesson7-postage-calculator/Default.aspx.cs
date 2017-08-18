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

        private double determineShippingMultiplier()
        {
            if (groundRadioButton.Checked)
                return GROUND_SHIPPING_MULTIPLIER;
            else if (airRadioButton.Checked)
                return AIR_SHIPPING_MULTIPLIER;
            else
                return NEXT_DAY_SHIPPING_MULTIPLIER;
        }

        private double calculatePostageCost(double[] numArray, double shippingMultiplier)
        {
            double postageCost = numArray[0] * numArray[1] * numArray[2] * shippingMultiplier;

            return postageCost;
        }

        private void displayPostageCost(double postageCost)
        {
            if (postageCost != 0)
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", postageCost);
            else
                resultLabel.Text = "";
        }
    }
}