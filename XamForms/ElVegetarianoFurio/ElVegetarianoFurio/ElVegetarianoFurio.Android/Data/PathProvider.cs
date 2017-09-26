using System;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathProvider))]
namespace ElVegetarianoFurio.Droid.Data
{
    public class PathProvider : IPathProvider
    {
        public string GetDbFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}