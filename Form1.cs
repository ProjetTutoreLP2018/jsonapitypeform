using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

namespace lot1api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //nomEntreprise.Text = info.getNom();


        }

        private void bValide_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                typeFormApi.json_answers = getAnswers(typeFormApi.id_form);
                InfoEntreprise info = typeFormApi.getInfos("5f1ccad09db138f184034ce06ba87f74");
                nomEntreprise.Text = info.getNom();
                loc.Text = info.getPerimetre();
                Dep.Text = info.getPerimetre(); });

            Thread demoThread =
         new Thread(new ThreadStart(this.ThreadProcUnsafe));

            demoThread.Start();
            //  Console.WriteLine(nomEntreprise.Text);



        }
        private void ThreadProcUnsafe()
        {
            
            this.nomEntreprise.Text = "This text was set unsafely.";
        }
        public static AnswerTypeForm.RootObject getAnswers(string id_form)
        {


            string url = "https://api.typeform.com/forms/" + id_form + "/responses";


            string outputJson = getJson(url).Result;
            AnswerTypeForm.RootObject res = JsonConvert.DeserializeObject<AnswerTypeForm.RootObject>(outputJson);
            return res;

        }
        public async static Task<string> getJson(string url)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer " + "C4yr7FzMfPjiXd6QRMt1ypPT1tUWMbYvk4UQgxdAnrmL");

                var response = await client.GetAsync(url);
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string outputJson = await responseString;
                return outputJson;
            }
        }

    }
}
