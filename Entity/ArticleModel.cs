namespace Demoproject.Entity
{
    public class ArticleModel
    {
        public int iartId { get; set; }
        public string strartName { get; set; }
        public string strartCode { get; set; }
        public int iarttype { get; set; }
        public string strarttype { get; set; }
        public decimal dprice { get; set; }
        public int iStatus { get; set; }
    } 
    public class ArticleTypeModel
    {
        public int iartTypeId { get; set; }
        public int iartTypename { get; set; }
    }
}
