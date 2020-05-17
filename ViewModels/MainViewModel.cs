﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

using Hiker_Editor.Models;
using Hiker_Editor.Views;

namespace Hiker_Editor.ViewModels
{
    public enum Folders { Sprites = 0, Scripts = 1, Objects = 2, Rooms = 3 };
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _openAbout;
        private RelayCommand _openSettings;
        private RelayCommand _exitProgram;
        private RelayCommand _newProject;
        private RelayCommand _openProject;
        private RelayCommand _addObject;
        private RelayCommand _openProperties;
        public ObservableCollection<ProjectItem> StructureProject { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        
        public bool _isAvailableCreate = true;
        public bool _isAvailableRename = true;
        public bool _isAvailableDelete = true;
        public bool _isAvailableProperties = true;

        public string MainTitle
        {
            get
            {
                return "Hiker: <new game>";
            }
        }

        public bool IsAvailableCreate
        {
            get
            {
                return _isAvailableCreate;
            }
        }

        public bool IsAvailableRename
        {
            get
            {
                return _isAvailableRename;
            }
        }

        public bool IsAvailableDelete
        {
            get
            {
                return _isAvailableDelete;
            }
        }

        public bool IsAvailableProperties
        {
            get
            {
                return _isAvailableProperties;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindowViewModel()
        {
            StructureProject = ProjectItem.InitializationStructureProject();
        }


        public RelayCommand OpenAbout
        {
            get
            {
                return _openAbout ??
                  (_openAbout = new RelayCommand(obj =>
                  {
                      AboutWindow aboutWindow = new AboutWindow();
                      aboutWindow.Show();
                  }));
            }
        }

        public RelayCommand AddObject
        {
            get
            {
                return _addObject ??
                  (_addObject = new RelayCommand(obj =>
                  {
                      StructureProject[(int)Folders.Sprites].Items.Add(new Sprite());
                  }));
            }
        }

        public RelayCommand OpenProperties
        {
            get
            {
                return _openProperties ??
                  (_openProperties = new RelayCommand(obj =>
                  {
                      /*
                      Sprite sprite = new Sprite() { Name = "123" };
                      SpriteWindow spriteWindow = new SpriteWindow(ref sprite);
                      spriteWindow.Show();
                      */
                      GameObject go = new GameObject() { Name = "123" };
                      Sprite[] sprites = null;
                      GameObjectWindow spriteWindow = new GameObjectWindow(ref go, ref sprites);
                      spriteWindow.Show();
                  }));
            }
        }

        public RelayCommand OpenSettings
        {
            get
            {
                return _openSettings ??
                  (_openSettings = new RelayCommand(obj =>
                  {
                      SettingsWindow settingWindow = new SettingsWindow();
                      settingWindow.Show();
                  }));
            }
        }

        public RelayCommand ExitProgram
        {
            get
            {
                return _exitProgram ??
                  (_exitProgram = new RelayCommand(obj =>
                  {
                      Application.Current.Shutdown();
                  }));
            }
        }

        public RelayCommand NewProject
        {
            get
            {
                return _newProject ??
                  (_newProject = new RelayCommand(obj =>
                  {
                      //SaveFileDialog openFileDialog = new SaveFileDialog();
                      //openFileDialog.ShowDialog();
                  }));
            }
        }

        public RelayCommand OpenProject
        {
            get
            {
                return _openProject ??
                  (_openProject = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.ShowDialog();
                  }));
            }
        }
    }
}
