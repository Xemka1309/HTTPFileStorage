using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;

namespace file_storage_client
{
    public partial class ClienForm : Form
    {
        private String selectedfilename;
        private Boolean loggedin;
        private String[] identifer;
        private String uri;
        private Client client;
        public ClienForm()
        {
            InitializeComponent();
            loggedin = false;
            
        }
        public void CreateClient(String uri)
        {
            this.uri = uri;
            this.identifer = new String[2];
            this.identifer[0] = "log";
            this.identifer[1] = "pass";
            try
            {
                client = new Client(uri, identifer[0], identifer[1],"ANONIMUS");
            }
            catch
            {
                MessageBox.Show("no user data set");
            }
            

        }

        private void readFileGETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.CreateRequest();
            client.SetRequestMethod(HttpMethods.GET);
            client.SetRequestUri(selectedfilename);
            HttpResponseMessage responseMessage = client.SendRequest();
            HttpContent filecontent = responseMessage.Content;
            byte[] bytecontent = filecontent.ReadAsByteArrayAsync().Result;
            String strcontent = Encoding.UTF8.GetString(bytecontent);
            String[] stritems = strcontent.Split('\n');

            textBoxfilecontent.Clear();
            //listViewfilecontent.Items.Clear();
            for (int i = 0; i < stritems.Length; i++)
            {
                //listViewfilecontent.Items.Add(stritems[i]);
                textBoxfilecontent.AppendText(stritems[i]);
            }
            
        }

        private void ClienForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void addFilePUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String pass = openFileDialog1.FileName;
            String[] trimedstr = pass.Split('\\');
            MessageBox.Show(pass);
            try
            {
                client.CreateRequest();
                client.SetRequestMethod(HttpMethods.PUT);
                client.SetRequestUri(trimedstr[trimedstr.Length - 1]);
                HttpResponseMessage responseMessage = client.SendRequest(Encoding.UTF8.GetBytes(pass));
                //MessageBox.Show(responseMessage.Content.ReadAsStringAsync().Result);

            }
            catch
            {
                MessageBox.Show("Something wrong with server");
            }
            String str = String.Empty;
            try
            {
                str = client.GetFilesNames();
            }
            catch
            {
                MessageBox.Show("Server is not active");
            }

            List<String> filenames = new List<string>();
            listViewfiles.Items.Clear();
            String[] files = str.Split('/');
            for (int i = 0; i < files.Length; i++)
            {
                listViewfiles.Items.Add(files[i]);
            }

        }

        private void buttoncheckid_Click(object sender, EventArgs e)
        {
            try
            {
                CreateClient(textBoxuri.Text);
            }
            catch
            {
                MessageBox.Show("Invalid uri");
            }

            String str=String.Empty;
            try
            {
               str = client.GetFilesNames();
            }
            catch
            {
                MessageBox.Show("Server is not active");
            }
            
            List<String> filenames = new List<string>();
            listViewfiles.Items.Clear();
            String[] files = str.Split('/');
            for (int i = 0; i < files.Length; i++)
            {
                listViewfiles.Items.Add(files[i]);
            }
        }

        private void listViewfiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedfilename = e.Item.Text;
        }

        private void changeFilePOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.CreateRequest();
            client.SetRequestMethod(HttpMethods.POST);
            client.SetRequestUri(selectedfilename);
            HttpResponseMessage responseMessage = client.SendRequest(Encoding.UTF8.GetBytes(textBoxfilecontent.Text));
            MessageBox.Show(responseMessage.Content.ReadAsStringAsync().Result);

            /*String str = String.Empty;
            try
            {
                str = client.GetFilesNames();
            }
            catch
            {
                MessageBox.Show("Server is not active");
            }

            List<String> filenames = new List<string>();
            listViewfiles.Items.Clear();
            String[] files = str.Split('/');
            for (int i = 0; i < files.Length; i++)
            {
                listViewfiles.Items.Add(files[i]);
            }*/
        }

        private void deleteFileDELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                client.CreateRequest();
                client.SetRequestMethod(HttpMethods.DELETE);
                client.SetRequestUri(selectedfilename);
                MessageBox.Show(client.SendRequest().Content.ReadAsStringAsync().Result);

            }
            catch
            {
                MessageBox.Show("Server not answer");
            }
            String str = String.Empty;
            try
            {
                str = client.GetFilesNames();
            }
            catch
            {
                MessageBox.Show("Server is not active");
            }

            List<String> filenames = new List<string>();
            listViewfiles.Items.Clear();
            String[] files = str.Split('/');
            for (int i = 0; i < files.Length; i++)
            {
                listViewfiles.Items.Add(files[i]);
            }
        }

        private void copyFileCOPYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                client.CreateRequest();
                client.SetRequestMethod(HttpMethods.GET);
                client.SetRequestUri(selectedfilename);
                HttpResponseMessage responseMessage = client.SendRequest();
                HttpContent filecontent = responseMessage.Content;
                byte[] bytecontent = filecontent.ReadAsByteArrayAsync().Result;
                saveFileDialog1.ShowDialog();
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Create);
                fs.Write(bytecontent, 0, bytecontent.Length);
                MessageBox.Show("File sucseccfully copyed to your computer");
            }
            catch
            {
                MessageBox.Show("Server not answer");
            }
            
        }
    }
}
