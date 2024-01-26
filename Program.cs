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

            //Para ver los metodos de cada interfas dado el caso los metodos se repitan 
            //se debera de crear un metodo y aplicar el metodo de sustitucion como se
            //muestra a continuacion
            IMamiferosTerrestres ImiBabieca = miBabieca;
            ISaltoConPatas ImiBabieca1 = miBabieca;

            Humano miJuan = new Humano("Juan");

            Gorila miCopito = new Gorila("Copito");

            miJuan.getNombre();
            miBabieca.getNombre();
            miCopito.getNombre();

            //Sustitucion();

            Ballena miWally = new Ballena("Wally");

            miWally.nadar();

            Console.WriteLine($"Numero de patas de Babieta {ImiBabieca.NumeroPatas()}");

            Console.WriteLine($"Patas utilizadas en el salto de Babieca: {ImiBabieca1.NumeroPatas()}");

            Lagartija Juancho = new Lagartija("Juancho");

            Juancho.getNombre();

            miJuan.getNombre();
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

    /*INTERFACES:
     Es como un contrato que una clase firma. Este contrato especifica qué métodos y propiedades debe proporcionar la clase que lo firma. */

    //RESTRICCIONES:
    /*
     - No se permite definir campos (variables)
     - No se puede definir constructores
     - No se permite definir destructores
     - No se puede especificar modificadores de acceso en metodos (Todos son public de forma implicita)
     - No se puede anidar clases ni otro tipo de estructuras en las interfaces
     */
    //Todos los nombres de las interfaces deben de iniciar con una "I"

    //Las interfaces pueden poseer muchos metodos
    interface IMamiferosTerrestres
    {
        //Los metodos de una interfaz no se desarrollan 

        //No se abren llaves, no hay codigo dentro de ellas. Simplemente de declaran

        //No poseen modificadores de acceso
        int NumeroPatas();
    }

    interface IAnimalesYDeportes
    {
        String TipoDeporte();
        Boolean EsOlimpico();
    }

    interface ISaltoConPatas
    {
        int NumeroPatas();
    }

    //CLASES ABSTRACTAS
    //Son como las interfaces que asigna metodos que tenemos que implementar de forma obligada con la diferencia que dentro de estas tambien podemos crear metodos con contenido dentro de estas

    //Si la clase posee por lo menos 1 metodo abstracto la clase debera ser abstracta
    abstract class Animales
    {
        public void respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }

        //Asi se declara un metodo abstracto
        public abstract void getNombre();

    }

    class Lagartija : Animales
    {
        public Lagartija(String nombre)
        {
            nombreReptil = nombre;
        }

        public override void getNombre()
        {
            Console.WriteLine($"El nombre del reptil es: {nombreReptil}");
        }

        private String nombreReptil;
    }
    class Mamiferos: Animales
    {
        public Mamiferos(String nombre)
        {

            nombreSerVivo = nombre;

        }

        //Los metodos o variables "protected" solo son accesible desde su misma clase
        //y de sus clases hijas
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
        //Con "override" sobreescribimos al metodos del que estamos heredando
        public override void getNombre()
        {
            Console.WriteLine($"El nombre del mamifero es: {nombreSerVivo}");
        }
        private String nombreSerVivo;
    }
    //Sintaxis de como hereda de la clase "Mamifero" a "Caballo"

    //Sintaxis de como agregar una interfaz y el orden es: 1° La clase y 2° La interfas o interfaces 
    //separado por una ","
    class Caballo : Mamiferos, IMamiferosTerrestres, IAnimalesYDeportes, ISaltoConPatas
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
        //Al desarollar interfaces dentro de un clase:
        //1 - El nombre del metodo debe de coincidir con el que se definio en la interfaz
        //2 - El tipo de dato a devolver debe de coincidir con el que se definio en la interfaz
        //3 - El numero de parametros debe de coincidir con el numero y tipo con los que se definieron en la interfaz

        //------------------------------------------------------------------------------
        /*public int NumeroPatas()
        //{
        //    return 4;
        }*/
        //------------------------------------------------------------------------------

        //EL CODIGO DE ARRIBA MUESTRA LA FORMA COMUN DE HACERLO
        //Si en un dado caso existan 2 metodos con el mismo nombre en diferentes interfaces 
        //la forma de solucionarlo es la siguiente:

        //Precindimos del modificador de accesos en este caso "public" y solo dejamos el tipo seguido del nombre de la interfas y con punto indicamos el metodo al que queremos llamar

        int IMamiferosTerrestres.NumeroPatas()
        {
            return 4;
        }

        int ISaltoConPatas.NumeroPatas() 
        {
            return 2;
        }

        public String TipoDeporte()
        {
            return "Hipica";
        }
        public Boolean EsOlimpico()
        {
            return true;
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
    class Adolecente : Humano
    {
        public Adolecente(string nombreAdolecente) : base(nombreAdolecente)
        {

        }
        public override void pensar()
        {
            Console.WriteLine("Las hormonas me impiden pensar con claridad");
        }
    }
    class Gorila : Mamiferos, IMamiferosTerrestres
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

        public int NumeroPatas()
        {
            return 2;
        }
    }
    class Chimpance : Gorila
    {
        public Chimpance(string nombreChimpace) : base(nombreChimpace)
        {

        }

    }
    class Ballena : Mamiferos
    {
        public Ballena(String nombreBallena):base(nombreBallena)
        {

        }

        public void nadar()
        {
            Console.WriteLine("Soy capaz de nadar");
        }
    }
}
//Clases selladas (sealed classes)
//Son aquellas de las cuales no se va a poder heredar 
//Impide la herencia de clase y la sobreescritura de metodos

//Sintaxis en clases 

/*sealed class clase
{

    Sintaxis con metodos
    Con "sealed" indicamos que el metodo no se puede sobreescribir

    public sealed override void pensar()
    {

    }

}*/