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
        private static string infoString;

        private static SoundEffect loadedSong;
        private static SoundEffectInstance songInstance;

        private static string[] fileData; // This is where the initial data is read to. 
        private static string[] songInfo; // If there is a chart in the file, the initial information (name, artist, etc) is chopped off and put into another array.
        private static string[] loadedChartData; // This is where the rest of the fileData, the usable information, is stored. 
        private static string[] newChartData; // This is where chart data is stored while editing.

        private KeyboardState previousState;



        public ChartVisualizer()
        {
            filePath = "";
        }
        

        protected override void Draw()
        {
            base.Draw();
            Editor.spriteBatch.Begin();

            if (name != null)
            {
                Editor.spriteBatch.DrawString(Editor.Font, infoString, new Vector2(20, 10), Color.White);
            }

            Editor.spriteBatch.End();

            // This is debug information, fps and cursor position. Uncomment as needed.
            //Editor.DrawDisplay();

        }

        protected override void Initialize()
        {
            base.Initialize();

            Editor.BackgroundColor = Color.Black;

        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Stopped)
            {
                try
                {
                    songInstance = loadedSong.CreateInstance();
                    songInstance.Play();
                    
                } catch (Exception ex)
                {
                    Console.WriteLine("Attempted to load file at " + filePath + @"\song.wav");
                    Console.WriteLine("Error: " + ex.ToString());
                }
            } else if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Playing)
            {
                songInstance.Stop();
            }


            base.Update(gameTime);

            previousState = keyboardState;
        }


        public void Load(string _filePath)
        {
            filePath = _filePath;
            string chartFilePath = filePath + @"\chart.taptchart";

            try // Pulling data from file
            {
                fileData = File.ReadAllLines(chartFilePath);
            } catch (Exception ex)
            {
                Console.WriteLine("Error reading file in Load function: " + ex.ToString());
                return;
            }
            
            // Pulling basic data from file
            bpm = Int32.Parse(fileData[0]);
            length = Int32.Parse(fileData[1]);
            name = fileData[3];
            artist = fileData[4];
            album = fileData[5];
            charter = fileData[6];

            infoString = "Name: " + name + " | Arist: " + artist + " | Album: " + album + " | Charter: " + charter;

            // Loading song file
            try
            {
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
                Array.Copy(fileData, 9, loadedChartData, 0, fileData.Length-9);
            } else
            {
                return;
            }
        }

        private void Generate(int _bpm, int _length)
        {
            float bpmf = (float)_bpm;
            int numRows = (bpm / 60) * _length * 4;
            newChartData = new string[numRows];
        }
    }
}
