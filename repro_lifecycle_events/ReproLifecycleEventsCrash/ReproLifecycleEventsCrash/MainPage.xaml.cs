namespace ReproLifecycleEventsCrash;

public partial class MainPage : ContentPage
{
	int pageCount = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnNewWindowClicked(object sender, EventArgs e)
	{
		pageCount++;
		Window secondWindow = new MyWindow(new SweekyWindow(pageCount));
		Application.Current.OpenWindow(secondWindow);
	}

}


