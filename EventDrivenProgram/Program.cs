using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenProgram
{
    public class Window
    {
        Button _btn = new Button();
        TextBox _text = new TextBox();

        public Window()
        {
            //this._btn.Add_Click(new Action(this.Button_Click_Handler));
            this._btn.Click += this.Button_Click_Handler;
            this._btn.Click += () => { this._text.Clear(); };
        }
        public void CaptureButtonClick()
        {
            _btn.OnClick();
            
        }

        void Button_Click_Handler()
        {
            this._text.Clear();
        }

    }

    //Observable
    public class Button
    {
        //Events
        public event Action Click = null;
        public void OnClick()
        {
            if (Click != null)
            {
                //Raise 
                Click.Invoke(); //Click();
            }
        }
    }

    public class TextBox
    {

        public void Clear()
        {
            Console.WriteLine("Text Box Content Cleared");
        }
    }
    class Program
    {
        static void  Main(string[] args)
        {
            Window _window = new Window();
            while(true)
            {
                Console.WriteLine("Press Any Key To Press Button");
                Console.ReadKey();
                _window.CaptureButtonClick();

            }
        }
    }
}
