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
        class Program
        {
            static string token = "C4yr7FzMfPjiXd6QRMt1ypPT1tUWMbYvk4UQgxdAnrmL";
            static string id_form = "YuE8Lp";




           static FormTypeForm.RootObject getForms()
            {

                string url = "https://api.typeform.com/forms";
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer " + token);

                    string outputJson = getJson(url).Result;

                    FormTypeForm.RootObject res = JsonConvert.DeserializeObject<FormTypeForm.RootObject>(outputJson);

                    return res;
                }

            }


            static FormTypeForm.RootObject getForm(string id_form)
            {

                string url = "https://api.typeform.com/forms/" + id_form;
                string outputJson = getJson(url).Result;

                FormTypeForm.RootObject res = JsonConvert.DeserializeObject<FormTypeForm.RootObject>(outputJson);


                return res;
            }


            static AnswerTypeForm.RootObject getAnswers(string id_form)
            {

                string url = "https://api.typeform.com/forms/" + id_form + "/responses";


                string outputJson = getJson(url).Result;
                AnswerTypeForm.RootObject res = JsonConvert.DeserializeObject<AnswerTypeForm.RootObject>(outputJson);
                return res;
                
            }

            async static Task<string> getJson(string url)
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer " + token);

                    var response = await client.GetAsync(url);
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    string outputJson = await responseString;
                    return outputJson;
                }
            }

            static void Main(string[] args)
            {
                //RootObject json_forms = getForms().Result;


                FormTypeForm.RootObject json_form = getForm(id_form);

                Console.WriteLine("Nom du formulaire: " + json_form.title);

                foreach (FormTypeForm.Field field in json_form.fields)
                {
                    Console.WriteLine("Titre question: " + field.title);

                    if (field.properties != null && field.properties.fields != null)
                    {
                        foreach (FormTypeForm.Field sous_question in field.properties.fields)
                        {
                            Console.WriteLine("Question: " + sous_question.title);
                        }
                    }


                }

                Console.WriteLine("");

                AnswerTypeForm.RootObject json_answers = getAnswers(id_form);
                //Console.WriteLine(json_answers.items[0].answers[0].choice.label);
                if (json_answers.items != null)
                {



                    foreach (AnswerTypeForm.Item field in json_answers.items)
                    {
                        if (field.answers != null)
                        {


                            foreach (AnswerTypeForm.Answer answer in field.answers)
                            {

                                if (answer != null)
                                {
                                    if (answer.choice != null)
                                    {
                                        Console.WriteLine("Réponse: " + answer.choice.label);

                                    }

                                    else if (answer.choices != null)
                                    {
                                        foreach (string choix in answer.choices.labels)
                                        {
                                            Console.WriteLine("Réponses: " + choix);

                                        }
                                    }

                                    if (answer.text != null)
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
                else
                {
                    Console.WriteLine("Pas de réponses");


                }
                Console.ReadKey();
            }
        }
    }
}