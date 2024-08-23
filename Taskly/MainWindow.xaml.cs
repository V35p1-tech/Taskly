using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Permissions;
using System.Configuration;
using System.Windows.Threading;
using System.Text.Json;

namespace Taskly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LangHandling language = new LangHandling();
        ColorThemeHandling colorTheme = new ColorThemeHandling();
        private int currentLanguage;
        private int currentThemeColor;
        SettingsFileHandling fileHandling = new SettingsFileHandling();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new ToDoList());
            GlobalSettings.OnLanguageChanged += langChanger;
            GlobalSettings.OnThemeChanged += themeChanger;
            bool init = true;
            if (init)
            {
                Button_Setting.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_fg);
                Button_Setting.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].BtnColour_bg);
                MainFrame.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
                Button_Setting.Content = language.langs[currentLanguage].BtnSettings;
                var (int1, int2) = fileHandling.Load();
                GlobalSettings.Language = int1;
                GlobalSettings.Theme = int2;
                currentLanguage = GlobalSettings.Language;
                currentThemeColor = GlobalSettings.Theme;
                init = false;
            }
           

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
            };

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
            else if(GlobalSettings.CurrentPage == 0)
                {
                    MainFrame.NavigationService.Navigate(new Settings());
                    Button_Setting.Content = language.langs[currentLanguage].BtnSettingsToDo;
            }
            else
                {
                    MainFrame.NavigationService.Navigate(new ToDoList());
                }
        }
    }   
}
