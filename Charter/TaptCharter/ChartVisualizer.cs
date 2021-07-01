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

public enum NoteType
{
    None = 0,
    Full = 1,
    Half = 2,
    Quarter = 3,
    ThreeQuarter = 4,
    FullSustainStart = 5,
    HalfSustainStart = 6,
    QuarterSustainStart = 7,
    ThreeQuarterSustainStart = 8,
    SustainEnd = 9
}
public enum EditorState
{

}

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

        private static string[] fileChartData; // This is where the initial data is read to. 
        private static string[] songInfo; // If there is a chart in the file, the initial information (name, artist, etc) is chopped off and put into another array.
        private static string[] loadedChartData; // This is where the rest of the fileData, the usable information, is stored. 
        private static Note[,] chartData; // This is where chart data is stored while editing.

        private Texture2D blankNoteTexture;

        private KeyboardState keyboardState;
        private KeyboardState previousKeyboard;
        private MouseState mouseState;
        private MouseState previousMouse;

        private static int xOffset = 100; // This shouldn't change
        private static float yOffset; // This will change

        private static Texture2D textBackgroundRectangle;

        private Color[] colorData;

        public ChartVisualizer()
        {
            filePath = "";

            
            colorData = new Color[724 * 50];

            for (int i = 0; i < colorData.Length; i++)
            {
                colorData[i] = Color.Black;
            }

            
            

            yOffset = 100;
        }
        
        
        protected override void Draw()
        {
            base.Draw();
            Editor.spriteBatch.Begin();

            // This causes a massive memory issue. However it is necessary. Must fix.

            //textBackgroundRectangle = new Texture2D(Editor.graphics, 724, 50);
            //textBackgroundRectangle.SetData(colorData);


            // Drawing the notes
            if (chartData != null)
            {
                foreach (Note note in chartData)
                {
                    if (note.IsActive)
                    {
                        switch (note.NoteType)
                        {
                            case NoteType.Quarter:
                                // switch blankNoteTexture to quarternotetexture when its made
                                Editor.spriteBatch.Draw(blankNoteTexture, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), note.ActiveColor);
                                break;
                        }
                        
                    } else
                    {
                        Editor.spriteBatch.Draw(blankNoteTexture, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), Color.White);
                    }
                    
                }
                // Junk. Inefficent way to draw the notes but I'm leaving it in in case my efficient way doesn't actually work.
                /*
                for (int i = 0; i < chartData.Length / 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        switch (chartData[i, j].NoteType)
                        {
                            case NoteType.None:
                                Editor.spriteBatch.Draw(blankNoteTexture, new Vector2(yOffset + j * 32, xOffset + i * 32), Color.White);
                                break;
                        }

                    }
                }
                */


                //Editor.spriteBatch.Draw(textBackgroundRectangle, new Vector2(0, 0), Color.Black);
                if (name != null)
                {
                    Editor.spriteBatch.DrawString(Editor.Font, infoString, new Vector2(20, 10), Color.White);
                }
            }


            
            Editor.spriteBatch.End();

            // This is debug information, fps and cursor position. Uncomment as needed.
            //Editor.DrawDisplay();

        }

        protected override void Initialize()
        {
            base.Initialize();

            Editor.BackgroundColor = Color.Black;
            blankNoteTexture = Editor.Content.Load<Texture2D>("blanknote");

        }


        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (songInstance != null)
            {
                // Handling sound playing
                // If you press space the song starts playing. If you press space again it stops playing. And so forth.
                if (keyboardState.IsKeyDown(Keys.Space) && !previousKeyboard.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Stopped)
                {
                    songInstance.Play();
                    previousKeyboard = keyboardState;
                    keyboardState = Keyboard.GetState();
                } else if (keyboardState.IsKeyDown(Keys.Space) && !previousKeyboard.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Playing)
                {
                    songInstance.Stop();
                    yOffset = 100;
                }

                if (songInstance.State == SoundState.Playing)
                {
                    // The math was never broken... literally everything else was. Nice.
                    // Discovered that everything needed to be casted to an float when calculating the number of rows.
                    // Int division caused it to ALWAYS be short which is what caused the issue. 
                    yOffset -= ((float)bpm/60f * 4f * 32f / 1000f) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (songInstance.State == SoundState.Stopped)
                    {
                        yOffset = 100;
                    }
                }
                
            }
            

            if ((mouseState.ScrollWheelValue < previousMouse.ScrollWheelValue)) // Stops you from scrolling down if the end of the chart is on the screen
                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ STILL NEEDS MATH ADDED! DO NOT FORGET
            {
                yOffset-= 32;
            }
            else if ((mouseState.ScrollWheelValue > previousMouse.ScrollWheelValue) && yOffset < 100) // Stops you from scrolling up if it's in default state/can't go lower
            {
                yOffset+= 32;
            }
            //Console.WriteLine("ScrollWheelValue: " + mouseState.ScrollWheelValue);

            //Console.WriteLine(yOffset);

            base.Update(gameTime);

            previousKeyboard = keyboardState;
            previousMouse = mouseState;
        }

        /// <summary>
        /// Loads in chart data to the visualizer
        /// </summary>
        /// <param name="_filePath">Path of the current song directory</param>
        public void LoadChart(string _filePath)
        {
            filePath = _filePath;
            string chartFilePath = filePath + @"\chart.taptchart";
            string infoFilePath = filePath + @"\songinfo.txt";

            try // Pulling data from chart file
            {
                fileChartData = File.ReadAllLines(chartFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file in Load function: " + ex.ToString());
                return;
            }

            try // Pulling data from info file
            {
                songInfo = File.ReadAllLines(infoFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file in Load function: " + ex.ToString());
                return;
            }

            // Pulling basic data from file
            bpm = Int32.Parse(fileChartData[0]);
            length = Int32.Parse(fileChartData[1]);
            name = songInfo[0];
            artist = songInfo[1];
            album = songInfo[2];
            charter = songInfo[3];

            int numRows = (int)(((float)bpm / 60f) * (float)length * 4f) + 1;
            chartData = new Note[numRows, 9];
            //Console.WriteLine("BPM: " + bpm + " LENGTH: " + length + " NUMROWS: " + numRows);

            infoString = "Name: " + name + " | Arist: " + artist + " | Album: " + album + " | Charter: " + charter;

            // Loading song file
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(filePath + @"\song.wav", System.IO.FileMode.Open);
                loadedSong = SoundEffect.FromStream(fs);
                Console.WriteLine("Loaded sound at " + filePath + @"\song.wav");
                songInstance = loadedSong.CreateInstance();
                fs.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading wav file: " + ex.ToString());
                return;
            }



            if (fileChartData.Length > 2)
            {
                loadedChartData = new string[fileChartData.Length - 2];
                Array.Copy(fileChartData, 2, loadedChartData, 0, fileChartData.Length - 2);
                ConvertStringToNotes(loadedChartData);
            }
            else
            {
                Generate(bpm, length);
            }

            

            /*
            try
            {
                songInstance = loadedSong.CreateInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Attempted to load file at " + filePath + @"\song.wav");
                Console.WriteLine("Error: " + ex.ToString());
            }
            */
        }
        /// <summary>
        /// Updates song info in the visualizer when it is edited
        /// </summary>
        /// <param name="songInfo">SongInfo string spit out by the Create function in CharterForm</param>
        public void UpdateInfo(string[] songInfo)
        {
            name = songInfo[0];
            artist = songInfo[1];
            album = songInfo[2];
            charter = songInfo[3];

            infoString = "Name: " + name + " | Arist: " + artist + " | Album: " + album + " | Charter: " + charter;
        }
        /// <summary>
        /// Generates the QD data for the song. Needs work.
        /// </summary>
        /// <param name="_bpm">Song BPM</param>
        /// <param name="_length">Song length</param>
        private void Generate(int _bpm, int _length)
        {
            //float bpmf = (float)_bpm; // I don't remember why i put this here, but I'm not deleting it in case it was important. I don't think it's ever used.

            int numRows = (int)(((float)bpm / 60f) * (float)length * 4f) + 1;
            //Console.WriteLine("BPM: " + _bpm + " LENGTH: " + _length + " NUMROWS: " + numRows);
            chartData = new Note[numRows, 9];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < 9; i++) {
                    chartData[i, j] = new Note(i, j, NoteType.None);
                }
            }
            Save(filePath, _bpm, _length);
        }

        public void Save(string _filePath, int bpm, int length)
        {
            string chartFilePath = filePath + @"\chart.taptchart";


            using (StreamWriter outputFile = new StreamWriter(chartFilePath, false))
            {
                outputFile.WriteLine(bpm);
                outputFile.WriteLine(length);
                for (int i = 0; i < chartData.Length/9; i++)
                {
                    for (int j = 0; i < 10; i++)
                    {
                        if (i == 9)
                        {
                            outputFile.Write("\r\n");
                        } else
                        {
                            outputFile.Write((int)chartData[i, j].NoteType);
                        }
                    }
                }
                
            }
        }
        /// <summary>
        /// Converts a loaded in string array from a file to chart data in notes
        /// </summary>
        /// <param name="_loadedChartData">Loaded in chart data string array</param>
        private void ConvertStringToNotes(string[] _loadedChartData)
        {
            for (int i = 0; i < _loadedChartData.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    chartData[i, j] = new Note(i, j, (NoteType)Int32.Parse(_loadedChartData[i][j].ToString()));
                }
            }
        }
    }
}
