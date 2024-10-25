using Demoproject.Entity;
using MySql.Data.MySqlClient;
using System.Data;

namespace Demoproject.DAL
{
    public interface IDALArticle
    {
        Task<int> insupdArticle(ArticleModel article);
        Task<ArticleModel> viewArticle(int iartcId);
    }
}
