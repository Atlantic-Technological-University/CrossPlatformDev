using Microsoft.Maui.ApplicationModel.Communication;

namespace MyMAUIApp;


public partial class Dialer : ContentPage
{
    string translatedNumber;
	public Dialer()
	{
		InitializeComponent();
	}



    private void TranslateButton_Clicked(object sender, EventArgs e)
    {

        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = MyMAUIApp.MyPhoneDialer.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + translatedNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    async void CallButton_Clicked(object sender, EventArgs e)
    {
        if (await this.DisplayAlert(
        "Dial a Number",
        "Would you like to call " + translatedNumber + "?",
        "Yes",
        "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(translatedNumber);
                //else
                  // await DisplayAlert("Unsupported feature ", "You can not call numbers from this device", "OK");
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                // Other error has occurred.
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }

        }
    }

    
}