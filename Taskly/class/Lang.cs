namespace Taskly
{
    public class Lang
    {
        private readonly string _name;
        private readonly string _btnAddToList;
        private readonly string _btnRemoveFromList;
        private readonly string _btnSettings;
        private readonly string _date;
        private readonly string _st_newToDo_added;
        private readonly string _messDateFromPast;
        private readonly string _btnSettings_ToDo;
        private readonly string _lang;
        private readonly string _theme;
        private readonly string _selectedItem;

        public string Name
        {
            get { return _name; }
            init { _name = value; }
        }

        public string BtnAddToList
        {
            get { return _btnAddToList; }
            init { _btnAddToList = value; }
        }

        public string BtnRemoveFromList
        {
            get { return _btnRemoveFromList; }
            init { _btnRemoveFromList = value; }
        }

        public string BtnSettings
        {
            get { return _btnSettings; }
            init { _btnSettings = value; }
        }

        public string Date
        {
            get { return _date; }
            init { _date = value; }
        }

        public string StNewToDoAdded
        {
            get { return _st_newToDo_added; }
            init { _st_newToDo_added = value; }
        }

        public string MessDateFromPast
        {
            get { return _messDateFromPast; }
            init { _messDateFromPast = value; }
        }

        public string BtnSettingsToDo
        {
            get { return _btnSettings_ToDo; }
            init { _btnSettings_ToDo = value; }
        }

        public string Language
        {
            get { return _lang; }
            init { _lang = value; }
        }

        public string Theme
        {
            get { return _theme; }
            init { _theme = value; }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            init { _selectedItem = value; }
        }

        public Lang(string LangName, string trAddToList, string trRemoveFromList, string trSettings, string transDate, string trNewToDo_added, string trMessDateFromPast, string trSettings_moveToTodo, string trLanguage, string trTheme, string trSelectedItem)
        {
            Name = LangName;
            BtnAddToList = trAddToList;
            BtnRemoveFromList = trRemoveFromList;
            BtnSettings = trSettings;
            Date = transDate;
            StNewToDoAdded = trNewToDo_added;
            MessDateFromPast = trMessDateFromPast;
            BtnSettingsToDo = trSettings_moveToTodo;
            Language = trLanguage;
            Theme = trTheme;
            SelectedItem = trSelectedItem;
        }
    }
}