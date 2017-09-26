using System.Reflection;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.UWP.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathProvider))]
namespace ElVegetarianoFurio.UWP.Data
{
    public class PathProvider : IPathProvider
    {
        public string GetDbFolder()
        {
            return "";
        }
    }
}