using System;
using System.IO;
using NarfuSchedule.Droid;
using NarfuSchedule.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace NarfuSchedule.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}