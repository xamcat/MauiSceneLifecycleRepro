using System.Diagnostics;

namespace ReproLifecycleEventsCrash;

public partial class SweekyWindow : ContentPage
{
	public SweekyWindow(int pageCount)
	{
		InitializeComponent();
		this.titleLabel.Text = $"WINDOW COUNT {pageCount}";
	}

}
