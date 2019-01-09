using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupBoxRadioControl
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            List<RadioButton> rbList = new List<RadioButton>();

            rbList.Add(this.rb0);
            rbList.Add(this.rb1);
            rbList.Add(this.rb2);
            rbList.Add(this.rb3);
            rbList.Add(this.rb4);
            rbList.Add(this.rb5);
            rbList.Add(this.rb6);


        }

        public int CurrentSelection(RadioButton rb)
        {
        https://docs.microsoft.com/en-us/previous-versions/dotnet/articles/ms996431(v=msdn.10)
            int currentValue = 0;
            {
                if ( rb.Checked > 0 & Value <= )
                    radioButtons(Value - 1).Checked = true;
                rb = 5;
            }
        }
    }
}
