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
using Newtonsoft.Json;


namespace MoviesAIAgentApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string question = textBox1.Text;

            if( question == "" )
            {
                MessageBox.Show("Please type a question.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                var data = new
                {
                    question = question
                };

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/ask", content);
                    string answer = await response.Content.ReadAsStringAsync();
                    answer = answer.Substring(1, answer.Length - 3);
                    richTextBox1.Clear();
                    richTextBox1.Text = answer;
                }
                catch
                {
                    MessageBox.Show("Unable to obtain the response. History is probably full. Try deleting history and try again.");
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (HttpClient print_history_client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await print_history_client.GetAsync("http://127.0.0.1:5000/history");
                    string answer = await response.Content.ReadAsStringAsync();
                    richTextBox1.Clear();
                    richTextBox1.Text = answer;
                }
                catch
                {
                    MessageBox.Show("Error while attempting to print history");
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (HttpClient delete_history_client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await delete_history_client.DeleteAsync("http://127.0.0.1:5000/history");
                    richTextBox1.Clear();
                    MessageBox.Show("History deleted");
                }
                catch
                {
                    MessageBox.Show("Error while attempting to delete history");
                }
            }
        }
    }
}
