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
            static string id_nom = "KA17sOqFVIRs";
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

            static void getQuestions()
            {
                FormTypeForm.RootObject json_form = getForm(id_form);
                foreach (FormTypeForm.Field field in json_form.fields)
                {
                    if (field.properties != null && field.properties.fields != null)
                    {
                        foreach (FormTypeForm.Field sous_question in field.properties.fields)
                        {
                            Console.WriteLine("Question: " + sous_question.id +" " +sous_question.title);
                           

                        }
                    }
                }
                  
            }

            static void getNomEntreprises(string id_question)
            {
                AnswerTypeForm.RootObject json_answers = getAnswers(id_form);


                foreach (AnswerTypeForm.Item field in json_answers.items)
                {
                    if (field.answers != null)
                    {


                        foreach (AnswerTypeForm.Answer answer in field.answers)
                        {
                            if(answer.field.id == id_question)
                            {
                                if (answer.text != null)
                                {
                                    Console.WriteLine("Nom de l' entreprise: " + answer.text+ "landing_id: "+field.landing_id);
                                }
                            }
                            
                        }
                    }
                }
                    
            }

            static string getInfoEntreprise(string landing_id, string id_question)
            {
                AnswerTypeForm.RootObject json_answers = getAnswers(id_form);
                foreach (AnswerTypeForm.Item field in json_answers.items)
                {
                    if (field.answers != null)
                    {

                        foreach (AnswerTypeForm.Answer answer in field.answers)
                        {
                            
                            if (landing_id == field.landing_id && id_question == answer.field.id)
                            {
                                if (answer.text != null)
                                {
                                    Console.WriteLine(answer.text+ "  " + answer.field.id);
                                    return answer.text;
                                }
                            }

                        }
                    }
                }
                return "";
            }


            public static void getInfos(string landing_id)
            {
                ConsoleApp1.InfoEntreprise info_entreprise = new ConsoleApp1.InfoEntreprise();

                info_entreprise.setNom(getInfoEntreprise(landing_id, id_nom));
                Console.WriteLine(info_entreprise.getNom());

                //info_entreprise.setNom(getInfoEntreprise(landing_id, ""));

            }
       

            
        static void getEntreprisesRep() {
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
                                        Console.WriteLine("Réponse: " + answer.text + " id item: " + field.landing_id);
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
                  
                }
                else
                {
                    Console.WriteLine("Pas de réponses");


                }


                
                


            }  
                
                
                
                
                

            /*static string rechercher_entreprise(string nom)
            {

            }*/


            static void Main(string[] args)
            {
                //RootObject json_forms = getForms().Result;


                FormTypeForm.RootObject json_form = getForm(id_form);
                //   getNomEntreprises(json_form, "");
                //getEntreprisesRep();
                //getInfoEntreprise("5f1ccad09db138f184034ce06ba87f74", "KA17sOqFVIRs");
                //getQuestions();
                getInfos("5f1ccad09db138f184034ce06ba87f74");
                //getQuestions();
                //getNomEntreprises("KA17sOqFVIRs");
                Console.ReadKey();
            }
        }
    }
}