using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LVIII_Dejan_Prodanovic.ViewModel
{
    class MainViewModel:ViewModelBase
    {
        MainWindow view;

        Dictionary<int, string> fields = new Dictionary<int, string>();
        Random rnd = new Random();
        int yourMoveCounter = 0;
        int gameMoveCounter = 0;
        bool gameStarted = false;
        bool gameEnded = false;

        public MainViewModel(MainWindow mainView)
        {
            view = mainView;


        }
        private Visibility youWon = Visibility.Hidden;
        public Visibility YouWon
        {
            get
            {
                return youWon;
            }
            set
            {
                youWon = value;
                OnPropertyChanged("YouWon");
            }
        }
        private Visibility computerWon = Visibility.Hidden;
        public Visibility ComputerWon
        {
            get
            {
                return computerWon;
            }
            set
            {
                computerWon = value;
                OnPropertyChanged("ComputerWon");
            }
        }
        private Visibility tieResult = Visibility.Hidden;
        public Visibility TieResult
        {
            get
            {
                return tieResult;
            }
            set
            {
                tieResult = value;
                OnPropertyChanged("TieResult");
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


        private string button0_0;
        public string Button0_0
        {
            get
            {
                return button0_0;
            }
            set
            {
                button0_0 = value;
                OnPropertyChanged("Button0_0");
            }
        }
        private string button0_1;
        public string Button0_1
        {
            get
            {
                return button0_1;
            }
            set
            {
                button0_1 = value;
                OnPropertyChanged("Button0_1");
            }
        }

        private string button0_2;
        public string Button0_2
        {
            get
            {
                return button0_2;
            }
            set
            {
                button0_2 = value;
                OnPropertyChanged("Button0_2");
            }
        }

        private string button1_0;
        public string Button1_0
        {
            get
            {
                return button1_0;
            }
            set
            {
                button1_0 = value;
                OnPropertyChanged("Button1_0");
            }
        }

        private string button1_1;
        public string Button1_1
        {
            get
            {
                return button1_1;
            }
            set
            {
                button1_1 = value;
                OnPropertyChanged("Button1_1");
            }
        }

        private string button1_2;
        public string Button1_2
        {
            get
            {
                return button1_2;
            }
            set
            {
                button1_2 = value;
                OnPropertyChanged("Button1_2");
            }
        }

        private string button2_0;
        public string Button2_0
        {
            get
            {
                return button2_0;
            }
            set
            {
                button2_0 = value;
                OnPropertyChanged("Button2_0");
            }
        }

        private string button2_1;
        public string Button2_1
        {
            get
            {
                return button2_1;
            }
            set
            {
                button2_1 = value;
                OnPropertyChanged("Button2_1");
            }
        }
        private string button2_2;
        public string Button2_2
        {
            get
            {
                return button2_2;
            }
            set
            {
                button2_2 = value;
                OnPropertyChanged("Button2_2");
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

        private ICommand chooseTeam;
        public ICommand ChooseTeam
        {
            get
            {
                if (chooseTeam == null)
                {
                    chooseTeam = new RelayCommand(param => ChooseTeamExecute(),
                        param => CanChooseTeam());
                }
                return chooseTeam;
            }
        }
        private void ChooseTeamExecute()
        {
            try
            {

                ChooseTeam chooseTeam = new ChooseTeam();
                chooseTeam.ShowDialog();

                if ((chooseTeam.DataContext as ChooseTeamViewModel).SelectedTeam.Equals("X"))
                {
                    SelectedTeam = "X";
                }
                else
                {
                    SelectedTeam = "O";
                }

                Button0_0 = "";
                Button0_1 = "";
                Button0_2 = "";
                Button1_0 = "";
                Button1_1 = "";
                Button1_2 = "";
                Button2_0 = "";
                Button2_1 = "";
                Button2_2 = "";

                fields = new Dictionary<int, string>();

                gameStarted = true;
                gameEnded = false;
                yourMoveCounter = 0;
                gameMoveCounter = 0;
                YouWon = Visibility.Hidden;
                ComputerWon = Visibility.Hidden;
                TieResult = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }

        private bool CanChooseTeam()
        {

            return true;
        }

        private ICommand clickOnField;
        public ICommand ClickOnField
        {
            get
            {
                if (clickOnField == null)
                {
                    clickOnField = new RelayCommand(ClickOnFieldExecute,
                        CanClickOnFieldExexute);
                }
                return clickOnField;
            }
        }
        private void ClickOnFieldExecute(object obj)
        {
            try
            {
                var button = (obj as Button);
                // Find the buttons position in the array
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);


                //write Team name at selected field
                if (column.ToString().Equals("0") && row.ToString().Equals("0"))
                {
                    if (!fields.ContainsKey(1))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button0_0 = SelectedTeam;
                        fields.Add(1, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }

                    }

                }
                else if (row.ToString().Equals("0") && column.ToString().Equals("1"))
                {
                    if (!fields.ContainsKey(2))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button0_1 = SelectedTeam;
                        fields.Add(2, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("0") && column.ToString().Equals("2"))
                {
                    if (!fields.ContainsKey(3))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button0_2 = SelectedTeam;
                        fields.Add(3, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("1") && column.ToString().Equals("0"))
                {
                    if (!fields.ContainsKey(4))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button1_0 = SelectedTeam;
                        fields.Add(4, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("1") && column.ToString().Equals("1"))
                {
                    if (!fields.ContainsKey(5))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button1_1 = SelectedTeam;
                        fields.Add(5, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("1") && column.ToString().Equals("2"))
                {
                    if (!fields.ContainsKey(6))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button1_2 = SelectedTeam;
                        fields.Add(6, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("2") && column.ToString().Equals("0"))
                {
                    if (!fields.ContainsKey(7))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button2_0 = SelectedTeam;
                        fields.Add(7, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("2") && column.ToString().Equals("1"))
                {
                    if (!fields.ContainsKey(8))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button2_1 = SelectedTeam;
                        fields.Add(8, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }
                else if (row.ToString().Equals("2") && column.ToString().Equals("2"))
                {
                    if (!fields.ContainsKey(9))
                    {
                        yourMoveCounter++;
                        gameMoveCounter++;
                        Button2_2 = SelectedTeam;
                        fields.Add(9, SelectedTeam);
                        CheckForWinner();
                        if (gameEnded)
                        {
                            return;
                        }
                        if (yourMoveCounter <= 4)
                        {
                            AutoInput(button);
                            CheckForWinner();
                            if (gameEnded)
                            {
                                return;
                            }
                        }


                    }

                }


                if (gameMoveCounter == 9 && !gameEnded)
                {
                    TieResult = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanClickOnFieldExexute(object obj)
        {
            if (!gameStarted || gameEnded)
            {
                return false;
            }
            return true;
        }

        private void AutoInput(object obj)
        {
            int index = rnd.Next(1, 10);
            var button = (obj as Button);

            if (!fields.ContainsKey(index))
            {
                string input;
                if (SelectedTeam.Equals("X"))
                {
                    input = "O";

                }
                else
                {
                    input = "X";
                }
                if (index == 1)
                {
                    Button0_0 = input;
                    fields.Add(1, input);
                    gameMoveCounter++;
                }
                else if (index == 2)
                {
                    Button0_1 = input;
                    fields.Add(2, input);
                    gameMoveCounter++;
                }
                else if (index == 3)
                {
                    Button0_2 = input;
                    fields.Add(3, input);
                    gameMoveCounter++;
                }
                else if (index == 4)
                {
                    Button1_0 = input;
                    fields.Add(4, input);
                    gameMoveCounter++;
                }
                else if (index == 5)
                {
                    Button1_1 = input;
                    fields.Add(5, input);
                    gameMoveCounter++;

                }
                else if (index == 6)
                {
                    Button1_2 = input;
                    fields.Add(6, input);
                    gameMoveCounter++;
                }
                else if (index == 7)
                {
                    Button2_0 = input;
                    fields.Add(7, input);
                    gameMoveCounter++;
                }
                else if (index == 8)
                {
                    Button2_1 = input;
                    fields.Add(8, input);
                    gameMoveCounter++;
                }
                else if (index == 9)
                {
                    Button2_2 = input;
                    fields.Add(9, input);
                    gameMoveCounter++;
                }
            }
            else
            {
                AutoInput(button);
            }
        }
        /// <summary>
        /// Checks if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Wins



            if (Button0_0.Equals(Button0_1) && Button0_0.Equals(Button0_2)
                && !string.IsNullOrEmpty(Button0_0) && !string.IsNullOrEmpty(Button0_1)
                && !string.IsNullOrEmpty(Button0_2))
            {

                gameEnded = true;
                if (Button0_0.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }
            else if (Button1_0.Equals(Button1_1) && Button1_0.Equals(Button1_2)
                 && !string.IsNullOrEmpty(Button1_0) && !string.IsNullOrEmpty(Button1_1)
                && !string.IsNullOrEmpty(Button1_2))
            {

                gameEnded = true;
                if (Button1_0.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }
            else if (Button2_0.Equals(Button2_1) && Button2_0.Equals(Button2_2)
                 && !string.IsNullOrEmpty(Button2_0) && !string.IsNullOrEmpty(Button2_1)
                && !string.IsNullOrEmpty(Button2_2))
            {

                gameEnded = true;
                if (Button2_0.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;
                }

            }
            #endregion

            #region Vertical Wins

            if (Button0_0.Equals(Button1_0) && Button0_0.Equals(Button2_0)
                && !string.IsNullOrEmpty(Button0_0) && !string.IsNullOrEmpty(Button1_0)
                && !string.IsNullOrEmpty(Button2_0))
            {

                gameEnded = true;
                if (Button0_0.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }
            else if (Button0_1.Equals(Button1_1) && Button0_1.Equals(Button2_1)
                 && !string.IsNullOrEmpty(Button0_1) && !string.IsNullOrEmpty(Button1_1)
                && !string.IsNullOrEmpty(Button2_1))
            {

                gameEnded = true;
                if (Button0_1.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }
            else if (Button0_2.Equals(Button1_2) && Button0_2.Equals(Button2_2)
                 && !string.IsNullOrEmpty(Button0_2) && !string.IsNullOrEmpty(Button1_2)
                && !string.IsNullOrEmpty(Button2_2))
            {

                gameEnded = true;
                if (Button0_2.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;
                }

            }
            #endregion

            #region Diagonal Wins

            if (Button0_0.Equals(Button1_1) && Button0_0.Equals(Button2_2)
                && !string.IsNullOrEmpty(Button0_0) && !string.IsNullOrEmpty(Button1_1)
                && !string.IsNullOrEmpty(Button2_2))
            {

                gameEnded = true;
                if (Button0_0.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }
            else if (Button0_2.Equals(Button1_1) && Button0_2.Equals(Button2_0)
                 && !string.IsNullOrEmpty(Button0_2) && !string.IsNullOrEmpty(Button1_1)
                && !string.IsNullOrEmpty(Button2_0))
            {

                gameEnded = true;
                if (Button0_2.Equals(SelectedTeam))
                {
                    YouWon = Visibility.Visible;
                }
                else
                {
                    ComputerWon = Visibility.Visible;

                }
            }

            #endregion
        }
    }
}
