using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace Taskly
{
    public class ColorTheme
    {
        private readonly string _name;
        private readonly Color _btnColour_bg; // 0,0,0,0 - black
        private readonly Color _btnColour_fg;
        private readonly Color _textBoxColour_bg;
        private readonly Color _textBoxColour_fg;
        private readonly Color _background;
        private readonly Color _stack_bg;
        private readonly Color _stack_fg;
        private readonly Color _textOnBackground;

        public required string Name {
            get { return _name; }
            init { _name = value; }
        }
        /// <summary>  Color.FromArgb(255, 255, 255, 0) - BLACK; 
        /// Color.FromArgb(0, 0, 0, 0) - WHITE </summary> 
        public required Color BtnColour_bg {
            get { return _btnColour_bg; }
            init { _btnColour_bg = value; }
        }
        /// <summary>  0,0,0,0 - black  </summary>  
        public required Color BtnColour_fg
        {
            get { return _btnColour_fg; }
            init { _btnColour_fg = value; }
        } 
        /// <summary>  0,0,0,0 - black  </summary> 
        public required Color BtnTextColour_bg
        {
            get { return _textBoxColour_bg; }
            init { _textBoxColour_bg = value; }
        }
        /// <summary>  0,0,0,0 - black  </summary> 
        public required Color BtnTextColour_fg
        {
            get { return _textBoxColour_fg; }
            init { _textBoxColour_fg = value; }
        }
        /// <summary>  0,0,0,0 - black  </summary> 
        public required Color Background
        {
            get { return _background; }
            init { _background = value; }
        } 
        /// <summary>  0,0,0,0 - black  </summary> 
        public required Color Stack_bg
        {
            get { return _stack_bg; }
            init { _stack_bg = value; }
        } 
        /// <summary>  0,0,0,0 - black  </summary> 
        public required Color Stack_fg
        {
            get { return _stack_fg; }
            init { _stack_fg = value; }
        }

        public required Color TextOnBackground
        {
            get { return _textOnBackground; }
            init { _textOnBackground = value; }
        }
    }

        /*
        public ColorTheme (string Name, Color btnColour_bg, Color btnColour_fg, string textBoxColour_bg, string textBoxColour_fg, string Background, string Stack_bg, string Stack_fg)
        {
            this.Name = Name;
            _btnColour_bg = btnColour_bg;
            _btnColour_fg = btnColour_fg;
            _textBoxColour_bg = textBoxColour_bg;
            _textBoxColour_fg = textBoxColour_fg;
            _background = Background;
            _stack_bg = Stack_bg;
            _stack_fg = Stack_fg;

        }
        */
    
}
