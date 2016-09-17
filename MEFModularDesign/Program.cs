using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MEFModularDesign
{
    public interface ILoader // heeft een calculate functie. bv 2+ 2 = string 4.
    {
        List<myPerson> load();
    }

    public class myPerson
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public interface ISorter // heeft een calculate functie. bv 2+ 2 = string 4.
    {
        int Calculate(String input);
    }


    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(ILoader))]
        public ILoader FileLoader;

        [Import(typeof(ISorter))]
        public ISorter FileSorter;


        static void Main(string[] args)
        {
            // blijft hij doen zolang er input is van de gebruiker
            Program p = new Program(); //Composition is performed in the constructor
            List<myPerson> a = p.FileLoader.load();
            foreach (var item in a)
            {
                Console.WriteLine(item.age);

            }
            Console.ReadKey();

        }

        private Program()
        {

            // An aggregate catalog that combines multiple catalogs
            // te maken met MEF, je kan hier een assambly toevoegen. Dat is op dit moment het programma waar je nu naar zit te kijken.
            // in dit catalog kan je een assembly toevoegen, dat is op dit moment het programma.
            // dat zit in de execute
            var catalog = new AggregateCatalog();
            // Adds all the parts found in the same assembly as the Program class
            // aangeven dat de functionaliteit gaat inelzen vanuit de assambly en directary.
            // assambly betekent samenkomst. bijvoorbeeld 
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            // in deze directory gaat die alle dll's inlezen. Dat doet die in een compositie container.
            // hier komen de extentions te staan
            catalog.Catalogs.Add(new DirectoryCatalog(@"C:\Users\Murat\Documents\Visual Studio 2015\Projects\Jeerjaar2\c sharp\MEFModularDesign\MEFModularDesign\Extentions"));


            // Create the CompositionContainer with the parts in the catalog
            // maakt een compositie van de catalog van assembly's die we bij hem hebben aangeboden
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                // hier gaat die op zoek naar al die informatie die we hebben aangeboden in de assably's van programm of de assambly in een bepaalde directory. Die gaat die bijelkaar verzamelen zodat we die kunnen gebruiken.
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
