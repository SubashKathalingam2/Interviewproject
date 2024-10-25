using Demoproject.Entity;
using MySql.Data.MySqlClient;
using System.Data;

namespace Demoproject.DAL
{
    public class DALArticle : IDALArticle
    {
        public async Task<int> insupdArticle(ArticleModel article)
        {
            int irowaffected = 0;
            using (MySqlConnection conn = new MySqlConnection(dbprops.Conn))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("sp_insupd_article", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("_id", article.iartId.ToString());
                    cmd.Parameters.AddWithValue("_name", article.strartName.ToString());
                    cmd.Parameters.AddWithValue("_code", article.strartCode.ToString());
                    cmd.Parameters.AddWithValue("_type", article.iarttype.ToString());
                    cmd.Parameters.AddWithValue("_price", article.dprice.ToString());
                    cmd.Parameters.AddWithValue("_status", article.iStatus.ToString());

                    await conn.OpenAsync();

                    irowaffected = await cmd.ExecuteNonQueryAsync();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.GetBaseException().Message.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.GetBaseException().Message.ToString());
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return irowaffected;
        }
        public async Task<ArticleModel> viewArticle(int iartcId)
        {
            ArticleModel _result = new ArticleModel();
            using (MySqlConnection conn = new MySqlConnection(dbprops.Conn))
            {
                try
                {
                    string Query = string.Format("select * from vw_tbl_articles Where ArtcId={0};", iartcId);

                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("_id", iartcId.ToString());

                    await conn.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        _result.iartId = Convert.ToInt32(reader["ArtcId"].ToString());
                        _result.strartName = Convert.ToString(reader["ArtcName"].ToString());
                        _result.strartCode = Convert.ToString(reader["ArtcCode"].ToString());
                        _result.iarttype = Convert.ToInt32(reader["Artctype"].ToString());
                        _result.dprice = Convert.ToDecimal(reader["Price"].ToString());
                        _result.iStatus = Convert.ToInt32(reader["Status"].ToString());
                        _result.iStatus = Convert.ToInt32(reader["Status"].ToString());
                        _result.strarttype = Convert.ToString(reader["ArtctypeName"].ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.GetBaseException().Message.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.GetBaseException().Message.ToString());
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return _result;
        }
    }
}

