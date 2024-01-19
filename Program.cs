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

            Sustitucion();
        }

        static public void Sustitucion()
        {

            //PRINCIPIO DE SUSTITUCION
            //Este principio establece que puedes usar un objeto de una clase hija
            //en lugar de un objeto de la clase padre sin que el programa se rompa.

            //Permite que los objetos de clases hijas sean utilizados en
            //cualquier lugar donde se esperan objetos de la clase padre

            //--------------------------------------------------------
            //PRIMERA FORMA
            Mamiferos animal = new Caballo("Bucefalo");

            Mamiferos persona = new Humano("Juan");

            //--------------------------------------------------------
            //SEGUNDA FORMA
            Mamiferos animal1 = new Mamiferos("Bucefalo");

            Caballo Bucefalo = new Caballo("Bucefalo");

            //Aqui se aplica el principio de sustitucion
            animal1 = Bucefalo;

            //--------------------------------------------------------
            //EJEMPLO
            Caballo miBabieca = new Caballo("Babieta1");

            Humano miJuan = new Humano("Juan1");

            Gorila miCopito = new Gorila("Copito1");

            Mamiferos[] almacenAnimales = new Mamiferos[3];

            almacenAnimales[0] = miBabieca;
            almacenAnimales[1] = miJuan;
            almacenAnimales[2] = miCopito;

            foreach (Mamiferos i in almacenAnimales) i.pensar();
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
        
        //Con "virtual" estamos indicando que todas las sub clases de mamiferos
        //deberian de tener un metodo "pensar()",
        //En otras palabras que las clases hijas podran tener el mismo metodo 
        //y los cambios que resiva sera una sobreescritura para esta
        public virtual void pensar()
        {
            Console.WriteLine("Pensamiento basico instintivo");
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

        //Si en la clase padre hay un metodo con el mismo nombre y misma cantidad
        //de parametros, el metodo de la clase hija del mismo nombre invalida el
        //metodo de la clase padre siendo en este caso la salida "Soy capaz de pensar"

        //Agregando "override" indicamos que el metodo no sera independiente de la clase 
        //padre sino un sobreescritura al metodo de la clase padre
        public override void pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }
    }
    class Gorila : Mamiferos
    {
        public Gorila (String nombreGorila) : base(nombreGorila)
        {

        }
        public override void pensar()
        {
            Console.WriteLine("Pensamiento instintivo avanzado");
        }
        public void trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }
    }
}
