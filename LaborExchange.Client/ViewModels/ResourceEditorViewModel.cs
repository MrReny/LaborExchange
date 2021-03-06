using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using LaborExchange.Client.Base;
using LaborExchange.Client.Model;
using LaborExchange.Client.Themes;
using NLog;

namespace LaborExchange.Client
{
    public class ResourceEditorViewModel:ViewModelBase
    {
        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ResourceDictionary Style { get; set; }

        public ObservableCollection<DictionaryEntry> Properties { get; set; }

        private DictionaryEntry _selectedProperty;
        private SolidColorBrush _selectedColor;

        public DictionaryEntry SelectedProperty
        {
            get => _selectedProperty;
            set
            {
                if(_selectedProperty.Key == value.Key) return;
                _selectedProperty = value;
                SelectedColor = (SolidColorBrush)_selectedProperty.Value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush SelectedColor
        {
            get => _selectedColor;
            set
            {
                if(_selectedColor == value) return;
                _selectedColor= value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SetColor { get; set; }

        public DelegateCommand SetStyle { get; set; }

        public string ValueType { get; set; }

        public ResourceEditorViewModel()
        {
            BuildType();

            SetColor = new DelegateCommand(
                () =>
                {
                    try
                    {
                        var index = Properties.IndexOf(_selectedProperty);
                        _selectedProperty.Value = _selectedColor;
                        Properties[index] = _selectedProperty;
                        ApplyStyle();

                    }
                    catch(Exception e)
                    {
                        _logger.Error(e);
                    }

                });

            SetStyle = new DelegateCommand(
                () =>
                {
                    try
                    {

                        ApplyStandardStyle();

                    }
                    catch(Exception e)
                    {
                        _logger.Error(e);
                    }

                });
        }

        private void ApplyStandardStyle()
        {
            try
            {
                var m = typeof(ThemeTypes)
                    .GetMembers().FirstOrDefault(m => m.GetCustomAttributes(typeof(DescriptionAttribute), true)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault()
                        ?.Description == ValueType);
                ThemesController.SetTheme((ThemeTypes)Enum.Parse(typeof(ThemeTypes), m?.Name));
                BuildType();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

        }

        private void ApplyStyle()
        {
            foreach (var de in Properties)
            {
                Style[de.Key] = de.Value; //de.Value;
            }

            var old = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(r => r.Source.OriginalString.Contains(Style.Source.OriginalString));

            var index = Application.Current.Resources.MergedDictionaries.IndexOf(old);
            Application.Current.Resources.MergedDictionaries[index<0? 0: index] = Style;
        }

        private void BuildType()
        {
            Style = ThemesController.GetTheme(ThemesController.CurrentTheme);

            var lst = new List<DictionaryEntry>();
            foreach (var dictEntry in Style)
            {
                var r = (DictionaryEntry)dictEntry;
                if(r.Value is SolidColorBrush) lst.Add(r);
            }
            Properties = new ObservableCollection<DictionaryEntry>(lst);

            SelectedProperty = Properties[0];
        }
    }
}