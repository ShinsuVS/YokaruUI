using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using YokaruUI.View.Pages;

namespace YokaruUI.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Page Auth = new AuthPage();
        private Page Home= new HomePage();
        private Page Sounds= new SoundsPage();
        private Page Notes= new NotesPage();
        private Page _CurPage = new HomePage();

        public Page CurPage
        {
            get => _CurPage;
            set=> Set(ref _CurPage, value);
        }
        public ICommand OpenAuthPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Auth);
            }
        }
        public ICommand OpenHomePage
        {
            get
            {
                return new RelayCommand(() => CurPage = Home);
            }
        }
        public ICommand OpenSoundsPage
        {
            get
            {
                return new RelayCommand(() => CurPage = Sounds);
            }
        }
        public ICommand OpenNotesPage
        {
            get
            {
                return new RelayCommand( () => CurPage = Notes);
            }
        }

    }
}
