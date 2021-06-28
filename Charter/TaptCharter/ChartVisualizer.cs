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

        private KeyboardState previousState;



        public ChartVisualizer()
        {
            filePath = "";
        }
        
        
        protected override void Draw()
        {
            base.Draw();
            Editor.spriteBatch.Begin();

            int xOffset = 100;
            int yOffset = 50;


            if (name != null)
            {
                Editor.spriteBatch.DrawString(Editor.Font, infoString, new Vector2(20, 10), Color.White);
            }
            // Drawing the notes
            if (chartData != null)
            {
                foreach (Note note in chartData)
                {
                    switch (note.NoteType)
                    {
                        case NoteType.None:
                            Editor.spriteBatch.Draw(blankNoteTexture, new Vector2(yOffset + note.Col * 32, xOffset + note.Row * 32), Color.White);
                            break;
                    }
                }
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
            KeyboardState keyboardState = Keyboard.GetState();

            // Handling sound playing
            // If you press space the song starts playing. If you press space again it stops playing. And so forth.
            if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Stopped)
            {
                songInstance.Play();
            } else if (keyboardState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space) && songInstance.State == SoundState.Playing)
            {
                songInstance.Stop();
            }


            base.Update(gameTime);

            previousState = keyboardState;
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

            int numRows = ((bpm / 60) * length * 4) + 1;
            chartData = new Note[numRows, 9];

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
            int numRows = ((_bpm / 60) * _length * 4) + 1;
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
