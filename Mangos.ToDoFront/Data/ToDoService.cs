using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mangos.ToDoFront.Data
{
    public class ToDoService
    {
        private ToDoServiceConfiguration config;
        private static HttpClient client = new HttpClient();
        public ToDoService(ToDoServiceConfiguration config)
        {
            this.config = config;
        }
        public async Task<TEntity[]> GetAllFromEntity<TEntity>()
        {
            return JsonConvert.DeserializeObject<TEntity[]>(await client.GetStringAsync(string.Format("{0}/api/{1}/{2}", config.BaseUrl, typeof(TEntity).Name, "GetAll")));
        }

        public async Task<TEntity> GetEntityById<TEntity, TKey>(TKey id)
        {
            return JsonConvert.DeserializeObject<TEntity>(await client.GetStringAsync(string.Format("{0}/api/{1}/{2}/{3}", config.BaseUrl, typeof(TEntity).Name, "Get", id.ToString())));
        }

        public async Task<bool> Insert<TEntity>(TEntity entity)
        {
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

        public async Task<bool> MarkAsDone<TEntity>(Guid id)
        {
            try
            {
                await client.PostJsonAsync(string.Format("{0}/api/{1}/{2}", config.BaseUrl, typeof(TEntity).Name, "MarkAsDone"), id);
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
