using System;
using System.Configuration;
using System.Windows.Forms;
using MyGame.Enums;
using MyGame.Forms;

namespace MyGame.Game
{
    public sealed class Setting
    {
        private static Setting instance;
        private static readonly object padlock = new object();
        private Difficulty difficulty;
        private Shape shape;

        private Setting()
        {
        }

        public static Setting Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance ?? (instance = new Setting());
                }
            }
        }
    }
}