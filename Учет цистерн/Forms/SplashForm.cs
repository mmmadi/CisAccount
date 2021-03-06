﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учет_цистерн.Forms
{
    public partial class SplashForm : Form
    {
        #region FIELDS
        Timer timer = new Timer();
        bool fadeIn = true;
        bool fadeOut = true;
        #endregion

        #region METHOD
        public SplashForm()
        {
            InitializeComponent();
            ExtraFormSettings();
            SetAndStartTimer();
        }

        private void SetAndStartTimer()
        {
            timer.Interval = 10;
            timer.Tick += new EventHandler(t_Tick);
            timer.Start();
        }

        private void ExtraFormSettings()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.0;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            //this.BackgroundImage = Properties.Resources.PLMIcon;
        }
        #endregion

        #region Events
        private void t_Tick(object sender, EventArgs e)
        {
            if (fadeIn)
            {
                if(Opacity < 1.0)
                {
                    this.Opacity += 0.02;
                }
                else
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }
            else if (fadeOut)
            {
                if(this.Opacity > 0)
                {
                    this.Opacity -= 0.02;
                }
                else
                {
                    fadeOut = false;
                }
            }

            if(!(fadeIn || fadeOut))
            {
                timer.Stop();
                this.Close();
            }
        }
        #endregion
    }
}
