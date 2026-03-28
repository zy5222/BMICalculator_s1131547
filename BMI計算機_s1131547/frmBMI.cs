using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機_s1131547
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            double height = double.Parse(txtHeight.Text) / 100;
            double weight = double.Parse(txtWeight.Text);
            double bmi = weight / (height * height);

            lblResult.Text = $"{bmi:F2}";

            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = {
            Color.FromArgb(123, 139, 111), // 體重過輕 - 灰綠色
            Color.FromArgb(152, 175, 120), // 健康體位 - 灰豆綠
            Color.FromArgb(202, 185, 135), // 體位過重 - 暖灰黃 
            Color.FromArgb(193, 154, 107), // 輕度肥胖 - 駝色 
            Color.FromArgb(178, 102, 89),  // 中度肥胖 - 煙燻玫瑰
            Color.FromArgb(121, 85, 72)    // 重度肥胖 - 灰褐色
            };
        
            string strResult = "";
            Color colorResult = Color.Black;
            int resultIndex = 0;
            if (bmi < 18.5)
            {
                resultIndex = 0;
            }
            else if (bmi < 24)
            {
                resultIndex = 1;
            }
            else if (bmi < 27)
            {
                resultIndex = 2;
            }
            else if (bmi < 30)
            {
                resultIndex = 3;
            }
            else if (bmi < 35)
            {
                resultIndex = 4;
            }
            else
            {
                resultIndex = 5;
            }
            strResult = strResultList[resultIndex];
            colorResult = colorList[resultIndex];

            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.ForeColor = colorResult;

            string historyItem = $"身高:{txtHeight.Text} 體重:{txtWeight.Text} BMI:{bmi:F2} ({strResult})";

            lstHistory.Items.Add(historyItem);
            lstHistory.TopIndex = lstHistory.Items.Count - 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Clear();
            txtWeight.Clear();

            lblResult.Text = "";

            lblResult.ForeColor = Color.Black;
            txtHeight.Focus();
        }
    }
}
