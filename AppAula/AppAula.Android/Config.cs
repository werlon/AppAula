using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using SQLite.Net.Interop;
using AppAula.Model;

[assembly: Dependency(typeof(AppAula.Android.Config))]

namespace AppAula.Android
{
    class Config : IConfig
    {
        private string _diretorioDB;
        private ISQLitePlatform _plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }
    }
}