using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;
using System.Threading.Tasks;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.CreateDate = DateTime.Now;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}