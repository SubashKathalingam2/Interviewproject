using Demoproject.Entity;

namespace Demoproject.BAL
{
    public interface IBALArticle
    {
        Task<int> insupdArticle(ArticleModel article);
        Task<ArticleModel> viewArticle(int iartcId);
    }
}
