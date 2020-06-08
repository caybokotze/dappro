using Dapper;

namespace Dappro
{
    public static class CustomMappings
    {
        public static void ConfigureMappings()
        {
            //GenericMapper<Script>.Map(); //Make sure properties are decorated.
            //SqlMapper.SetTypeMap(typeof(Script), new ColumnAttributeTypeMapper<Script>());
        }
    }
}