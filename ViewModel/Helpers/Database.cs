using SQLite;

using System;
using System.Collections.Generic;
using System.IO;

namespace Safe.Helpers {
    public class Database {

        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "NotesDB.db3");

        public static bool Insert<T>(T Item) {

            bool inserted = false;

            using (SQLiteConnection conn = new(dbFile)) {

                conn.CreateTable<T>();
                int row = conn.Insert(Item);
                if (row > 0) {
                    inserted = true;
                }
            }
            return inserted;
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
