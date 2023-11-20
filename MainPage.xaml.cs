namespace Ciurca_Radu_Lab7;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Cumparat {count} bufnita";
		else
			CounterBtn.Text = $"Cumparat {count} bufnite";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
	private void ResetCounter(object sender, EventArgs e)
	{
		count=0;
	}
}

