using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intelliJautoCompiler
{
    public partial class keysSelection : Form
    {
        public keysSelection()
        {
            InitializeComponent();
            Enum.GetNames(typeof(Keys)).ToList().ForEach(x => checkedListBox1.Items.Add(x));
        }

        public keysSelection(Keys[] k)
        {
            InitializeComponent();
            Enum.GetNames(typeof(Keys)).ToList().ForEach(x => checkedListBox1.Items.Add(x));
            k.Select(x => Enum.GetName(typeof(Keys), x)).Select(x => checkedListBox1.Items.IndexOf(x)).ToList().ForEach(x => checkedListBox1.SetItemChecked(x, true));
            this.Keys = k;
        }
        public Keys[] Keys { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Keys = checkedListBox1.CheckedItems.Cast<string>().Select(y => (Keys)Enum.Parse(typeof(Keys), y)).ToArray();
            this.DialogResult = DialogResult.OK;
        }
    }
}
