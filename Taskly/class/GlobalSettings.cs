namespace Taskly
{
    public static class GlobalSettings
    {
        private static int _languageIndex = 0;
        private static int _themeIndex = 0;
        private static string _filePath = Properties.Settings.Default.FilePath;
        private static string _settingsFilePath = Properties.Settings.Default.SettingFilePath;
        private static int _currentPage = 0;

        public static string FilePath
        {
            get { return _filePath; }
        }

        public static string SettingsFilePath
        {
            get { return _settingsFilePath; }
        }

        public static int Language
        {
            get { return _languageIndex; }
            set
            {
                if (_languageIndex != value)
                {
                    _languageIndex = value;
                    OnLanguageChanged?.Invoke(_languageIndex);
                }
            }
        }

        public static event Action<int> OnLanguageChanged;

        public static int Theme
        {
            get => _themeIndex;
            set
            {
                if (_themeIndex != value)
                {
                    _themeIndex = value;
                    OnThemeChanged?.Invoke(_themeIndex);
                }
            }
        }

        public static int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                }
            }
        }

        public static event Action<int> OnThemeChanged;
    }
}