using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Text;
using MyMusic.Models;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using MyMusic.Page;

namespace MyMusic.ViewModels
{
    public partial class NowPlayingVM : BaseViewModel, IQueryAttributable
    {
        
        private ObservableCollection<NowPlaying> nowPlayings;
        public ObservableCollection<NowPlaying> NowPlayings
        {
            get { return nowPlayings; }
            set 
            { 
                nowPlayings = value;
                OnPropertyChanged();

            }

        }

        
        private Song selectedSong;
        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                selectedSong = value;
                OnPropertyChanged();

            }

        }

        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();

            }

        }
        private TimeSpan position;
        public TimeSpan Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();

            }

        }


        private double maximum;
        public double Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                OnPropertyChanged();

            }

        }
        private bool isplaying;
        public bool Isplaying
        {
            get { return isplaying; }
            set
            {
                isplaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayIcon));
            }

        }
        private string PlayIcon{ get => Isplaying ? "pause.png" : "play.png"; }
        //public string PlayIcon{ get { if(Isplaying)
        //        {
        //            return "pause.png";
        //        }
        //        else
        //        {
        //            return "play,png";
        //        }
        //    }
            

        //}




        ICommand PlayCommand => new Command(PlayMusic);

        NowPlaying cb;
        public NowPlayingVM(NowPlaying nowpl)
        {
            nowPlayings = new ObservableCollection<NowPlaying>();
     

            cb = nowpl;
        //    medialmt.Loaded += Medialmt_Loaded;
         
        }




        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            var song = query["selectedSong"] as Song;

            var mk = query["mouriba"] as string;

            SelectedSong = song;
            Play(SelectedSong);
            Isplaying = true;
        }


        public void PlayMusic()
        {
             
            if (Isplaying)
            {
                cb.Pause();
                Isplaying = false;
            }
            else
            {
                cb.Play();
                Isplaying = true;
            }
            
        }

        public void Play( Song song)
        {

            cb.SetSourceUrl(song.Url);
            cb.Play();
            Isplaying = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Duration = cb.Duration;
                Maximum = cb.Duration.TotalSeconds;
                Position = cb.Position;
                return true;

            });

        }
   
    }

}
