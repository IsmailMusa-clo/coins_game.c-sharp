using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coinsGame
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }
        bool goLeft, goRight, goDown, goUp, GameOver;
        int score = 0;
       int playerSpeed=12;
        int enemy1Speed = 7;
        int enemy2Speed = 7;
        int enemy3Speed = 10;
        int enemy4Speed = 7;

        private void GameRun_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score : " + score;
            if (goLeft==true)
            {
                player.Left -= playerSpeed;
                player.Image = coinsGame.Properties.Resources.left;
            }
            if (goRight== true)
            {
                player.Left += playerSpeed;
                player.Image = coinsGame.Properties.Resources.right;
            }
            if (goUp==true)
            {
                player.Top -= playerSpeed;
                player.Image = coinsGame.Properties.Resources.Up;
            }
            if (goDown== true)
            {
                player.Top += playerSpeed;
                player.Image = coinsGame.Properties.Resources.down;
            }
            if (score == 37) 
            { lblGameOver.Text = "Your Win"; lblGameOver.Visible = true; GameRun.Stop(); }
            if (player.Left > this.ClientSize.Width)
            {
               
                player.Left = -player.Width;
               
            }
            if (player.Left <-player.Width)
            {

                player.Left = this.ClientSize.Width ;

            }
            if (player.Top > this.ClientSize.Height-player.Height)
            {
                player.Top = this.ClientSize.Height-player.Height;
            }
            if (player.Top <0)
            {
                player.Top = 0;
            }
            enemyRed.Left+=enemy3Speed;
            enemyRed.Top+=enemy3Speed;
            if (enemyRed.Top > this.ClientSize.Height - enemyRed.Height)
            { 
                enemy3Speed =- enemy3Speed;
            }
            if (enemyRed.Top < 0)
            {
                enemy3Speed = - enemy3Speed;
            }
            if (enemyRed.Left > this.ClientSize.Width-enemyRed.Width)
            {
                enemyRed.Left -=enemy3Speed ;
            }
            if (enemyRed.Left<0)
            {
                enemyRed.Left = 0;
            }
            
           

                foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    if ((String)item.Tag=="coin")
                    {
                        if (player.Bounds.IntersectsWith(item.Bounds)&&item.Visible==true)
                        {
                            score++;
                            item.Visible = false;
                        }
                    }
                    if ((String)item.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(item.Bounds))
                        {
                            GameOver = true;
                            GameRun.Stop();
                            lblGameOver.Visible = true;
                        }
                       
                    }
                    if ((String)item.Tag=="Wall")
                    {
                        if (player.Bounds.IntersectsWith(item.Bounds))
                        {
                           if(player.Left<item.Left) player.Left = item.Left-player.Width;
                           if(player.Left>item.Left) player.Left = item.Left +player.Width;

                        }
                        
                        if (enemyRed.Bounds.IntersectsWith(item.Bounds))
                        {
                            if (enemyRed.Left < item.Left) enemyRed.Left = item.Left - enemyRed.Width;
                            if (enemyRed.Left > item.Left) enemyRed.Left = item.Left + enemyRed.Width;

                        }
                    }
                    
                }
            }
            
            enemyPInk.Left -= enemy1Speed;
            if (enemyPInk.Left < wall1.Left+wall1.Width||enemyPInk.Left>wall2.Left-wall2.Width-10)
            {
                enemy1Speed = -enemy1Speed;
            }
            
            enemyYellwo.Left -= enemy2Speed;
            if (enemyYellwo.Left < wall3.Left + wall3.Width || enemyYellwo.Left > wall4.Left - wall4.Width - 10)
            {
                enemy2Speed = -enemy2Speed;
            }
            enemyRed1.Top-= enemy4Speed;
            if (enemyRed1.Top > this.ClientSize.Height-enemyRed1.Height || enemyRed1.Top < 0)
            {
                enemy4Speed = -enemy4Speed;
            }


        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode==Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode==Keys.Space&&GameOver==true)
            {
                restart();
            }
        }
        private void game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
        private void restart()
        {
            foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    if ((String)item.Tag == "coin")
                    {
                        item.Visible = true;

                    }
                }
            }
                    player.Left = 47;
            player.Top = 94;
            enemyPInk.Left = 330;
            enemyYellwo.Left = 292;
            enemyRed.Left = 233;
            enemyRed.Top = 239;
            score = 0;
            lblScore.Text= "Score : " +score;
            GameOver = false;
            lblGameOver.Visible = false;
            GameRun.Start();
        }
    }
}
