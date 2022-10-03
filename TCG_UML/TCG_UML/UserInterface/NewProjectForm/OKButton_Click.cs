using System;
using System.IO;
using System.Windows.Forms;

namespace TCG_UML
{
    public partial class NewProjectForm
    {
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text != String.Empty)
            {
                NameTextBox.Enabled = false;
                LocationTextBox.Enabled = false;
                if (Directory.Exists(LocationTextBox.Text + NameTextBox.Text))
                {
                    Console.WriteLine("That project exists already.");
                    NameTextBox.Enabled = true;
                    LocationTextBox.Enabled = true;
                }
                else
                {
                    newProject.directory = LocationTextBox.Text + NameTextBox.Text;

                    DirectoryInfo di = Directory.CreateDirectory(newProject.directory);

                    newProject.SetName(NameTextBox.Text);

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Set a NAME to the project...");
            }
        }
    }
}
