using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Taskly
{
    public class ColorThemeHandling
    {
   
           public readonly ColorTheme defaultTheme = new ColorTheme
            {
                Name = "default",
                BtnColour_bg = Color.FromArgb(255, 255, 255, 255),
                BtnColour_fg = Color.FromArgb(255, 255, 255, 255),
                BtnTextColour_bg = Color.FromArgb(255, 0, 0, 0),
                BtnTextColour_fg = Color.FromArgb(255, 255, 255, 255),
                Background = Color.FromArgb(255, 0, 0, 0),
                Stack_bg = Color.FromArgb(255, 255, 255, 255),
                Stack_fg = Color.FromArgb(255, 10, 10, 10),
                TextOnBackground = Color.FromArgb(255, 250, 250 ,250)
           };

    
        
        
            // COLOR THEMES
            public readonly ColorTheme[] colorThemes =
            {
                    new ColorTheme
                    {
                        Name = "Dark",
                        BtnColour_bg = Color.FromArgb(255, 30, 30, 30),
                        BtnColour_fg = Color.FromArgb(255, 200, 200, 200),
                        BtnTextColour_bg = Color.FromArgb(255, 15, 15, 15),
                        BtnTextColour_fg = Color.FromArgb(255, 130, 130, 130),
                        Background = Color.FromArgb(255, 45, 45, 48),
                        Stack_bg = Color.FromArgb(255, 50, 50, 50),
                        Stack_fg = Color.FromArgb(255, 200, 200, 200),
                        TextOnBackground = Color.FromArgb(255, 250, 250 ,250)
                    },
                    new ColorTheme
                    {
                        Name = "Light",
                        BtnColour_bg = Color.FromArgb(255, 235, 235, 235),
                        BtnColour_fg = Color.FromArgb(255, 5, 5, 5),
                        BtnTextColour_bg = Color.FromArgb(255, 150, 150, 150),
                        BtnTextColour_fg = Color.FromArgb(255, 25, 25, 25),
                        Background = Color.FromArgb(255, 155, 155, 155),
                        Stack_bg = Color.FromArgb(255, 222, 222, 222),
                        Stack_fg = Color.FromArgb(255, 22, 22, 22),
                        TextOnBackground = Color.FromArgb(255, 33, 33 ,33)
                    },

                    new ColorTheme
                    {
                        Name = "Blue",
                        BtnColour_bg = Color.FromArgb(255, 245, 198, 41), 
                        BtnColour_fg = Color.FromArgb(255, 49, 58, 61), 
                        BtnTextColour_bg = Color.FromArgb(255, 88, 187, 220), 
                        BtnTextColour_fg = Color.FromArgb(255, 49, 73, 82), 
                        Background = Color.FromArgb(255, 53, 113, 133), 
                        Stack_bg = Color.FromArgb(255, 49, 73, 82), 
                        Stack_fg = Color.FromArgb(255, 245, 198, 41),
                        TextOnBackground = Color.FromArgb(255, 22, 22 ,66)
                    },

                    new ColorTheme
                    {
                        Name = "Red",
                        BtnColour_bg = Color.FromArgb(255, 244, 64, 18), 
                        BtnColour_fg = Color.FromArgb(255, 55, 75, 68), 
                        BtnTextColour_bg = Color.FromArgb(255, 201, 81, 56), 
                        BtnTextColour_fg = Color.FromArgb(255, 0,0,0),//120, 77, 66), 
                        Background = Color.FromArgb(255, 120, 77, 66), 
                        Stack_bg = Color.FromArgb(255, 181, 83, 58), 
                        Stack_fg = Color.FromArgb(255, 25, 45, 38),
                        TextOnBackground = Color.FromArgb(255, 122, 188 ,122)
                    }
            };
        
    }
}
