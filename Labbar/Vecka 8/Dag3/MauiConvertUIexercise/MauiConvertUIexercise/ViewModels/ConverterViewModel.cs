// using GameController;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Text;
using System.Windows.Input;

namespace MauiConvertUIexercise.ViewModels
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
            "Meter → Feet",
            "Miles → Kilometers",
            "Kilometers → Miles",
            "Stones → Kg",
            "Kg → Stones"
        };
        // Vald option i Picker
        public string SelectedConversion
        {
            get => selectedConversion;
            set { selectedConversion = value; OnPropertyChanged(); }
        }
        // Command som kör vald omvandling
        public ICommand ConvertCommand { get; }
        public ICommand CloseCommand { get; }
        public ConverterViewModel()
        {
            ConvertCommand = new Command(OnConvert);
            CloseCommand = new Command(OnClose);
        }

        private void OnClose()
        {
            Application.Current.Quit();
        }

        // Metod som körs när användaren klickar på "Konvertera"
        private void OnConvert()
        {
            if (string.IsNullOrEmpty(SelectedConversion) || string.IsNullOrEmpty(InputValue))
            {
                History.Add("Välj en omvandling och ange ett värde!");
                return;
            }
            double convertedValue;

            switch (SelectedConversion)
            {
                case "Feet → Meter":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} feet = {convertedValue * 0.3048:F2} meter");
                    break;
                case "Meter → Feet":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} meter = {convertedValue / 0.3048:F2} feet");
                    break;
                case "Miles → Kilometers":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} miles = {convertedValue * 1.609344:F2} kilometres");
                    break;
                case "Kilometers → Miles":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} kilometres = {convertedValue * 0.621371:F2} miles");
                    break;
                case "Stones → Kg":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} stones = {convertedValue * 6,3503:F2} kg");
                    break;
                case "Kg → Stones":
                    if (double.TryParse(InputValue, out convertedValue))
                        History.Add($"{convertedValue} kg = {convertedValue * 0,157473:F2} stones");
                    break;
                default:
                    History.Add("Ogiltigt värde!");
                    break;
            }           
        }        
    }
}

