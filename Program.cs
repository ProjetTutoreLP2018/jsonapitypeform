using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    
    public class Settings
    {
        public bool is_public { get; set; }
        public bool is_trial { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Theme
    {
        public string href { get; set; }
    }

    public class Links
    {
        public string display { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime last_updated_at { get; set; }
        public Settings settings { get; set; }
        public Self self { get; set; }
        public Theme theme { get; set; }
        public Links _links { get; set; }
    }

    public class RootObject
    {
        public int total_items { get; set; }
        public int page_count { get; set; }
        public List<Item> items { get; set; }
    }








    class Program
    {
        async static Task req()
        {
            
            string url = "https://api.typeform.com/forms/uB6Jj8/responses";
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer BWGey6f4itiRXzCXk2MwrfKhtsEgNqLaM8ygNZR17dtj");
                    
                    var response = await client.GetAsync(url);
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    string outputJson = await responseString;
                Console.WriteLine("finis");
                var res = JsonConvert.DeserializeObject<RootObject>(outputJson);



                return;
            }
      
        }

        

        async static Task<RootObject> getForms()
        {

            string url = "https://api.typeform.com/forms";
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer BWGey6f4itiRXzCXk2MwrfKhtsEgNqLaM8ygNZR17dtj");

                var response = await client.GetAsync(url);
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string outputJson = await responseString;
                
                RootObject res = JsonConvert.DeserializeObject<RootObject>(outputJson);

                return res;
            }

        }


        async static Task<FormTypeForm.RootObject> getForm(string id_form)
        {

            string url = "https://api.typeform.com/forms/"+id_form;

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer BWGey6f4itiRXzCXk2MwrfKhtsEgNqLaM8ygNZR17dtj");

                var response = await client.GetAsync(url);
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string outputJson = await responseString;
                
                FormTypeForm.RootObject res = JsonConvert.DeserializeObject<FormTypeForm.RootObject>(outputJson);


                return res;
            }



        }


        async static Task<AnswerTypeForm.RootObject> getAnswers(string id_form)
        {

            string url = "https://api.typeform.com/forms/"+id_form+"/responses";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer BWGey6f4itiRXzCXk2MwrfKhtsEgNqLaM8ygNZR17dtj");

                var response = await client.GetAsync(url);
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string outputJson = await responseString;

                AnswerTypeForm.RootObject res = JsonConvert.DeserializeObject<AnswerTypeForm.RootObject>(outputJson);


                return res;
            }



        }



        static void Main(string[] args)
        {
           //RootObject json_forms = getForms().Result;


            FormTypeForm.RootObject json_form = getForm("uB6Jj8").Result;

            Console.WriteLine("Nom du formulaire: "+json_form.title);

            foreach (FormTypeForm.Field field in json_form.fields)
            {
                Console.WriteLine("Question: "+field.title);
            }


            AnswerTypeForm.RootObject json_answers = getAnswers("uB6Jj8").Result;
            //Console.WriteLine(json_answers.items[0].answers[0].choice.label);

            foreach (AnswerTypeForm.Item field in json_answers.items)
            {
                if(field.answers != null)
                {

                
                    foreach(AnswerTypeForm.Answer answer in field.answers)
                    {
                    
                        if(answer != null)
                        {
                            if (answer.choice != null)
                            {
                                Console.WriteLine("Réponse: " + answer.choice.label);

                            }

                            else if(answer.choices != null)
                            {
                                foreach(string choix in answer.choices.labels)
                                {
                                    Console.WriteLine("Réponses: " + choix);

                                }
                            }

                            if(answer.text != null)
                            {
                                Console.WriteLine("Réponse: " + answer.text);
                            }

                            if (answer.url != null)
                            {
                                Console.WriteLine("Réponse: " + answer.url);
                            }

                            if (answer.boolean != null)
                            {
                                Console.WriteLine("Réponse: " + answer.boolean);
                            }

                            if (answer.number != null)
                            {
                                Console.WriteLine("Réponse: " + answer.number);
                            }

                            if (answer.date != null)
                            {
                                Console.WriteLine("Réponse: " + answer.date);
                            }

                            if (answer.email != null)
                            {
                                Console.WriteLine("Réponse: " + answer.email);
                            }

                            if (answer.file_url != null)
                            {
                                Console.WriteLine("Réponse: " + answer.file_url);
                            }

                        }
                    
                    }
                }

            }

            Console.ReadKey();
            return;
        }
    }
}
