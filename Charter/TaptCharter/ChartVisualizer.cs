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
    SustainEnd = 9,
    Covered = 10
}
public enum EditorState
{
    PlaceFull,
    PlaceHalf,
    PlaceQuarter,
    PlaceThreeQuarter,
    PlaceFullSustain,
    PlaceHalfSustain,
    PlaceQuarterSustain,
    PlaceThreeQuarterSustain,
    PlaceSustainEnd,
    Erase,
    None
}
public enum ButtonType
{
    OneButton,
    TwoButton,
    ThreeButton,
    FourButton,
    DeleteButton
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

        #region Texture loading
        private Texture2D quarterNote;
        private Texture2D halfNote;
        private Texture2D threeQuarterNote;
        private Texture2D fullNote;
        private Texture2D beatlineTexture;
        private Texture2D textBackground;

        private Texture2D oneButton;
        private Texture2D oneButtonPressed;
        private Texture2D twoButton;
        private Texture2D twoButtonPressed;
        private Texture2D threeButton;
        private Texture2D threeButtonPressed;
        private Texture2D fourButton;
        private Texture2D fourButtonPressed;
        private Texture2D deleteButton;
        private Texture2D deleteButtonPressed;
        
        #endregion
        
        private KeyboardState keyboardState;
        private KeyboardState previousKeyboard;
        private MouseState mouseState;
        private MouseState previousMouse;

        private static int xOffset = 100; // This shouldn't change
        private static float yOffset; // This will change

        private EditorState currentEditorState;
        private int currentMouseX;
        private int currentMouseY;
        private int clickedCol;
        private int clickedRow;


        public ChartVisualizer()
        {
            filePath = "";
            currentEditorState = EditorState.PlaceQuarter;
            

            yOffset = 128;



        }


        protected override void Draw()
        {
            base.Draw();
            Editor.spriteBatch.Begin();


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
                                Editor.spriteBatch.DrawString(Editor.Font, note.Row.ToString(), new Vector2(10, yOffset + (float)note.Row * 32f), Color.Black);
                                Editor.spriteBatch.Draw(quarterNote, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), note.ActiveColor);
                                break;
                            case NoteType.Half:
                                Editor.spriteBatch.DrawString(Editor.Font, note.Row.ToString(), new Vector2(10, yOffset + (float)note.Row * 32f), Color.Black);
                                Editor.spriteBatch.Draw(halfNote, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), note.ActiveColor);
                                break;
                            case NoteType.ThreeQuarter:
                                Editor.spriteBatch.DrawString(Editor.Font, note.Row.ToString(), new Vector2(10, yOffset + (float)note.Row * 32f), Color.Black);
                                Editor.spriteBatch.Draw(threeQuarterNote, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), note.ActiveColor);
                                break;
                            case NoteType.Full:
                                Editor.spriteBatch.DrawString(Editor.Font, note.Row.ToString(), new Vector2(10, yOffset + (float)note.Row * 32f), Color.Black);
                                Editor.spriteBatch.Draw(fullNote, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), note.ActiveColor);
                                break;

                        }
                        
                    } else
                    {
                        if (note.NoteType == NoteType.Covered)
                        {
                            continue;
                        } else
                        {
                            Editor.spriteBatch.DrawString(Editor.Font, note.Row.ToString(), new Vector2(10, yOffset + 5 + (float)note.Row * 32f), Color.Black);
                            Editor.spriteBatch.Draw(quarterNote, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f), Color.White);
                        }
                        
                    }
                    if (note.Row % 4 == 0)
                    {
                        Editor.spriteBatch.Draw(beatlineTexture, new Vector2(xOffset + note.Col * 32, yOffset + (float)note.Row * 32f - 1), Color.White);

                    }

                }

                // White space so that notes disappear earlier
                Editor.spriteBatch.Draw(textBackground, new Vector2(0, 0), Color.White);

                //Editor.spriteBatch.Draw(textBackgroundRectangle, new Vector2(0, 0), Color.Black);
                if (name != null)
                {
                    Editor.spriteBatch.DrawString(Editor.Font, infoString, new Vector2(20, 10), Color.Black, 0f, new Vector2(0,0), 1.5f, SpriteEffects.None, 0f);
                }

                
            }

            Editor.spriteBatch.Draw(oneButton, new Vector2(660, 132), Color.White);
            Editor.spriteBatch.Draw(twoButton, new Vector2(660, 196), Color.White);
            Editor.spriteBatch.Draw(threeButton, new Vector2(660, 260), Color.White);
            Editor.spriteBatch.Draw(fourButton, new Vector2(660, 324), Color.White);
            Editor.spriteBatch.Draw(deleteButton, new Vector2(660, 388), Color.White);

            switch (currentEditorState)
            {
                case EditorState.PlaceQuarter:
                    Editor.spriteBatch.Draw(oneButtonPressed, new Vector2(660, 132), Color.White);
                    break;
                case EditorState.PlaceHalf:
                    Editor.spriteBatch.Draw(twoButtonPressed, new Vector2(660, 196), Color.White);
                    break;
                case EditorState.PlaceThreeQuarter:
                    Editor.spriteBatch.Draw(threeButtonPressed, new Vector2(660, 260), Color.White);
                    break;
                case EditorState.PlaceFull:
                    Editor.spriteBatch.Draw(fourButtonPressed, new Vector2(660, 324), Color.White);
                    break;
                case EditorState.Erase:
                    Editor.spriteBatch.Draw(deleteButtonPressed, new Vector2(660, 388), Color.White);
                    break;
            }



            Editor.spriteBatch.End();

            // This is debug information, fps and cursor position. Uncomment as needed.
            //Editor.DrawDisplay();

        }

        protected override void Initialize()
        {
            base.Initialize();

            Editor.BackgroundColor = Color.White;

            #region Initializing textures

            quarterNote = Editor.Content.Load<Texture2D>("blanknote");
            beatlineTexture = Editor.Content.Load<Texture2D>("beatline");
            textBackground = Editor.Content.Load<Texture2D>("textbackground");
            halfNote = Editor.Content.Load<Texture2D>("blankhalf");
            threeQuarterNote = Editor.Content.Load<Texture2D>("blankthreequarter");
            fullNote = Editor.Content.Load<Texture2D>("blankfull");

            oneButton = Editor.Content.Load<Texture2D>("1button");
            oneButtonPressed = Editor.Content.Load<Texture2D>("1buttonpressed");
            twoButton = Editor.Content.Load<Texture2D>("2button");
            twoButtonPressed = Editor.Content.Load<Texture2D>("2buttonpressed");
            threeButton = Editor.Content.Load<Texture2D>("3button");
            threeButtonPressed = Editor.Content.Load<Texture2D>("3buttonpressed");
            fourButton = Editor.Content.Load<Texture2D>("4button");
            fourButtonPressed = Editor.Content.Load<Texture2D>("4buttonpressed");
            deleteButton = Editor.Content.Load<Texture2D>("deletebutton");
            deleteButtonPressed = Editor.Content.Load<Texture2D>("deletebuttonpressed");
            
            #endregion
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
                    yOffset = 128;
                }

                if (songInstance.State == SoundState.Playing)
                {
                    // The math was never broken... literally everything else was. Nice.
                    // Discovered that everything needed to be casted to an float when calculating the number of rows.
                    // Int division caused it to ALWAYS be short which is what caused the issue. 
                    yOffset -= ((float)bpm/60f * 4f * 32f / 1000f) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (songInstance.State == SoundState.Stopped)
                    {
                        yOffset = 128;
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

            
            // Uncomment these to track the scrollwheelvalue and y offset while troubleshooting
            //Console.WriteLine("ScrollWheelValue: " + mouseState.ScrollWheelValue);

            //Console.WriteLine("yOffset: " + yOffset);

            
            // Left click detection hell.
            if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
            {
                currentMouseX = mouseState.X;
                currentMouseY = mouseState.Y;

                // Find which note its on top of, and change its state accordingly. Easier said than done. 
                if (currentMouseX > 99 && currentMouseX < 389 && currentMouseY > 99)
                {

                    // Encapsulate in a switch statement based on editor state.
                    // Detecting the column it is in. I'm pretty sure this can be done more easily.
                    // I wrote that when I was only kinda sure the following equation would work. It does. 9 if/else statements went to heaven today.
                    clickedCol = ((currentMouseX - 128) - (currentMouseX % 32)) / 32 + 1;
                    Console.WriteLine("Clicked Column: " + clickedCol);
                    clickedRow = ((currentMouseY - 128) - (currentMouseY % 32)) / 32 - (((int)yOffset - -1 * (int)yOffset % 32) / 32) + 4;
                    Console.WriteLine("Clicked Row: " + clickedRow);

                    switch (currentEditorState)
                    {
                        case EditorState.PlaceQuarter:
                            chartData[clickedRow, clickedCol].IsActive = true;
                            chartData[clickedRow, clickedCol].NoteType = NoteType.Quarter;
                            break;
                        case EditorState.PlaceHalf:
                            chartData[clickedRow, clickedCol].IsActive = true;
                            chartData[clickedRow, clickedCol].NoteType = NoteType.Half;
                            chartData[clickedRow + 1, clickedCol].NoteType = NoteType.Covered;
                            break;
                        case EditorState.PlaceThreeQuarter:
                            chartData[clickedRow, clickedCol].IsActive = true;
                            chartData[clickedRow, clickedCol].NoteType = NoteType.ThreeQuarter;
                            chartData[clickedRow + 1, clickedCol].NoteType = NoteType.Covered;
                            chartData[clickedRow + 2, clickedCol].NoteType = NoteType.Covered;
                            break;
                        case EditorState.PlaceFull:
                            chartData[clickedRow, clickedCol].IsActive = true;
                            chartData[clickedRow, clickedCol].NoteType = NoteType.Full;
                            chartData[clickedRow + 1, clickedCol].NoteType = NoteType.Covered;
                            chartData[clickedRow + 2, clickedCol].NoteType = NoteType.Covered;
                            chartData[clickedRow + 3, clickedCol].NoteType = NoteType.Covered;
                            break;
                        case EditorState.Erase:
                            chartData[clickedRow, clickedCol].IsActive = false;
                            chartData[clickedRow, clickedCol].NoteType = NoteType.None;
                            if (chartData[clickedRow, clickedCol].NoteType == NoteType.Half)
                            {
                                chartData[clickedRow + 1, clickedCol].NoteType = NoteType.None;
                            } else if (chartData[clickedRow, clickedCol].NoteType == NoteType.ThreeQuarter)
                            {
                                chartData[clickedRow + 1, clickedCol].NoteType = NoteType.None;
                                chartData[clickedRow + 2, clickedCol].NoteType = NoteType.None;
                            } else if (chartData[clickedRow, clickedCol].NoteType == NoteType.Full)
                            {
                                chartData[clickedRow + 1, clickedCol].NoteType = NoteType.None;
                                chartData[clickedRow + 2, clickedCol].NoteType = NoteType.None;
                                chartData[clickedRow + 3, clickedCol].NoteType = NoteType.None;
                            }
                            
                            
                            break;
                    }
                    
                    

                } else if (currentMouseX > 660) // buttons
                {
                    if (currentMouseY > 132 && currentMouseY < 196)
                    {
                        currentEditorState = EditorState.PlaceQuarter;
                    } else if (currentMouseY > 196 && currentMouseY < 260)
                    {
                        currentEditorState = EditorState.PlaceHalf;
                    } else if (currentMouseY > 260 && currentMouseY < 324)
                    {
                        currentEditorState = EditorState.PlaceThreeQuarter;
                    } else if (currentMouseY > 324 && currentMouseY < 388)
                    {
                        currentEditorState = EditorState.PlaceFull;
                    } else if (currentMouseY > 388 && currentMouseY < 452)
                    {
                        currentEditorState = EditorState.Erase;
                    }
                }
                /*
                new Vector2(660, 132), Color.White);
                Editor.spriteBatch.Draw(twoButton, new Vector2(660, 196), Color.White);
                Editor.spriteBatch.Draw(threeButton, new Vector2(660, 260), Color.White);
                Editor.spriteBatch.Draw(fourButton, new Vector2(660, 324), Color.White);
                Editor.spriteBatch.Draw(deleteButton, new Vector2(660, 388),
                */

            }

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

            infoString = "Name: " + name + " | Artist: " + artist + " | Album: " + album + " \nCharter: " + charter + " | BPM: " + bpm + " | Length (s): " + length;

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
                //return;
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

            currentEditorState = EditorState.PlaceQuarter;

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

            infoString = "Name: " + name + " | Artist: " + artist + " | Album: " + album + " \nCharter: " + charter + " | BPM: " + bpm + " | Length (s): " + length;
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

        public void Save(string _filePath, int _bpm, int _length)
        {
            string chartFilePath = filePath + @"\chart.taptchart";


            using (StreamWriter outputFile = new StreamWriter(chartFilePath, false))
            {
                outputFile.WriteLine(_bpm);
                outputFile.WriteLine(_length);
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
