using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenciaDUAL.Models
{
    public static class DiccionarioAlumnos
    {
        public static string ValidarAlumno(string keyWLastLetter)
        {
            string key = subString(keyWLastLetter);

            Dictionary<string, string> diccionarioAlumnos = new Dictionary<string, string>()
            {
                { "3F0058B6C011", "Estevez Cardoso Brayan" },
                { "3F0058BBB468", "Wang Almazan Ammi Jatziry"},
                { "3F0058B6C617", "Bustos Mejia Cristopher"},
                { "3F0058BBC71B", "Cordoba Molina Alexandher"},
                { "1E0059EAAB06", "Ramirez de la Cruz Jaritzy Johana" },
                { "3F0058BC548F", "Rodriguez Diaz Rodrigo" },
                { "3F0058B6C514", "Calzada Espinosa Eder Joel" },
                { "3F0058B6BB6A", "Martinez Barrera Kevin Nathanael" },
                { "3F0058BC419A", "Mejia Osorio Roberto Alexis" },
                { "3F0058B6BB6F", "Garcia Alvarado Juan Daniel"},
                { "3F0058BBBF63", "Martinez Jimenez Rodrigo" },
                {"3F0058BBBB67", "Mora Dominguez Brian Oswaldo" },
                {"3F0058B6B968", "Mercado Flores Juan Francisco" },
                {"3F0058BC1AC1", "Diaz Garcia Karla Faviola"},
                {"1E005A8C10D8", "Martinez Hernandez Dilan Raul"},
                {"3F0058BBT30F","Baltazar Ortiz Sebastian"},
                { "3F0058BC15CE","Gomez Romero Enrique"},
                { "3F0058BBC814", "Cervantes Rosas Jesed"},
                {"3F0058B6E130", "Ramirez Mejia Sharay" },
                {"3F0058B6BD6C", "Garcia Arista Erika Tamara" },
                {"3F0058BBC31F","Hernandez Tellez Darien Alejandro" },
                {"3F0058BC479C", "Hernandez Hernandez Raul" },
                { "3F0058BC13C8", "Gonzalez Luna Freddy Daniel" },
                { "3F0058BC4D96", "Basurto Basurto Oscary" }
            };
            return diccionarioAlumnos[key];
        }

        public static string subString(string key)
        {
            string newKey = "";
            for(int i = 0; i < key.Length - 1; i++)
            {
                newKey += key[i];
            }
            return newKey;
        }
    }
}
