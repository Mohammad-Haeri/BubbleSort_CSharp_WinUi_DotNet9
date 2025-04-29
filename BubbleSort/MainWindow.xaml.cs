using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BubbleSort.Model;
using BubbleSort.WindowExtensions;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace BubbleSort
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : DesktopWindow
    {
        /// <summary>
        /// Observable collection contain generated random value for further sorting.
        /// </summary>
        private ObservableCollection<Item> _list = [];

        /// <summary>
        /// Current is sorted status of _list
        /// </summary>
        private bool _isSorted = false;

        public MainWindow()
        {
            this.InitializeComponent();
            this.ExtendsContentIntoTitleBar = true;
            if (this.AppWindow.Presenter is OverlappedPresenter overlappedPresenter)
            {
                overlappedPresenter.IsResizable = false;
                overlappedPresenter.IsMaximizable = false;
            }

        }

        /// <summary>
        /// Generate random value and add them to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRandomValueGereatorButtonsClick(object sender, RoutedEventArgs e)
        {
            _list.Clear();

            Random random = new();
            for (int i = 0, j = 200; i < j; i++)
            {
                _list.Add(new Item() { Value = random.Next(1, 999) });
            }
            _isSorted = false;
        }

        /// <summary>
        /// Clear the list from generated values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResetButtonsClick(object sender, RoutedEventArgs e)
        {
            _list.Clear();
            _isSorted = false;
        }

        /// <summary>
        /// Sort the list by bubblesort algorithm and use tupple for swaping(cleaner)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSortUseTuppleButtonClick(object sender, RoutedEventArgs e)
        {
            if (!_isSorted)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    for (int j = 0; j < _list.Count - i - 1; j++)
                    {
                        if (_list[j].Value > _list[j + 1].Value)
                        {
                            (_list[j], _list[j + 1]) = (_list[j + 1], _list[j]);
                        }
                    }
                }

                _isSorted = true;
            }
        }

        /// <summary>
        /// Sort the list by bubblesort algorithm and use temp variable for swaping(faster)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSortUseTempVarButtonClick(object sender, RoutedEventArgs e)
        {
            if (!_isSorted)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    for (int j = 0; j < _list.Count - i - 1; j++)
                    {
                        if (_list[j].Value > _list[j + 1].Value)
                        {
                            Item item = _list[j + 1];
                            _list[j + 1] = _list[j];
                            _list[j] = item;
                        }
                    }
                }

                _isSorted = true;
            }
        }
    }
}
