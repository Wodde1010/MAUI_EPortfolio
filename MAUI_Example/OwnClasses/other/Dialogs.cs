using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Example1
{
    class Dialogs{


        public Dialogs(){
            options[0] = "Welcome to .Net MAUI!";
            options[1] = "multiple platforms";
            options[2] = "Hot-reload";
            options[3] = "migrate existing Xamarin apps";
            
        }
        private string[] options = new string[size];
        private static uint size = 4;


        public string getOption(uint index){
            return options[index%size];
        }
    }
}