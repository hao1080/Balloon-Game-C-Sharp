namespace _1131735
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int t1 = 60, t2 = 60 , p = 0, z;   //t1、t2表示時間；p表示分數；z是timer2_Tick中的變數
        bool[] bc = new bool[] { false, false, false, false, false, false, false, false };   //八個值分別代表八顆氣球是否被點擊的判斷
        int[] r = new int[8];   //八個值分別代表八顆氣球是否開始飄的依據；將隨機填入數字，如果r[i]==0，氣球會開始飄，可以做出氣球漂浮的隨機性
        int[] n = new int[8];   //八個值分別代表八顆氣球若被點擊，顯示到爆掉特效(imageList3,imageList4)的哪一張圖
        Random rp = new Random();

        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; 
            timer1.Enabled = false;
            timer2.Interval = 100;
            timer2.Enabled = false;
            button2.Enabled = false;
            this.BackColor = Color.White;

            //以下八行表示圖片一開始在視窗下方
            pictureBox1.Top = this.Height;
            pictureBox2.Top = this.Height;
            pictureBox3.Top = this.Height;
            pictureBox4.Top = this.Height;
            pictureBox5.Top = this.Height;
            pictureBox6.Top = this.Height;
            pictureBox7.Top = this.Height;
            pictureBox8.Top = this.Height;

            //一開始就跳出遊戲規則的視窗
            MessageBox.Show("遊戲開始前，可以利用畫面右方的設置，修改時間及遊戲難度。\n開始後 : \n點擊藍色氣球 → 加 1 分。\n點擊紅色氣球 → 扣 1 分。\n藍色氣球飛出畫面未點擊 → 扣 1 分。\n可隨時點擊「停止」中止遊戲。\n祝你好運!!!", "規則說明", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        //若numericUpDown的值改變，右上的時間也會改變
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)  
        {
            t1 = Convert.ToInt32(numericUpDown1.Value);
            t2 = t1;
            label1.Text = $"{t1}秒";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;

            //以下六行關閉設置區和開始鍵，打開停止鍵
            numericUpDown1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;

            //隨機從15個數字選一個放入r[i]；在後面的程式碼，如果r[i]==0，氣球會開始飄，可以做出氣球漂浮的隨機性
            for (int i = 0; i < 8; i++)
            {
                r[i] = rp.Next(15);
            }

        }

        //如果按下停止鍵，全部都變回原樣，並跳出遊戲停止的提醒視窗
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            t2 = t1;
            label1.Text = $"{t1}秒";
            p = 0;
            label4.Text = $"{p}";
            numericUpDown1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            pictureBox1.Top = this.Height;
            pictureBox2.Top = this.Height;
            pictureBox3.Top = this.Height;
            pictureBox4.Top = this.Height;
            pictureBox5.Top = this.Height;
            pictureBox6.Top = this.Height;
            pictureBox7.Top = this.Height;
            pictureBox8.Top = this.Height;
            MessageBox.Show("遊戲已暫停", "停止!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        //按下button3，顯示遊戲規則
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("遊戲開始前，可以利用畫面右方的設置，修改時間及遊戲難度。\n開始後 : \n點擊藍色氣球 → 加 1 分。\n點擊紅色氣球 → 扣 1 分。\n藍色氣球飛出畫面未點擊 → 扣 1 分。\n可隨時點擊「停止」中止遊戲。\n祝你好運!!!", "規則說明", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //以下兩行t2會每秒減一，並顯示在視窗右上角的時間，做出倒數計時的效果
            t2--;
            label1.Text = $"{t2}秒";

            //如果時間歸零，全部都回覆原狀，並且跳出遊戲結束得提醒視窗
            if (t2 == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                label1.Text = $"{t1}秒";
                t2 = t1;
                pictureBox1.Top = this.Height;
                pictureBox2.Top = this.Height;
                pictureBox3.Top = this.Height;
                pictureBox4.Top = this.Height;
                pictureBox5.Top = this.Height;
                pictureBox6.Top = this.Height;
                pictureBox7.Top = this.Height;
                pictureBox8.Top = this.Height;
                label4.Text = $"{p}";
                numericUpDown1.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                MessageBox.Show($"時間到!!!\n恭喜你得到了{p}分", "遊戲結束!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                p = 0;
            }
        }

        private void clickpicturebox(int y)
        {
            bc[y] = true;//若點擊照片，bc[y]會變成true，在後面程式碼，bc是作為是否要顯示動畫...的依據
            if (y < 5)
                p++;//若是藍色氣球，分數上升
            else
                p--;//若是紅色氣球，分數上升
            label4.Text = $"{p}";
        }

        //從pictureBox1_Click~pictureBox8_Click，表示若照片被點擊，執行clickpicturebox函式
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickpicturebox(0);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clickpicturebox(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clickpicturebox(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            clickpicturebox(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            clickpicturebox(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            clickpicturebox(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            clickpicturebox(6);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            clickpicturebox(7);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int i = 0;
            //以下三行為氣球圖片的輪換，每0.1秒換一張，總共15張；z表示為imageList1,imageList2的第z張照片
            z++;
            if (z > 15)   
                z = 0;

            //氣球1
            if (bc[i] == false)  //與129行呼應，bc[i]等於false，表示沒有被點擊
            {
                pictureBox1.Image = imageList1.Images[z];//因沒被點擊，從imageList1中換下一張照片

                //呼應57行的隨機取數，有1/15的機率r[i]等於0；若等於零，氣球開始向上飄
                if (r[i] == 0)  
                {
                    //以下12行表示不同難度，氣球有不同的移動速度
                    if (radioButton1.Checked == true)
                    {
                        pictureBox1.Top -= 20;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox1.Top -= 30;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox1.Top -= 40;
                    }
                }
                // 14/15的機率r[i]不等於0；若不等於零，r[i]重新取數
                else
                {
                      r[i] = rp.Next(15);
                }

                //如果氣球飄到視窗最高都沒被點到，氣球回到視窗下，r[i]重新取數，總分減一
                if (pictureBox1.Top <= -315)  
                {
                    pictureBox1.Top = this.Height;
                    r[i] = rp.Next(15);
                    p--;
                    label4.Text = $"{p}";
                }
            }
            else  //與129行呼應，bc[i]等於true，表示被點擊
            {
                pictureBox1.Image = imageList3.Images[n[i]];//因被點擊，循環一次爆掉特效(imageList3)的圖片
                n[i]++;
                if (n[i] == 9)   //循環完imageList3的圖片後，氣球被隱藏到視窗下
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox1.Top = this.Height;
                }
            }
            i++;

            // 以下氣球2~5皆與氣球1僅有氣球移動速度有些許不同，而6~8僅有圖片、分數計算少許不同，因此省略解釋

            //氣球2
            if (bc[i] == false)
            {
                pictureBox2.Image = imageList1.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox2.Top -= 30;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox2.Top -= 40;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox2.Top -= 50;
                    }
                }
                else
                {
                    r[i] = rp.Next(15);
                }
                if (pictureBox2.Top <= -315)
                {
                    pictureBox2.Top = this.Height;
                    r[i] = rp.Next(15);
                    p--;
                    label4.Text = $"{p}";
                }
            }
            else
            {
                pictureBox2.Image = imageList3.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox2.Top = this.Height;
                }
            }
            i++;
            //氣球3
            if (bc[i] == false)
            {
                pictureBox3.Image = imageList1.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox3.Top -= 20;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox3.Top -= 30;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox3.Top -= 40;
                    }
                }
                else
                {
                    r[i] = rp.Next(15);
                }
                if (pictureBox3.Top <= -315)
                {
                    pictureBox3.Top = this.Height;
                    r[i] = rp.Next(15);
                    p--;
                    label4.Text = $"{p}";
                }
            }
            else
            {
                pictureBox3.Image = imageList3.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox3.Top = this.Height;
                }
            }
            i++;
            //氣球4
            if (bc[i] == false)
            {
                pictureBox4.Image = imageList1.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox4.Top -= 25;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox4.Top -= 35;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox4.Top -= 45;
                    }
                }
                else
                {
                    r[i] = rp.Next(15);
                }
                if (pictureBox4.Top <= -315)
                {
                    pictureBox4.Top = this.Height;
                    r[i] = rp.Next(15);
                    p--;
                    label4.Text = $"{p}";
                }
            }
            else
            {
                pictureBox4.Image = imageList3.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox4.Top = this.Height;
                }
            }
            i++;
            //氣球5
            if (bc[i] == false)
            {
                pictureBox5.Image = imageList1.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox5.Top -= 23;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox5.Top -= 33;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox5.Top -= 43;
                    }
                }
                else
                {
                    r[i] = rp.Next(15);
                }
                if (pictureBox5.Top <= -315)
                {
                    pictureBox5.Top = this.Height;
                    r[i] = rp.Next(15);
                    p--;
                    label4.Text = $"{p}";
                }
            }
            else
            {
                pictureBox5.Image = imageList3.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox5.Top = this.Height;
                }
            }
            i++;
            //氣球6
            if (bc[i] == false)
            {
                pictureBox6.Image = imageList2.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox6.Top -= 30;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox6.Top -= 40;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox6.Top -= 50;
                    }
                }
                else
                {
                    r[i] = rp.Next(4);
                }
                if (pictureBox6.Top <= -315)
                {
                    pictureBox6.Top = this.Height;
                    r[i] = rp.Next(4);
                }
            }
            else
            {
                pictureBox6.Image = imageList4.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox6.Top = this.Height;
                }
            }
            i++;
            //氣球7
            if (bc[i] == false)
            {
                pictureBox7.Image = imageList2.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox7.Top -= 20;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox7.Top -= 30;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox7.Top -= 40;
                    }
                }
                else
                {
                    r[i] = rp.Next(4);
                }
                if (pictureBox7.Top <= -315)
                {
                    pictureBox7.Top = this.Height;
                    r[i] = rp.Next(4);
                }
            }
            else
            {
                pictureBox7.Image = imageList4.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox7.Top = this.Height;
                }
            }
            i++;
            //氣球8
            if (bc[i] == false)
            {
                pictureBox8.Image = imageList2.Images[z];
                if (r[i] == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        pictureBox8.Top -= 25;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        pictureBox8.Top -= 35;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        pictureBox8.Top -= 45;
                    }
                }
                else
                {
                    r[i] = rp.Next(4);
                }
                if (pictureBox8.Top <= -315)
                {
                    pictureBox8.Top = this.Height;
                    r[i] = rp.Next(4);
                }
            }
            else
            {
                pictureBox8.Image = imageList4.Images[n[i]];
                n[i]++;
                if (n[i] == 9)
                {
                    bc[i] = false;
                    n[i] = 0;
                    pictureBox8.Top = this.Height;
                }
            }
        }

    
        
        
    }
}
