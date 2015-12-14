using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PooP.GUI.Audio
{
    public class Sound
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static Sound INSTANCE = new Sound();
        private SoundPlayer music;
        private MusicTimer musicWorker;
        private Thread musicThread;

        private Sound()
        {
            int NewVolume = ((ushort.MaxValue / 10) * 1);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);

            music = new SoundPlayer("../../audio/Oursvince_-_Magic_Spell.wav");
        }

        public void StartMusic()
        {
            musicWorker = new MusicTimer(this);
            musicThread = new Thread(musicWorker.DoWork);
            musicThread.Start();
        }

        private void StartMusicIntern()
        {
            music.Play();
        }

        public void StopMusic()
        {
            musicWorker.RequestStop();
        }

        private void StopMusicIntern()
        {
            music.Stop();
        }

        private class MusicTimer
        {
            // Volatile is used as hint to the compiler that this data
            // member will be accessed by multiple threads.
            private volatile bool _shouldStop = false;
            private Sound sound;

            public MusicTimer(Sound sound)
            {
                this.sound = sound;
            }

            // This method will be called when the thread is started.
            public void DoWork()
            {
                sound.StartMusicIntern();
                while (!_shouldStop)
                {
                    int last = 3 * 60;
                    while (!_shouldStop && last > 1)
                    {
                        Thread.Sleep(1000);
                        last--;
                    }
                    sound.StopMusicIntern();
                    sound.StartMusicIntern();
                }
                sound.StopMusicIntern();
            }
            public void RequestStop()
            {
                sound.StopMusicIntern();
                _shouldStop = true;
            }
        }
    }
}
