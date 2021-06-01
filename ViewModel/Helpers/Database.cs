
using Newtonsoft.Json;

using Safe.Inteface;

using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Helpers {
    public class Database {

        private static readonly string dbFile = Path.Combine(Environment.CurrentDirectory, "NotesDB.db3");
        private static readonly string FirebadeDb = "https://safe-wpf-default-rtdb.europe-west1.firebasedatabase.app/";

        public static async Task<bool> InsertAsync<T>(T Item) {

            string jsonBody = JsonConvert.SerializeObject(Item);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            using (HttpClient client = new()) {
                var res = await client.PostAsync($"{FirebadeDb}{Item.GetType().Name.ToLower()}.json", content);
                if (res.IsSuccessStatusCode) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public static async Task<List<T>> ReadAsync<T>() where T : HasId {

            using (HttpClient client = new()) {
                var res = await client.GetAsync($"{FirebadeDb}{typeof(T).Name.ToLower()}.json");
                var JsonRes = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode) {
                    var valuePairs = JsonConvert.DeserializeObject<Dictionary<string, T>>(JsonRes);
                    if (valuePairs != null) {
                        List<T> objts = new();

                        foreach (var item in valuePairs) {

                            item.Value.Id = item.Key;
                            objts.Add(item.Value);
                        }
                        return objts;
                    }

                } else {
                    return null;
                }

                return null;
            }
        }

        public static async Task<bool> UpdateAsync<T>(T Item) where T : HasId{

            string jsonBody = JsonConvert.SerializeObject(Item);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            using (HttpClient client = new()) {
                var res = await client.PatchAsync($"{FirebadeDb}{Item.GetType().Name.ToLower()}/{Item.Id}.json", content);
                if (res.IsSuccessStatusCode) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteAsync<T>(T Item) where T : HasId {

            using (HttpClient client = new()) {
                var res = await client.DeleteAsync($"{FirebadeDb}{Item.GetType().Name.ToLower()}/{Item.Id}.json");
                if (res.IsSuccessStatusCode) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}
