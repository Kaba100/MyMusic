using MyMusic.Page;
namespace MyMusic;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("NowPlaying", typeof(NowPlaying));
	}
}
