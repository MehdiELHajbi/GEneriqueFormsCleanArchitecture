namespace WorkFlowPattern.CompositePattern
{
    public class TestComposite
    {
        public void run()
        {
            Composite racine = new Composite("Repertoire 1");
            Composite composite2 = new Composite("Repertoire 2");



            racine.add(composite2);
            racine.add(new Element("Fichier 1"));
            racine.add(new Element("Fichier 2"));
            racine.add(new Element("Fichier 3"));
            composite2.add(new Element("Fichier 21"));
            composite2.add(new Element("Fichier 22"));

            racine.operation();
        }
    }
}
