
using Newtonsoft.Json;

using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Helpers {
    public class SqliteDatabase {

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
                var res = await client.PostAsync($"{FirebadeDb}{Item.GetType().Name.ToLower()}", content);
                if (res.IsSuccessStatusCode) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public static List<T> Read<T>() where T : new() {

            List<T> items;

            using (SQLiteConnection conn = new(dbFile)) {

                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
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
