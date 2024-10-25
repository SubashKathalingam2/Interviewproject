using Demoproject.BAL;
using Demoproject.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Demoproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleMasterController : ControllerBase
    {
        IBALArticle balarticle;

        public ArticleMasterController()
        {
            balarticle = new BALArticle();
        }
        [HttpPost("insupdArticle")]
        public async Task<IActionResult> insupdArticle(ArticleModel article)
        {
            try
            {
                if (article.strartName== "string" || article.strartName.Length ==0)
                {
                    return Ok(
                                        new ResponseModel
                                        {
                                            strMessage = "Please Ente Valid Article Name",
                                            strStatus = "info",
                                        }
                                    );
                }
                
                int iresul = await balarticle.insupdArticle(article);
                return Ok(
                    new ResponseModel
                    {
                        strMessage = iresul == 1 ? "Article Successfully Saved" : "Something Went Wrong!",
                        strStatus = iresul == 1 ? "sucess" : "info",
                    }
                );
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    strMessage = ex.GetBaseException().Message.ToString(),
                    strStatus = "error",
                });
            }
        }
        
        [HttpGet("viewArticle/{iartcId}")]
        public async Task<IActionResult> viewArticle(int iartcId)
        {
            try
            {
                IDictionary<string,object> _dicartc=new Dictionary<string,object>();
                _dicartc.Add("article",await balarticle.viewArticle(iartcId));
                _dicartc.Add("strStatus", "success");
                return Ok(_dicartc);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    strMessage = ex.GetBaseException().Message.ToString(),
                    strStatus = "error",
                });
            }
        }
    }
}
