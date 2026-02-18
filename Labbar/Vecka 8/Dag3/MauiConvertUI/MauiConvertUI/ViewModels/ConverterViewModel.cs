using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiConvertUI.ViewModels
{
    public class ConverterViewModel : BindableObject
    {
        private string inputValue;
        private string selectedConversion;
        // Texten som användaren skriver in
        public string InputValue
        {
            get => inputValue;
            set { inputValue = value; OnPropertyChanged(); }
        }
        // Historiklista som visas i UI
        public ObservableCollection<string> History { get; set; } = new();
        // Picker-alternativ
        public ObservableCollection<string> ConversionOptions { get; } = new()
        {
            "Feet → Meter",
            "Meter → Feet"
        };
        // Vald option i Picker
        public string SelectedConversion
        {
            get => selectedConversion;
            set { selectedConversion = value; OnPropertyChanged(); }
        }
        // Command som kör vald omvandling
        public ICommand ConvertCommand { get; }
        public ConverterViewModel()
        {
            ConvertCommand = new Command(OnConvert);
        }

        // Metod som körs när användaren klickar på "Konvertera"
        private void OnConvert()
        {
            if (string.IsNullOrEmpty(SelectedConversion) || string.IsNullOrEmpty(InputValue))
            {
                History.Add("Välj en omvandling och ange ett värde!");
                return;
            }
            if (SelectedConversion == "Feet → Meter")
            {
                if (double.TryParse(InputValue, out double feet))
                    History.Add($"{feet} feet = {feet * 0.3048:F2} meter");
                else
                    History.Add("Ogiltigt värde!");
            }
            else if (SelectedConversion == "Meter → Feet")
            {
                if (double.TryParse(InputValue, out double meters))
                    History.Add($"{meters} meter = {meters / 0.3048:F2} feet");
                else
                    History.Add("Ogiltigt värde!");
            }
        }

        /*  
        public class ConverterViewModel : BindableObject
        {
            private string inputValue; // lagrar texten från Entry
            public string InputValue
            {
                get => inputValue;
                set { inputValue = value; OnPropertyChanged(); }
            }
            // Historiklista som UI kan visa via binding
            public ObservableCollection<string> History { get; set; } = new();
            // Commands för knapparna
            public ICommand FeetToMeterCommand { get; }
            public ICommand MeterToFeetCommand { get; }
            public ConverterViewModel()
            {
                // Sätt upp kommandon och koppla till metoder
                FeetToMeterCommand = new Command(OnFeetToMeter);
                MeterToFeetCommand = new Command(OnMeterToFeet);
            }
            private void OnFeetToMeter()
            {
                if (double.TryParse(InputValue, out double feet))
                    History.Add($"{feet} feet = {feet * 0.3048:F2} meter");
                else
                    History.Add("Ogiltigt värde!");
            }
            private void OnMeterToFeet()
            {
                if (double.TryParse(InputValue, out double meters))
                    History.Add($"{meters} meter = {meters / 0.3048:F2} feet");
                else
                    History.Add("Ogiltigt värde!");
            } 
        }   */
    }
}


