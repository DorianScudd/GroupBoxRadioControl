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
    public partial class GroupBoxRadioControl : UserControl
    {

        private int numberOfButtons = 0;
        private int currentValue = 1;
        private List<RadioButton> rbList = new List<RadioButton>();

        public event EventHandler CurrentSelectionChanged;

        public GroupBoxRadioControl()
        {
            InitializeComponent();
        }

        //https://docs.microsoft.com/en-us/previous-versions/dotnet/articles/ms996431(v=msdn.10)
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Bindable(true)]
        public int CurrentSelection
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (currentValue > 0 && currentValue <= numberOfButtons)
                {
                    rbList[currentValue - 1].Checked = true;
                }

            }
        }

        private string groupBoxHeader;

        public string GroupBoxHeader
        {
            get { return groupBoxHeader; }
            set
            {
                if (!string.IsNullOrEmpty(groupBoxHeader))
                {
                    groupBoxHeader = value;
                }
                else
                {
                    ; // do nothing
                }
                
            }
        }


        private void rb_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                int i = 0;
                bool buttonFound = false;
                while ((i < numberOfButtons) & !buttonFound)
                {
                    if (rbList[i].Checked)
                    {
                        currentValue = i + 1;
                        buttonFound = true;
                        CurrentSelectionChanged?.Invoke((object)this, e);
                    }
                    i += 1;
                }
            }
        }

        private void GroupBoxRadioControl_Load(object sender, EventArgs e)
        {
            rbList.Add(this.rb0);
            rbList.Add(this.rb1);
            rbList.Add(this.rb2);
            rbList.Add(this.rb3);
            rbList.Add(this.rb4);
            rbList.Add(this.rb5);
            rbList.Add(this.rb6);
            rbList.Add(this.rb7);

            numberOfButtons = rbList.Count();
        }

        //private void showMe_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MessageBox.Show(rbList[currentValue - 1].Text);
        //    }
        //    catch (IndexOutOfRangeException ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //        throw;
        //    }

        //}
    }
}