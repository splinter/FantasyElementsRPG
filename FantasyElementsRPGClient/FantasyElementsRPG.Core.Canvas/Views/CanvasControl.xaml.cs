using FantasyElementsRPG.Core.GameLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FantasyElementsRPG.Core.Canvas.Views
{
    public partial class CanvasControl : UserControl
    {
        #region Global Variables
        private KeyHandler keyHandler;
        private GameLoop.GameLoop gameLoop;
        #endregion

        public CanvasControl()
        {
            InitializeComponent();

            keyHandler = new KeyHandler(this);
            gameLoop = new GameLoop.GameLoop(this);
            gameLoop.Update += new GameLoop.GameLoop.UpdateHandler(gameLoop_Update);

            gameLoop.Start();
        }

        void gameLoop_Update(TimeSpan elapsed)
        {
            //clear the current Vector so the sprite is not moving unless a keys is pressed
            
            if (keyHandler.IsKeyPressed(Key.Left))
            {
                
            }
            
        }
    }
}
