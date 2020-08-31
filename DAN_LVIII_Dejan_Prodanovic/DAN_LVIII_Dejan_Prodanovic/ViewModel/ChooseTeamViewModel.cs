using DAN_LVIII_Dejan_Prodanovic.Command;
using DAN_LVIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LVIII_Dejan_Prodanovic.ViewModel
{
    class ChooseTeamViewModel:ViewModelBase
    {
        ChooseTeam view;


        public ChooseTeamViewModel(ChooseTeam chooseTeam)
        {
            view = chooseTeam;
            Teams = new List<string>();
            Teams.Add("X");
            Teams.Add("O");
        }

        private List<string> teams;
        public List<string> Teams
        {
            get
            {
                return teams;
            }
            set
            {
                teams = value;
                OnPropertyChanged("Teams");
            }
        }
        private string selectedTeam;
        public string SelectedTeam
        {
            get
            {
                return selectedTeam;
            }
            set
            {
                selectedTeam = value;
                OnPropertyChanged("SelectedTeam");
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private ICommand choose;
        public ICommand Choose
        {
            get
            {
                if (choose == null)
                {
                    choose = new RelayCommand(param => ChooseExecute(),
                        param => CanChooseExecute());
                }
                return choose;
            }
        }
        private void ChooseExecute()
        {
            try
            {

                view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }

        private bool CanChooseExecute()
        {
            if (string.IsNullOrEmpty(SelectedTeam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
