using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCG_UML
{
    public partial class TreeProjectViewForm : Form
    {
        public TreeProjectViewForm()
        {
            InitializeComponent();
        }

        public TreeView GetProjectTree()
        {
            return ProjectTree;
        }
    }
}
