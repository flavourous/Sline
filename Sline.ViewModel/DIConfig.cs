using Sline.Model;
using Sline.ViewModel.ViewModels;
using Splat.Ninject;
using Ninject.Extensions.Conventions;

namespace Sline.ViewModel
{
    public static class DIConfig
    {
        public static void Configure()
        {
            var  kernel = new Ninject.StandardKernel();

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining<ISlineCommand>()
                 .SelectAllClasses()
                 .InheritedFrom<ISlineCommand>()
                 .BindSelection((t, b) => new[] { typeof(ISlineCommand) });
            });

            kernel.Bind<MainWindowViewModel>().ToSelf();

            kernel.UseNinjectDependencyResolver();
        }
    }
}
