using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEditPage : ContentPage
    {
        public NoteEditPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.LastUpdatedDate = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool deleteConfirmed = await DisplayAlert("Confirm", "Are you sure you want to delete this note?", "Delete", "Cancel");

            if(deleteConfirmed)
            {
                Note note = (Note)BindingContext;
                await App.Database.DeleteNoteAsync(note);
                await Navigation.PopAsync();
            }
        }
    }
}