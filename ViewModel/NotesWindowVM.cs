﻿

using MvvmHelpers.Commands;

using Safe.Helpers;
using Safe.Model;
using Safe.View;
using Safe.ViewModel.Helpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Safe.ViewModel {
    public class NotesWindowVM : ViewModelBase {
        public ICommand ExitCommand { get; set; }
        public ICommand NewNotebookCommand { get; set; }
        public ICommand NewNoteCommand { get; set; }
        public Command LogOutCommand { get; }
        public ICommand RenameCommand { get; set; }
        public ICommand RenameNotebookCompleteCommand { get; set; }
        public ICommand RenameNoteCompleteCommand { get; set; }
        public List<int> FontSizes { get; set; }
        public IOrderedEnumerable<FontFamily> Fonts { get; set; }
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        private Notebook _SelectedNoteBook;
        public Notebook SelectedNoteBook {
            get { return _SelectedNoteBook; }
            set {
                if (_SelectedNoteBook != value) {
                    _SelectedNoteBook = value;
                    RaisePropertyChanged();
                    GetNotes();
                }
            }
        }


        private bool _IsEnabled;
        public bool IsEnabled {
            get { return _IsEnabled; }
            set {
                if (_IsEnabled != value) {
                    _IsEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }


        private Note _SelectedNote;
        public Note SelectedNote {
            get { return _SelectedNote; }
            set {
                if (_SelectedNote != value) {
                    _SelectedNote = value;
                    RaisePropertyChanged();
                    SelectedNoteChanged.Invoke(this, new EventArgs());
                    if (SelectedNote != null) {
                        IsEnabled = true;
                    } else {
                        IsEnabled = false;
                    }
                }
            }
        }


        private Visibility _IsVisible;
        public Visibility IsVisible {
            get { return _IsVisible; }
            set {
                if (_IsVisible != value) {
                    _IsVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        public NotesWindowVM() {

            IsEnabled = false;
            IsVisible = Visibility.Collapsed;
            Notes = new ObservableCollection<Note>();
            Notebooks = new ObservableCollection<Notebook>();
            Fonts = System.Windows.Media.Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            FontSizes = new List<int>();
            for (int i = 7; i < 72; i++) {
                FontSizes.Add(i);
            }
            ExitCommand = new Command(() => {
                Application.Current.Shutdown();
            });
            NewNotebookCommand = new Command(() => {
                CreateNewNotebook();
            });
            RenameCommand = new Command(() => {
                IsVisible = Visibility.Visible;
            });
            NewNoteCommand = new HelperCommand {
                ExecuteDelegate = x => CreateNewNote(SelectedNoteBook.Id),
                CanExecuteDelegate = x => SelectedNoteBook != null
            };
            LogOutCommand = new Command(() => {
                LogOut.Invoke(this, new EventArgs());
            });
            RenameNotebookCompleteCommand = new HelperCommand {
                ExecuteDelegate = x => EditionCompltedNotebook(SelectedNoteBook),
                CanExecuteDelegate = x => true
            };
            RenameNoteCompleteCommand = new HelperCommand {
                ExecuteDelegate = x => EditionCompltedNote(SelectedNote),
                CanExecuteDelegate = x => true
            };


            GetNoteBooks();
        }

        private void EditionCompltedNote(Note selectedNote) {
            if (selectedNote != null) {
                IsVisible = Visibility.Collapsed;
                SqliteDatabase.Update(selectedNote);
                GetNoteBooks();
            }
        }

        private void EditionCompltedNotebook(Notebook notebook) {
            if (notebook != null) {
                IsVisible = Visibility.Collapsed;
                SqliteDatabase.Update(notebook);
                GetNotes();
            }

        }

        private async void CreateNewNote(int NotebookId) {
            Note note = new() {
                NotebookId = NotebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New Note"
            };
           await SqliteDatabase.InsertAsync(note);

            GetNotes();
        }

        private async void CreateNewNotebook() {
            Notebook notebook = new() { Name = $"Notebook", UserId = App.UserId };
          await SqliteDatabase.InsertAsync(notebook);
            GetNoteBooks();
        }

        public void GetNoteBooks() {

            var notebooks = SqliteDatabase.Read<Notebook>().Where(n => n.UserId == App.UserId);

            Notebooks.Clear();
            foreach (var item in notebooks) {
                Notebooks.Add(item);
            }
        }

        private void GetNotes() {

            if (SelectedNoteBook != null) {
                var notes = SqliteDatabase.Read<Note>().Where(
                    n => n.NotebookId == SelectedNoteBook.Id)
                    .ToList();

                Notes.Clear();
                foreach (var item in notes) {
                    Notes.Add(item);
                }
            }
        }

        public event EventHandler SelectedNoteChanged;
        public event EventHandler LogOut;
    }
}
