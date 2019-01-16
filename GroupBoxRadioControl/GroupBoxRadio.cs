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
        //private string groupBoxHeader;
        private List<RadioButton> rbList = new List<RadioButton>();

        public event EventHandler CurrentSelectionChanged;
        public event EventHandler SelectOperator_Click;

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

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [System.ComponentModel.Category("Appearance")]
        public override string Text //string GroupBoxHeader
        {
            get { return groupBox1.Text; }
            set
            {
                if (!string.IsNullOrEmpty(groupBox1.Text))
                {
                    groupBox1.Text = value;
                }
                else
                {
                    groupBox1.Text = "Undefined"; // do nothing
                }
            }
        }

        private string selectedOperator;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [System.ComponentModel.Category("Appearance")]
        public string SelectedOperator
        {
            get { return selectedOperator; }
            set { selectedOperator = value; }
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

        private void btnSelectOperator_Click(object sender, EventArgs e)
        {
            txtOperator.Text = selectedOperator;
            if(string.IsNullOrEmpty(txtOperator.Text))
            {
                selectedOperator = txtOperator.Text;
                SelectOperator_Click?.Invoke((object)this, e);
            }
        }
    }
}