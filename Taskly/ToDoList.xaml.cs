using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Taskly
{
    /// <summary>
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Page
    {
        //VARs
        bool init = true;
        LangHandling language = new LangHandling();
        ColorThemeHandling colorTheme = new ColorThemeHandling();
        private DispatcherTimer _timer;
        private int _counter = 0;
        int currentLanguage = GlobalSettings.Language;
        int currentThemeColor = GlobalSettings.Theme;
        TasksHandler TasksHandler = new TasksHandler();
        public ToDoList()
        {
            InitializeComponent();

            GlobalSettings.CurrentPage = 0;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;
            _timer.Start(); ;

            if (init == true)
            {
                themeChanger(GlobalSettings.Theme);
                langChanger(GlobalSettings.Language);
                Button_AddToDo.Content = language.lang_default.BtnAddToList;
                Button_RemoveToDo.Content = language.lang_default.BtnRemoveFromList;
                TasksHandler.toDo_Events = TasksHandler.LoadFromFile(GlobalSettings.FilePath);
                UpdateStackPanel();
                init = false;
            };
            GlobalSettings.OnLanguageChanged += langChanger;
            GlobalSettings.OnThemeChanged += themeChanger;

            void langChanger(int i)
            {
                currentLanguage = i;
                Button_AddToDo.Content = language.langs[currentLanguage].BtnAddToList;
                Button_RemoveToDo.Content = language.langs[currentLanguage].BtnRemoveFromList;
                //Button_Setting.Content = language.langs[currentLanguage].btnSettings;
                Todo_DatePicker.Text = language.langs[currentLanguage].BtnAddToList;
                Todo_DatePicker_Check.Content = language.langs[currentLanguage].Date;
            }

            void themeChanger(int i)
            {
                currentThemeColor = i;
                // guiMainWindow.Background        = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
                Button_AddToDo.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
                Button_AddToDo.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
                //Button_Setting.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
                //Button_Setting.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
                Button_RemoveToDo.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
                Button_RemoveToDo.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
                ToDoList_Stack.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Stack_bg);
                ToDo_TextInput.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_fg);
                ToDo_TextInput.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_bg);
                Todo_DatePicker.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_fg);
                Todo_DatePicker.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_bg);
                Todo_DatePicker_Check.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Stack_fg);

                foreach (var child in ToDoList_Stack.Children)
                {
                    if (child is CheckBox checkBox)
                    {
                        if (checkBox.Content is TextBlock textBlock)
                        {
                            textBlock.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Stack_fg);
                        }
                    }
                }
                /*
                for (int j = 0; j < VisualTreeHelper.GetChildrenCount(Todo_DatePicker); j++)
                {
                    var child = VisualTreeHelper.GetChild(Todo_DatePicker, j);
          
                    if (child is DatePickerTextBox textBox)
                    {
                        // Modify the properties directly
                        MessageBox.Show("zmiana koloru");
                        textBox.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_fg);
                        textBox.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnTextColour_bg);
                        break; 
                    }
                }
                */
                // ^^^^^^^^^^^^^^^^^^ THAT'S DONT WORK !!!!!!!!!!!!!!!!!!!!!!!!!
                // IT FINDS ONLY BORDER, NOT TEXT BOX <--- NEED TO BE FIXED!!!!!
            }
        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            // Change language and color every 5 seconds :)
            if (_counter >= 2)
            {
                _counter = 0;
              //  GlobalSettings.Language = _counter;
              //  GlobalSettings.Theme = _counter;
            }
            else
            {
                _counter++;
              //  GlobalSettings.Language = _counter;
              //  GlobalSettings.Theme = _counter;
                //MessageBox.Show(_counter.ToString());
            }
            // ^^^ FUNCTION TESTER !!! REMOVE BEFORE FLIGHT !!!
        }

        private void UpdateStackPanel()
        {
            // Save existing list to file
            TasksHandler.SaveToFile(TasksHandler.toDo_Events, GlobalSettings.FilePath);
            // Clear existing children in the StackPanel
            ToDoList_Stack.Children.Clear();
            // Iterate over each item in the list
            for (int i = 0; i < TasksHandler.toDo_Events.Count; i++)
            {
                int ID = i + 1;
                TasksHandler.toDo_Events[i].ID = ID;
                string contentText = "";
                string strID = ID.ToString();

                if (TasksHandler.toDo_Events[i].HasDate)
                {
                    double LeftDays = TasksHandler.toDo_Events[i].recalculateDaysToTaskEnd();
                    string sLeftDays = LeftDays.ToString();
                    string ToDoText = TasksHandler.toDo_Events[i].Task;
                    string sEventDate = TasksHandler.toDo_Events[i].TaskDate.ToShortDateString();
                    contentText = strID + ".   " + ToDoText + " - " + sEventDate + " (" + sLeftDays + ")";
                    //MessageBox.Show("update");
                }
                else
                {
                    contentText = strID + ".   " + TasksHandler.toDo_Events[i].Task;
                }

                // Create a new TextBlock for each item
                CheckBox toDoItem = new CheckBox
                {
                    Content = new TextBlock
                    {
                        Text = contentText,
                        //Margin = new Thickness(2),
                        Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Stack_fg)

                    },
                    Name = "ID_" + TasksHandler.toDo_Events[i].ID,
                    IsChecked = false,
                    IsThreeState = false,
                    Margin = new Thickness(2)


                };

                // Add the TextBlock to the StackPanel
                ToDoList_Stack.Children.Add(toDoItem);
            }
        }

        private void Button_AddToDo_Click(object sender, RoutedEventArgs e)
        {
            // DataContext = new MyViewModel();
            int ID;
            string ToDoText = ToDo_TextInput.Text;
            if (!string.IsNullOrEmpty(ToDoText))
            {
                ID = TasksHandler.toDo_Events.Count + 1;
                string strID = ID.ToString();
                string sEventDate = "";
                DateTime EventDate = DateTime.Now;
                bool tempHasDate = false;



                if (Todo_DatePicker.SelectedDate.HasValue)
                {
                    EventDate = Todo_DatePicker.SelectedDate.Value;
                    sEventDate = Todo_DatePicker.SelectedDate.Value.ToShortDateString();
                }
                double LeftDays = Math.Ceiling((Todo_DatePicker.SelectedDate.GetValueOrDefault() - DateTime.Now).TotalDays);
                string sLeftDays = LeftDays.ToString();
                if (Todo_DatePicker_Check.IsChecked.HasValue)
                {
                    if (Todo_DatePicker_Check.IsChecked == true)
                    {
                        if (LeftDays >= 0)
                        {
                            tempHasDate = true;
                        }
                        else
                        {
                            tempHasDate = false;
                            MessageBox.Show(language.langs[currentLanguage].MessDateFromPast);
                        }
                    }
                    else
                    {
                        tempHasDate = false;
                    }
                }


                TasksHandler.AddTask(ID, ToDoText, tempHasDate, EventDate);
                UpdateStackPanel();
                ToDo_TextInput.Clear();
                Todo_DatePicker_Check.IsChecked = false;

            }
        }

        private void Button_RemoveToDo_Click(object sender, RoutedEventArgs e)
        {

            int currentLanguage = GlobalSettings.Language;
            int currentThemeColor = GlobalSettings.Theme;
            int deleteCount = 0;
            int[] eventToDelete = new int[1000];
            for (int i = 0; i < eventToDelete.Length; i++)
            {
                eventToDelete[i] = 9999;
            }
            //MessageBox.Show("This button will remove ToDo Tasks!");
            foreach (var child in ToDoList_Stack.Children)
            {
                if ((child is CheckBox checkBox) && (checkBox.IsChecked.HasValue) && (checkBox.IsChecked.Value == true && deleteCount < 1000))
                {
                    string result = checkBox.Name.Substring(3, (checkBox.Name.Length - 3));
                    int elementToDeleteID;
                    if (int.TryParse(result, out elementToDeleteID) == true)
                    {
                        eventToDelete[deleteCount] = elementToDeleteID - 1;
                        deleteCount++;
                    }
                }
            }
            TasksHandler.RemoveTask(deleteCount, eventToDelete);
            UpdateStackPanel();
            deleteCount = 0;
            for (int i = 0; i < eventToDelete.Length; i++)
            {
                eventToDelete[i] = 9999;
            }
        }
    }
}
