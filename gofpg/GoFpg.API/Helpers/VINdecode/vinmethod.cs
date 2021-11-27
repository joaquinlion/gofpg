using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Helpers.VINdecode
{
    public class vinmethod
    {
        //private async void checkBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    if (vin.Text.Length > 17 || vin.Text.Length < 17)
        //    {
        //        resultsBox.Text = "VIN Number Length Is Incorrect";
        //    }

        //    //Send request
        //    RootObject myVin = await Decode.GetInfo(vin.Text);

        //    //Return Results
        //    resultsBox.Text = "Instructions: If a section empty manufacturer not provide those details." +
        //        "\n" + "Error code: " + myVin.Results[0].ErrorCode +
        //        //29 Year
        //        "\n" + "Year: " + myVin.Results[0].ModelYear +
        //        //26 Make
        //        "\n" + "Make: " + myVin.Results[0].Make +
        //        //28 Model
        //        "\n" + "Model: " + myVin.Results[0].Model +
        //        // 5 Body Class
        //        "\n" + "Body Class: " + myVin.Results[0].BodyClass +
        //        "\n" + "Doors: " + myVin.Results[0].Doors +
        //        // 39 Vehicle Type
        //        //"\n" + "Vehicle Type: " + myVin.Results[0].VehicleType +
        //        // 102 Lane Departure Warning
        //        "\n" + "Lane Departure Warning: " + myVin.Results[0].LaneDepartureWarning +
        //        // 103 Lane Keep System
        //        "\n" + "Lane Keep System: " + myVin.Results[0].LaneKeepSystem;

        //}
    }
}
