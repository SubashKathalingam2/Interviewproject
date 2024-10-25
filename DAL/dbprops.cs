namespace Demoproject.DAL
{
    public sealed class dbprops
    {
        public string dbName { get; set; } = "MasterDB";
        public string ConnString { get; set; } = "Server=127.0.0.1;Database={0};Uid=root;Pwd=123456;";
        public static string Conn { get; set; } = "Server=127.0.0.1;Database=MasterDB;Uid=root;Pwd=123456;";
    }
}
