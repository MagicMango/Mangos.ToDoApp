using Microsoft.AspNetCore.Blazor;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mangos.ToDoFront.Data
{
    public class ToDoService
    {
        private ToDoServiceConfiguration config;
        public ToDoService(ToDoServiceConfiguration config)
        {
            this.config = config;
        }
        public async Task<TEntity[]> GetAllFromEntity<TEntity>()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(string.Format("{0}/api/{1}/{2}", config.BaseUrl, typeof(TEntity).Name, "GetAll"));
            return JsonConvert.DeserializeObject<TEntity[]>(result);
        }

        public async Task<TEntity> GetEntityById<TEntity, TKey>(TKey id)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(string.Format("{0}/api/{1}/{2}?id={3}", config.BaseUrl, typeof(TEntity).Name, "Get", id.ToString()));
            return JsonConvert.DeserializeObject<TEntity>(result);
        }

        public async Task<bool> Insert<TEntity>(TEntity entity)
        {
            var client = new HttpClient();
            try
            {
                await client.PostJsonAsync(string.Format("{0}/api/{1}/{2}", config.BaseUrl, typeof(TEntity).Name, "Post"), entity);
                return true;
            }
            catch
            {
                //Todo Logging!!!!!
                return false;
            }
        }
        public async Task<bool> Update<TEntity>(TEntity entity)
        {
            var client = new HttpClient();
            try
            {
                await client.PutJsonAsync(string.Format("{0}/api/{1}/{2}", config.BaseUrl, typeof(TEntity).Name, "Post"), entity);
                return true;
            }
            catch
            {
                //Todo Logging!!!!!
                return false;
            }
        }
        public async Task<bool> Delete<TEntity,TKey>(TKey id)
        {
            var client = new HttpClient();
            try
            {
                await client.DeleteAsync(string.Format("{0}/api/{1}/{2}?id={3}", config.BaseUrl, typeof(TEntity).Name, "Post", id.ToString()));
                return true;
            }
            catch
            {
                //Todo Logging!!!!!
                return false;
            }
        }
    }
}
