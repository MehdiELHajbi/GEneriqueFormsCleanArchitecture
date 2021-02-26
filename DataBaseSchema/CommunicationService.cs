using EntityFrameWorkShema;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Newtonsoft.Json;

namespace DataBaseSchema
{
    public static class CommunicationService
    {
        public static string GEtSchemaJson(DatabaseOptions databseOption)
        {
            var schema = Shemadatabase.GetShema("", databseOption);

            var json = JsonConvert.SerializeObject(schema, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            return json;
        }

        public static DatabaseModel GEtSchema(DatabaseOptions databseOption)
        {
            return Shemadatabase.GetShema("", databseOption);
        }
    }
}
