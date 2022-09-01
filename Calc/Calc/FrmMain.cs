using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class FrmMain : Form
    {
        //定义操作数和结果
        string firstValue, secondValue, result;
        char operation;
        //存储上次点击了什么按钮，0代表什么都没点击，1代表了数字按钮
        private int lastButtonStatus = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnVaL_Click(object sender, EventArgs e)
         {
             Button btn = (Button)sender;
             if (lastButtonStatus == 0 || textBox_show.Text == "0")
             {
                 textBox_show.Text = btn.Text;
             }
             else
             {
                 textBox_show.Text += btn.Text;
             }
             lastButtonStatus = 1;
         }



        #region 将数字按钮的事件集中处理
        /// <summary>
        /// 将数字按钮的事件集中处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.textBox_show.Text = "0";
            this.textBox_top.Text = "0";
            btn_0.Click += new EventHandler(btnVaL_Click);
            btn_1.Click += new EventHandler(btnVaL_Click);
            btn_2.Click += new EventHandler(btnVaL_Click);
            btn_3.Click += new EventHandler(btnVaL_Click);
            btn_4.Click += new EventHandler(btnVaL_Click);
            btn_5.Click += new EventHandler(btnVaL_Click);
            btn_6.Click += new EventHandler(btnVaL_Click);
            btn_7.Click += new EventHandler(btnVaL_Click);
            btn_8.Click += new EventHandler(btnVaL_Click);
            btn_9.Click += new EventHandler(btnVaL_Click);
            btn_point.Click += new EventHandler(btnVaL_Click);
        } 
        #endregion

        #region 加
        /// <summary>
        /// 加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            operation = '+';
            textBox_top.Text = firstValue + '+';
            textBox_show.Text = string.Empty;
        } 
        #endregion

        #region 减
        /// <summary>
        /// 减
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sub_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            operation = '-';
            textBox_top.Text = firstValue + '-';
            textBox_show.Text = string.Empty;
        } 
        #endregion

        #region 求余
        /// <summary>
        /// 求余
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remain_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            operation = '%';
            textBox_top.Text = firstValue + '%';
            textBox_show.Text = string.Empty;
        } 
        #endregion

        #region 求平方和
        /// <summary>
        /// 求平方和
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_square_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            textBox_top.Text = firstValue + "的平方是：";
            double outFirst;
            double.TryParse(firstValue, out outFirst);
            textBox_show.Text = (outFirst * outFirst).ToString();
        } 
        #endregion

        #region 乘
        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mult_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            operation = '*';
            textBox_top.Text = firstValue + '*';
            textBox_show.Text = string.Empty;
        }
        #endregion

        #region 除
        /// <summary>
        /// 除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_div_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            operation = '/';
            textBox_top.Text = firstValue + '/';
            textBox_show.Text = string.Empty;
        }
        #endregion

        #region 求平方根
        /// <summary>
        /// 求平方根
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_involution_Click(object sender, EventArgs e)
        {
            firstValue = textBox_show.Text;
            textBox_top.Text = firstValue + "的平方根是：";
            double outFirst;
            double.TryParse(firstValue, out outFirst);
            textBox_show.Text = (Math.Sqrt(outFirst)).ToString();
        } 
        #endregion

        #region 等于
        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_equal_Click(object sender, EventArgs e)
        {
            secondValue = textBox_show.Text;
            textBox_top.Text += secondValue + '=';
            double outFirst, outSecond;
            double.TryParse(firstValue, out outFirst);
            double.TryParse(secondValue, out outSecond);
            switch (operation)
            {
                case '+':
                    result = (outFirst + outSecond).ToString();
                    break;
                case '-':
                    result = (outFirst - outSecond).ToString();
                    break;
                case '*':
                    result = (outFirst * outSecond).ToString();
                    break;
                case '/':
                    if (outSecond != 0)
                    {
                        result = (outFirst / outSecond).ToString();
                    }
                    else
                    {
                        MessageBox.Show("被除数不能为0");
                    }
                    break;
                case '%':
                    result = (outFirst % outSecond).ToString();
                    break;
            }
            textBox_show.Text = result;
        }
        #endregion

        #region 退格
        /// <summary>
        /// 退格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnback_Click(object sender, EventArgs e)
        {
            if (textBox_show.Text.Length > 0)
            {
                textBox_show.Text = textBox_show.Text.Substring(0, textBox_show.Text.Length - 1);
            }
        }
        #endregion

        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclear_Click(object sender, EventArgs e)
        {
            textBox_top.Text = string.Empty;
            textBox_show.Text = string.Empty;
            firstValue = string.Empty;
            secondValue = string.Empty;
        } 
        #endregion
    }
}
