using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MyMusic.Models;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using MyMusic.Page;

namespace MyMusic.ViewModels
{
    public partial class PopularVM : ObservableObject

    {
        [ObservableProperty]
        public ObservableCollection<Popular> populars;

        [ObservableProperty]
        public ObservableCollection<Song> playlists;

        [ObservableProperty]
        public ObservableCollection<NowPlayingMusic> nowPlayings;

        [ObservableProperty]
        public Song selectedSong;
        public ICommand SelectedSongCommand => new Command(GoToNowPlaying);

        public ICommand SelectedItemCommand => new Command<Song>(async (song) =>
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["selectedSong"] = song;
            data["mouriba"] = "Kaba";

            await Shell.Current.GoToAsync(nameof(NowPlaying), data);
        });




        private async void GoToNowPlaying()
        {
            await Shell.Current.GoToAsync("NowPlaying");
        }
        public PopularVM()
        {




            populars = new ObservableCollection<Popular>();
            Popular a = new Popular();
            a.Image = "banner.png";
            populars.Add(a);

            Popular b = new Popular();
            b.Image = "banner.png";
            populars.Add(b);

            Popular c = new Popular();
            c.Image = "banner.png";
            populars.Add(c);

            Popular d = new Popular();
            d.Image = "banner.png";
            populars.Add(d);

            Popular e = new Popular();
            e.Image = "banner.png";
            populars.Add(e);




            playlists = new ObservableCollection<Song>();
            Song aa = new Song();
            aa.SongTitle = "April";
            aa.Artiste = "Fiersa Bersari";
            aa.Image = "banner.png";
            aa.Duration = "4.24";           
            aa.Url = "https://p.scdn.co/mp3-preview/9d61998a29c2e8b52a7d46885352f5507eb219e2?cid=b5c8184f7dc34142b1d9cdddef4bb8b6";
            playlists.Add(aa);

            Song bb = new Song();
            bb.SongTitle = "Different World";
            bb.Artiste = "Alan Walker,K-391 & Sofia Carson";
            bb.Image = "banner.png";
            bb.Duration = "2.46";
            bb.Url = "https://p.scdn.co/mp3-preview/abcbc9adf10ae4901b40b80a30dc194d589c2d62?cid=b5c8184f7dc34142b1d9cdddef4bb8b6";
            playlists.Add(bb);

            Song cc = new Song();
            cc.SongTitle = "My Boo";
            cc.Artiste = "Usher,Alicia Keys";
            cc.Image = "banner.png";
            cc.Duration = "3.43";
            cc.Url = "https://p.scdn.co/mp3-preview/736c0ff37c1b6b7ca182ea6e78db36163e5e6eae?cid=b5c8184f7dc34142b1d9cdddef4bb8b6";
            playlists.Add(cc);

            Song dd = new Song();
            dd.SongTitle = "Islama";
            dd.Artiste = "Unknown Artist-Unknown Album";
            dd.Image = "banner.png";
            dd.Duration = "3.41";
            dd.Url = "https://p.scdn.co/mp3-preview/4bd2dc84016f3743add7eea8b988407b1b900672?cid=b5c8184f7dc34142b1d9cdddef4bb8b6";
            playlists.Add(dd);

          

            nowPlayings = new ObservableCollection<NowPlayingMusic>();
            NowPlayingMusic now = new NowPlayingMusic();
            now.Music = "Different World";
            now.Artiste = "Alan Walker,K-391 & Sofia Carson";
            now.Picture = "banner.png";
            now.Image = "banner.png";
            nowPlayings.Add(now);



        }
    }
}
