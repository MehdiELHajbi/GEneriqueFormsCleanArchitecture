namespace EntityFrameworkCore.Generator.Metadata.Generation
{
    public class EntityContexts : ModelBase
    {
        public EntityContexts()
        {
            Entities = new EntityCollection();
        }

        public string ContextNamespace { get; set; }

        public string ContextClass { get; set; }

        public string ContextBaseClass { get; set; }

        public string DatabaseName { get; set; }

        public EntityCollection Entities { get; set; }


    }
}
