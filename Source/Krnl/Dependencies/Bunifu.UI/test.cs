using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bunifu
{
    public class bunifu
    {
        // This class will hold custom methods and properties for the Bunifu controls

        // Method to change the appearance of a Bunifu button
        public static void ChangeButtonAppearance(Bunifu.Framework.UI.BunifuThinButton2 btn, int borderRadius, System.Drawing.Color btnColor, System.Drawing.Color textColor)
        {
            // Set button properties
            btn.BorderRadius = borderRadius;
            btn.ButtonText = "Custom Button";
            btn.FillColor = btnColor;
            btn.ForeColor = textColor;
            btn.IdleFillColor = btnColor;
            btn.IdleLineColor = textColor;
            btn.ActiveFillColor = btnColor;
            btn.ActiveLineColor = textColor;
        }

        // Method to make a label fade in and out
        public static async void FadeLabel(Bunifu.Framework.UI.BunifuCustomLabel label, int fadeInTime, int duration, int fadeOutTime)
        {
            // Set initial label opacity to 0
            label.Opacity = 0;

            // Fade in
            for (double i = 0; i <= 1.0; i += 0.05)
            {
                await Task.Delay(fadeInTime);
                label.Opacity = i;
            }
            // Wait for specified duration
            await Task.Delay(duration);

            // Fade out
            for (double i = 1.0; i >= 0; i -= 0.05)
            {
                await Task.Delay(fadeOutTime);
                label.Opacity = i;
            }
        }

        // Property to check if a Bunifu button is clicked
        public static bool IsButtonClicked(Bunifu.Framework.UI.BunifuMaterialTextbox txtbox)
        {
            // Check if the button clicked property is true
            if (txtbox.ButtonClicked)
            {
                txtbox.ButtonClicked = false;
                return true;
            }
            return false;
        }
    }
}
