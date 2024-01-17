using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHerencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caballo Babieca = new Caballo();

            Humano Juan = new Humano();

            Gorila Copito = new Gorila();

            Copito.trepar();
        }
    }

    class Mamiferos
    {
        public void respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }
        public void cuidarCrias()
        {
            Console.WriteLine("Cuido de mis crias hasta que se valga por si solas");
        }
    }

    //Sintaxis de como hereda de la clase "Mamifero" a "Caballo"
    class Caballo : Mamiferos
    {
        public void galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }
    }
    class Humano : Mamiferos
    {
        public void pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }
    }
    class Gorila : Mamiferos
    {
        public void trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }
    }
}
