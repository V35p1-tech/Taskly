using System.Windows;
using System.Windows.Media;

namespace Taskly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LangHandling language = new LangHandling();
        private ColorThemeHandling colorTheme = new ColorThemeHandling();
        private int currentLanguage;
        private int currentThemeColor;
        private SettingsFileHandling fileHandling = new SettingsFileHandling();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new ToDoList());
            GlobalSettings.OnLanguageChanged += langChanger;
            GlobalSettings.OnThemeChanged += themeChanger;
            Button_Setting.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
            Button_Setting.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
            MainFrame.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
            Button_Setting.Content = language.langs[currentLanguage].BtnSettings;
            var (int1, int2) = fileHandling.Load();
            GlobalSettings.Language = int1;
            GlobalSettings.Theme = int2;
            currentLanguage = GlobalSettings.Language;
            currentThemeColor = GlobalSettings.Theme;
     
            void langChanger(int i)
            {
                currentLanguage = i;
                if (GlobalSettings.CurrentPage == 0)
                {
                    Button_Setting.Content = language.langs[currentLanguage].BtnSettings;
                }
                else if (GlobalSettings.CurrentPage == 1)
                {
                    Button_Setting.Content = language.langs[currentLanguage].BtnSettingsToDo;
                }
            }

            void themeChanger(int i)
            {
                currentThemeColor = i;
                MainFrame.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
                Button_Setting.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
                Button_Setting.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
            }
        }

        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            int currentLanguage = GlobalSettings.Language;
            int currentThemeColor = GlobalSettings.Theme;

            if (GlobalSettings.CurrentPage == 1)
            {
                MainFrame.NavigationService.Navigate(new ToDoList());
                Button_Setting.Content = language.langs[currentLanguage].BtnSettings;
            }
            else if (GlobalSettings.CurrentPage == 0)
            {
                MainFrame.NavigationService.Navigate(new Settings());
                Button_Setting.Content = language.langs[currentLanguage].BtnSettingsToDo;
            }
            else
                MainFrame.NavigationService.Navigate(new ToDoList());
        }
    }
}