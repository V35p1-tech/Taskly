using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Taskly
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        LangHandling language = new LangHandling();
        ColorThemeHandling colorTheme = new ColorThemeHandling();
        SettingsFileHandling fileHandling = new SettingsFileHandling();
        private int currentLanguage = GlobalSettings.Language;
        private int currentThemeColor = GlobalSettings.Theme;

        public Settings()
        {
            InitializeComponent();
            GlobalSettings.CurrentPage = 1;
            Settings_LangSelect_Text.Text = language.langs[currentLanguage].Language;
            Settings_Theme_Text.Text = language.langs[currentLanguage].Theme;
            Settings_LangSelect_ComboBox.Text = language.langs[currentLanguage].Name;
            Settings_Theme_ComboBox.Text = colorTheme.colorThemes[currentThemeColor].Name;
            Settings_LangSelect_Text.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].TextOnBackground);
            Settings_LangSelect_Text.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
            Settings_Theme_Text.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].TextOnBackground);
            Settings_Theme_Text.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);

            GlobalSettings.OnLanguageChanged += langChanger;
            GlobalSettings.OnThemeChanged += themeChanger;
            /*
            for (int i = 0; i < language.langs.Length; i++)
            {
                Settings_Language_ComboBox.Items.Add(language.langs[i].Name);
                var item = Settings_Language_ComboBox.Items[i];
                //  MessageBox.Show(item.ToString());
            }
            */
            for (int i = 0; i < colorTheme.colorThemes.Length; i++)
            {
                Settings_Theme_ComboBox.Items.Add(colorTheme.colorThemes[i].Name);
            }

            for (int i = 0; i < language.langs.Length; i++)
            {
                Settings_LangSelect_ComboBox.Items.Add(language.langs[i].Name);
            }

            void langChanger(int i)
            {
                currentLanguage = i;
                Settings_LangSelect_Text.Text = language.langs[currentLanguage].Language;
                Settings_Theme_Text.Text = language.langs[currentLanguage].Theme;
            }

            void themeChanger(int i)
            {
                currentThemeColor = i;
                Settings_LangSelect_Text.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].TextOnBackground);
                Settings_LangSelect_Text.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
                Settings_Theme_Text.Foreground = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].TextOnBackground);
                Settings_Theme_Text.Background = new SolidColorBrush(colorTheme.colorThemes[currentThemeColor].Background);
            }
        }

        private void Settings_Theme_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Get the selected item
            string selectedItem = comboBox.SelectedItem.ToString();
            GlobalSettings.Theme = comboBox.SelectedIndex;
            MessageBox.Show(language.langs[currentLanguage].SelectedItem + selectedItem);
            fileHandling.Save(GlobalSettings.Language, GlobalSettings.Theme);
        }

        private void Settings_LangSelect_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string selectedItem = comboBox.SelectedItem.ToString();
            GlobalSettings.Language = comboBox.SelectedIndex;
            MessageBox.Show(language.langs[currentLanguage].SelectedItem + selectedItem);
            fileHandling.Save(GlobalSettings.Language, GlobalSettings.Theme);
        }
    }
}