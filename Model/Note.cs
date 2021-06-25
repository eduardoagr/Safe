using Safe.Inteface;

using System;

namespace Safe.Model {
    public class Note : HasId {
        public string Id { get; set; }
        public string NotebookId { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string FileLocation { get; set; }
    }
}
