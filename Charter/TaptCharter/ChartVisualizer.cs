using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaptCharter
{
    class ChartVisualizer : MonoGame.Forms.Controls.MonoGameControl
    {
        int bpm;
        string name;
        string artist;
        string album;
        string filePath;

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
            base.Update(gameTime);
        }


        public void Load(string filePath)
        {

        }
    }
}
