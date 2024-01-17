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
            Caballo miBabieca = new Caballo("Babieta");

            Humano miJuan = new Humano("Juan");

            Gorila miCopito = new Gorila("Copito");

            miJuan.getNombre();
            miBabieca.getNombre();
            miCopito.getNombre();
        }
    }

    class Mamiferos
    {
        public Mamiferos(String nombre)
        {

            nombreSerVivo = nombre;

        }
        public void respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }
        public void cuidarCrias()
        {
            Console.WriteLine("Cuido de mis crias hasta que se valga por si solas");
        }

        public void getNombre()
        {
            Console.WriteLine($"El nombre del ser vivo es: {nombreSerVivo}");
        }
        private String nombreSerVivo;
    }

    //Sintaxis de como hereda de la clase "Mamifero" a "Caballo"
    class Caballo : Mamiferos
    {
        //USO DE LA INSTRUCCION :base()
        /*Si el constructor de la clase padre tiene metodo por defecto podemos presindir 
         de la instruccion ":base()" porque implicitamente ya estaria
        
         Pero si sustituimos el metodo por defecto por uno propio entonces debomos contruir 
        la instruccion ":base()"*/
        public Caballo(String nombreCaballo):base(nombreCaballo)
        {

        }
        public void galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }
    }
    class Humano : Mamiferos
    {
        public Humano(String nombreHumano) : base(nombreHumano)
        {

        }
        public void pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }
    }
    class Gorila : Mamiferos
    {
        public Gorila (String nombreGorila) : base(nombreGorila)
        {

        }
        public void trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }
    }
}
