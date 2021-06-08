using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MonoGame.Forms.Controls;
using MonoGame.Forms;
using System.ComponentModel;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Media;

namespace TaptCharter
{
    class ChartVisualizer : MonoGame.Forms.Controls.MonoGameControl
    {
        private static int bpm;
        private static int length;
        private static string name;
        private static string artist;
        private static string album;
        private static string filePath;
        private static string charter;
        private static bool songPlaying;

        private static SoundEffect loadedSong;
        private static SoundEffectInstance songInstance;

        private static string[] fileData; // This is where the initial data is read to. 
        private static string[] songInfo; // If there is a chart in the file, the initial information (name, artist, etc) is chopped off and put into another array.
        private static string[] chartData; // This is where the rest of the fileData, the usable information, is stored. 

        private KeyboardState previousState;

        //CharterForm charterForm;

        
        public ChartVisualizer()
        {
            filePath = "";
            songPlaying = false;
        }
        

        protected override void Draw()
        {
            base.Draw();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && !songPlaying)
            {
                try
                {
                    songPlaying = true;
                    songInstance = loadedSong.CreateInstance();
                    songInstance.Play();
                    
                } catch (Exception ex)
                {
                    Console.WriteLine("Attempted to load file at " + filePath + @"\song.wav");
                    Console.WriteLine("Error: " + ex.ToString());
                }
            } else if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && songPlaying)
            {
                songPlaying = false;
                songInstance.Stop();
            }


            base.Update(gameTime);

            previousState = keyboardState;
        }


        public void Load(string _filePath)
        {
            filePath = _filePath;
            string chartFilePath = filePath + @"\chart.taptchart";
            try
            {
                fileData = File.ReadAllLines(chartFilePath);
            } catch (Exception ex)
            {
                Console.WriteLine("Error reading file in Load function: " + ex.ToString());
                return;
            }
            

            bpm = Int32.Parse(fileData[0]);
            length = Int32.Parse(fileData[1]);
            name = fileData[3];
            //charterForm.Text = "Tapt Charter " + charterForm.Version + ": " + name;
            artist = fileData[4];
            album = fileData[5];
            charter = fileData[6];
            try
            {
                //loadedSong = SoundEffect.FromStream(new System.IO.FileStream(filePath + @"\song.wav", System.IO.FileMode.Open));
                //Console.WriteLine("Loaded sound at " + filePath + @"\song.wav");

                System.IO.FileStream fs = new System.IO.FileStream(filePath + @"\song.wav", System.IO.FileMode.Open);
                loadedSong = SoundEffect.FromStream(fs);
                Console.WriteLine("Loaded sound at " + filePath + @"\song.wav");
                fs.Dispose();
                
            } catch (Exception ex)
            {
                Console.WriteLine("Error loading wav file: " + ex.ToString());
                return;
            }

            if (fileData.Length > 9)
            {
                fileData.CopyTo(songInfo, 8);
                Array.Copy(fileData, 9, chartData, 0, fileData.Length-9);
            } else
            {
                return;
            }
        }
    }
}
