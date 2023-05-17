using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace ColorMauiApp;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string HexValue; 
    public MainPage()
    {
        InitializeComponent();
    }

    void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = SldRed.Value;
            var green = SldGreen.Value;
            var blue = SldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
        
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        HexValue = color.ToHex();
        lblHex.Text = HexValue;
    }

    void btnRandom_Clicked(System.Object sender, System.EventArgs e)
    {
        isRandom = true;
        var random = new Random();
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        SetColor(color);
        SldRed.Value = color.Red;
        SldGreen.Value = color.Green;
        SldBlue.Value = color.Blue;
        isRandom = false;
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Clipboard.SetTextAsync(HexValue);
        var toast = Toast.Make("Color Copied" , CommunityToolkit.Maui.Core.ToastDuration.Short,12);
        await toast.Show();
         
    }
}


