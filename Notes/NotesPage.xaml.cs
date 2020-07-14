using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnSwiped(object sender, EventArgs e)
        {
            bool deleteConfirmed = await DisplayAlert("Confirm", "Are you sure you want to delete this note?", "Delete", "Cancel");
        }

        async void OnListViewItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() != null)
            {
                await Navigation.PushAsync(new NoteEditPage
                {
                    BindingContext = e.CurrentSelection.FirstOrDefault() as Note
                });
            }
        }
    }
}