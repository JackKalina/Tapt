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

namespace TaptCharter
{
    class ChartVisualizer : MonoGame.Forms.Controls.MonoGameControl
    {
        int bpm;
        int length;
        string name;
        string artist;
        string album;
        string filePath;
        string charter;

        SoundEffect loadedSong;

        string[] fileData; // This is where the initial data is read to. 
        string[] songInfo; // If there is a chart in the file, the initial information (name, artist, etc) is chopped off and put into another array.
        string[] chartData; // This is where the rest of the fileData, the usable information, is stored. 

        KeyboardState previousState;

        //CharterForm charterForm;

        
        public ChartVisualizer()
        {
            
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

            if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space))
            {
                loadedSong.Play();
            }


            base.Update(gameTime);

            previousState = keyboardState;
        }


        public void Load(string filePath)
        {
            string chartFilePath = filePath + @"/chart.taptchart";
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

            loadedSong = SoundEffect.FromStream(new System.IO.FileStream(filePath + "/song.wav", System.IO.FileMode.Open));

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
