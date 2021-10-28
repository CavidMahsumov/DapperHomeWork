using DapperHomeWork.Commands;
using DapperHomeWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHomeWork.Domain.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private Books selectedBook;

        public Books SelectedBooks
        {
            get { return selectedBook; }
            set { selectedBook = value; OnPropertyChanged(); }
        }

        public RelayCommand AddBtnClick { get; set; }
        public RelayCommand UpdateBtnClick { get; set; }
        public RelayCommand DeleteBtnClick { get; set; }
        public RelayCommand SelectBookCommand { get; set; }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            mainWindow.BooksDataGrid.ItemsSource = App.DB.booksRepository.GetAllData();
            AddBtnClick = new RelayCommand((sender) =>
            {
                App.DB.booksRepository.AddData(new Books
                {
                    Name = mainWindow.NameTxtBox.Text,
                    AuthorName = mainWindow.AuthorNametxtBox.Text,
                    Price = decimal.Parse(mainWindow.PriceTxtBox.Text)
                });

                mainWindow.BooksDataGrid.ItemsSource = App.DB.booksRepository.GetAllData();

            });
            UpdateBtnClick = new RelayCommand((sender) =>
            {

                App.DB.booksRepository.UpdateData(SelectedBooks.Id, new Books
                {
                     Name=mainWindow.NameTxtBox.Text,
                      Price=decimal.Parse(mainWindow.PriceTxtBox.Text),
                       AuthorName=mainWindow.AuthorNametxtBox.Text

                });
                mainWindow.BooksDataGrid.ItemsSource = App.DB.booksRepository.GetAllData();

            });
            SelectBookCommand = new RelayCommand((seder) => {

                if (SelectedBooks != null)
                {
                    var Book = App.DB.booksRepository.GetData(SelectedBooks.Id);
                    SelectedBooks = Book;
                }

            });
            DeleteBtnClick = new RelayCommand((sender) =>
            {
                App.DB.booksRepository.DeleteData(selectedBook.Id);
                mainWindow.BooksDataGrid.ItemsSource = App.DB.booksRepository.GetAllData();



            });


        }
    }
}
