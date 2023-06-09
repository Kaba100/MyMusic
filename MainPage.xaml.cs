using MyMusic.Models;
using MyMusic.ViewModels;

namespace MyMusic;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new PopularVM();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("NowPlaying");

    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // await Shell.Current.GoToAsync("NowPlaying");
       /* Dictionary<string, object> data = new Dictionary<string, object>();
        data["selectedSong"] = song;

        await Shell.Current.GoToAsync($"NowPlaying", data);*/
    }
}

