using System;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathProvider))]
namespace ElVegetarianoFurio.iOS.Data
{
    public class PathProvider : IPathProvider
    {
        public string GetDbFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}