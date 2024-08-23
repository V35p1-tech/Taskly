using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Taskly
{
    class LangHandling
    {
        // Lang
        public Lang lang_default = new Lang("default", "Add to List", "Remove", "Settings", "Date", "Added: ", "Date from past", "Todo List", "Language", "Theme", "Selected Item: ");
         
        // LANGUAGES
         public readonly Lang[] langs =
         {
                        new Lang("English", "Add to List", "Remove", "Settings", "Date", "Added to list: ", "Date from past", "Todo List", "Language", "Theme", "Selected Item: "),
                        new Lang("Polski", "Dodaj do listy", "Usuń", "Ustawienia", "Data", "Dodano do listy: ","Data z przeszłości", "Lista Todo", "Język", "Motyw", "Wybrany element: "),
                        new Lang("Deutsch", "Zur Liste hinzufügen", "Entfernen", "Einstellungen", "Datum",  "Zur Liste: ", "Datum aus der Vergangenheit", "Aufgabenliste", "Sprache", "Thema", "Ausgewähltes Element: ")
         };
    }
}


