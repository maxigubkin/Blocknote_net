using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace Blocknote
{
    public class TxtFile : INotifyPropertyChanged
    {
        public TxtFile()
        {
            FileName = "Noname";
            Contents = "";
        }

        private bool saved;

        private string fontFamily;
        public string FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {
                fontFamily = value;
                OnPropertyChanged("FontFamily");
            }
        }

        private double fontSize;
        public double FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }

        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        private string contents;
        public string Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
                this.saved = false;
                OnPropertyChanged("Contents");
            }
        }

        public bool SaveCheck()
        {
            if (Contents.Length > 0 && this.saved == false)
            {
                string messageBoxText = "Do you want to save changes to file?";
                string caption = "Blocknote";
                MessageBoxButton msgboxbutton = MessageBoxButton.YesNoCancel;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, msgboxbutton);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        return SaveFile();
                    case MessageBoxResult.No:
                        return true;
                    case MessageBoxResult.Cancel:
                        return false;
                }
                return false;
            }
            return true;
        }

        public bool SaveFile(bool newfile = false)
        {
            if (this.FileName.Length > 0 && this.FileName != "Noname" && newfile == false)
            { 
                return WriteSave();
            }
            else
            { 
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == true)
                {
                    this.FileName = save.FileName;
                    return WriteSave();
                }
                return false;
            }
        }

        public bool OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text File | *.txt";
            if (open.ShowDialog() == true)
            {
                try
                {
                    this.FileName = open.FileName;
                    this.Contents = File.ReadAllText(this.FileName);
                    this.saved = true;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return false;
        }

        private bool WriteSave()
        {
            try
            {
                File.WriteAllText(fileName, contents);
                this.saved = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
