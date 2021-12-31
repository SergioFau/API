using AA_API.Sites.Models;
using AA_API.Categories.Models;
using System.Collections.Generic;
using System;

namespace AA_API.Sites.Infraestructure{

    public class SitesInfraestructure : Site
    {
        private static List<Site> sitios = new List<Site>
        {
            new Site{id = 1, nombre = "Google", user="sergio", createdAt = DateTime.Now, password="1234", description="Google, LLC es una compañía principal subsidiaria de la multinacional estadounidense Alphabet.", idCategory = 4},
            new Site{id = 2, nombre = "Marca", user="sergio", createdAt=DateTime.Now, password="1234", description="Marca es un diario español de información deportiva, con sede en Madrid. Fundado en 1938.", idCategory = 2},
            new Site{id = 3, nombre = "Instagram", user="sergio", createdAt=DateTime.Now, password="1234", description="Instagram (comúnmente abreviado como IG o Insta) es una aplicación y red social de origen estadounidense, propiedad de Meta.", idCategory = 1},
            new Site{id = 4, nombre = "WhatsApp", user="sergio", createdAt=DateTime.Now, password="1234", description="WhatsApp Messenger (o simplemente WhatsApp) es una aplicación de mensajería instantánea para teléfonos inteligentes, propiedad de Meta.", idCategory = 1},
            new Site{id = 5, nombre = "Amazon", user="sergio", createdAt=DateTime.Now, password="1234", description="Amazon, Inc. es una compañía estadounidense de comercio electrónico y servicios de computación.", idCategory = 4},
            new Site{id = 6, nombre = "Netflix", user="sergio", createdAt=DateTime.Now, password="1234", description="Netflix, Inc. es una empresa de entretenimiento y un servicio por suscripción.", idCategory = 4},
            new Site{id = 7, nombre = "Twitch", user="sergio", createdAt=DateTime.Now, password="1234", description="Twitch (también conocido como Twitch.TV) es una plataforma perteneciente a Amazon, Inc., que permite realizar transmisiones en vivo. ", idCategory = 4}
        };
        public void add (Site sitio){
            Site sitioComprobar  = get(sitio.id);
            if(sitioComprobar != null){
                sitios.Add(sitioComprobar);
            }
        }
        public void remove (Site sitio){
            Site sitioComprobar  = get(sitio.id);
            if(sitioComprobar != null){
                sitios.Remove(sitioComprobar);
            }
        }
        public Site get (int idSitio){
           return sitios.Find(x => x.id == idSitio);
        }
        public List<Site> getAll (){
           return sitios;
        }        
        public int contar() {
            int numero = 0;
            foreach (var sitioContar in sitios)
            {
                numero++;
            }
                return numero;
        }
    }
}