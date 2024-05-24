using System;                             
using System.Reactive;                    
using ACalc.Models;                       
using ReactiveUI;                         

namespace ACalc.ViewModels                
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _firstValue;                // Przechowuje pierwszą wartość operacji
        private double _secondValue;               // Przechowuje drugą wartość operacji
        private Operation _operation = Operation.Add; // Przechowuje bieżącą operację, domyślnie dodawanie

        // Właściwość powiązana z wyświetlaną wartością
        public double ShownValue
        {
            get => _secondValue;                   // Pobiera drugą wartość operacji
            set => this.RaiseAndSetIfChanged(ref _secondValue, value); // Ustawia drugą wartość operacji i powiadamia o zmianie
        }

        // Komendy reaktywne
        public ReactiveCommand<int, Unit> AddNumberCommand { get; }       // Komenda do dodawania liczby
        public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; } // Komenda do usuwania ostatniej cyfry
        public ReactiveCommand<Operation, Unit> ExecuteOperationCommand { get; } // Komenda do wykonywania operacji

        // Konstruktor
        public MainWindowViewModel()
        {
            // Tworzy komendy reaktywne
            AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);           // Tworzy komendę do dodawania liczby
            ExecuteOperationCommand = ReactiveCommand.Create<Operation>(ExecuteOperation); // Tworzy komendę do wykonywania operacji
            RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);  // Tworzy komendę do usuwania ostatniej cyfry
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(          // Ustawia domyślnego obsługiwacza wyjątków
                ex => Console.Write("next"),                                     // Akcja dla następnego wyjątku
                ex => Console.Write("Unhandled rxui error"));                    // Akcja dla nieobsłużonego wyjątku
        }

        // Dodaje liczbę do bieżącej wartości
        private void AddNumber(int value)
        {
            ShownValue = ShownValue * 10 + value; // Mnoży bieżącą wartość przez 10 i dodaje nową cyfrę
        }

        // Czyści ekran kalkulatora
        public void ClearScreen()
        {
            ShownValue = 0;                 // Resetuje wyświetlaną wartość do 0
            _operation = Operation.Add;     // Ustawia operację na dodawanie
            _firstValue = 0;                // Resetuje pierwszą wartość operacji do 0
        }

        // Zamyka aplikację
        public void Exit()
        {
            Environment.Exit(0);            // Wywołuje zamknięcie aplikacji z kodem wyjścia 0
        }

        // Usuwa ostatnią cyfrę z bieżącej wartości
        public void RemoveLastNumber()
        {
            ShownValue = (int)ShownValue / 10; // Usuwa ostatnią cyfrę przez podzielenie przez 10
        }

        // Wykonuje bieżącą operację
        private void ExecuteOperation(Operation operation)
        {
            switch (_operation)            // Wybiera operację na podstawie bieżącej wartości _operation
            {
                case Operation.Add:        // Przypadek dodawania
                    {
                        _firstValue += _secondValue; // Dodaje drugą wartość do pierwszej
                        ShownValue = 0;         // Resetuje wyświetlaną wartość do 0
                        break;                  // Kończy przypadek
                    }
                case Operation.Subtract:    // Przypadek odejmowania
                    {
                        _firstValue -= _secondValue; // Odejmuje drugą wartość od pierwszej
                        ShownValue = 0;         // Resetuje wyświetlaną wartość do 0
                        break;                  // Kończy przypadek
                    }
                case Operation.Multiply:    // Przypadek mnożenia
                    {
                        _firstValue *= _secondValue; // Mnoży pierwszą wartość przez drugą
                        ShownValue = 0;         // Resetuje wyświetlaną wartość do 0
                        break;                  // Kończy przypadek
                    }
                case Operation.Divide:      // Przypadek dzielenia
                    {
                        _firstValue /= _secondValue; // Dzieli pierwszą wartość przez drugą
                        ShownValue = 0;         // Resetuje wyświetlaną wartość do 0
                        break;                  // Kończy przypadek
                    }
            }

            if (operation == Operation.Result) // Sprawdza, czy operacja to wynik
            {
                ShownValue = _firstValue;   // Ustawia wyświetlaną wartość na pierwszą wartość
                _operation = Operation.Add; // Resetuje operację do dodawania
                _firstValue = 0;            // Resetuje pierwszą wartość do 0
            }
            else
            {
                _operation = operation;     // Ustawia bieżącą operację na nową operację
            }
        }
    }
}
