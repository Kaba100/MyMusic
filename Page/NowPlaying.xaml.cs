using CommunityToolkit.Maui.Views;
using MyMusic.ViewModels;
namespace MyMusic.Page;

public partial class NowPlaying : ContentPage
{
	public NowPlaying()
	{
		InitializeComponent();
		BindingContext = new NowPlayingVM(this);
        mlmt.MediaFailed += Mlmt_MediaFailed;
	}

    private void Mlmt_MediaFailed(object sender, CommunityToolkit.Maui.Core.Primitives.MediaFailedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Mlmt_Loaded(object sender, EventArgs e)
    {
        mlmt.PositionChanged += Mlmt_PositionChanged;

    }

    private void Mlmt_PositionChanged(object sender, CommunityToolkit.Maui.Core.Primitives.MediaPositionChangedEventArgs e)
    {
        Position = e.Position;
    }

    public TimeSpan Position { get; set; }

    public TimeSpan Duration => mlmt.Duration;

    public void Play()
    {
        mlmt.Play();
    }
    public void Pause()
    {
        mlmt.Pause();
    } 
    public void SetSourceUrl(string url)
    {
        mlmt.Source = MediaSource.FromUri(url);
        mlmt.ShouldAutoPlay = true;
    }
}