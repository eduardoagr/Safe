
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

            //bool inserted = false;

            //using (SQLiteConnection conn = new(dbFile)) {

            //    conn.CreateTable<T>();
            //    int row = conn.Insert(Item);
            //    if (row > 0) {
            //        inserted = true;
            //    }
            //}

            //return inserted;

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

            //List<T> items;

            //using (SQLiteConnection conn = new(dbFile)) {

            //    conn.CreateTable<T>();
            //    items = conn.Table<T>().ToList();
            //}
            //return items;


            using (HttpClient client = new()) {
                var res = await client.GetAsync($"{FirebadeDb}{typeof(T).GetType().Name.ToLower()}.json");
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

        public static bool Update<T>(T Item) {

            bool inserted = false;

            using (SQLiteConnection conn = new(dbFile)) {

                conn.CreateTable<T>();
                int row = conn.Update(Item);
                if (row > 0) {
                    inserted = true;
                }
            }
            return inserted;
        }

        public static bool Delete<T>(T Item) {

            bool inserted = false;

            using (SQLiteConnection conn = new(dbFile)) {

                conn.CreateTable<T>();
                int row = conn.Delete(Item);
                if (row > 0) {
                    inserted = true;
                }
            }
            return inserted;
        }
    }
}
