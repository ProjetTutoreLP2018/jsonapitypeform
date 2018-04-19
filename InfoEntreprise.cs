using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class InfoEntreprise
    {
        private string landing_id;
        private string nom;

        Dictionary<string, string> list;

        public InfoEntreprise()
        {

        }

        /*public static void getInfos()
        {
         
            getInfoEntreprise("5f1ccad09db138f184034ce06ba87f74", "KA17sOqFVIRs");
        }*/

        public string getNom()
        {
            return nom;
        }

       public  void setNom(string nom)
        {
            this.nom = nom;
        }
    }
}
