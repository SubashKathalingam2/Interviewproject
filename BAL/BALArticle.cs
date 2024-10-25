using Demoproject.DAL;
using Demoproject.Entity;

namespace Demoproject.BAL
{
    public class BALArticle : IBALArticle
    {
        IDALArticle dalarticle;

        public BALArticle()
        {
            dalarticle = new DALArticle();
        }
        public async Task<int> insupdArticle(ArticleModel article)
        {
           return await dalarticle.insupdArticle(article);
        }
        public async Task<ArticleModel> viewArticle(int iartcId)
        {
           return await dalarticle.viewArticle(iartcId);
        }
    }
}
