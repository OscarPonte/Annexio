using Annexio.Controllers.HttpClients;
using Annexio.CountiresUriBuilder;
using Annexio.Repository.CountriesUriBuilder;
using Annexio.Repository.Manager;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Annexio
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			container.RegisterType<ICountriesHttpClient, CountriesHttpClient>();
			container.RegisterType<IRegionsHttpClient, RegionsHttpClient>();
			container.RegisterType<ISubregionsHttpClient, SubregionsHttpClient>();
			container.RegisterType<ICountriesUriBuilder, CountriesUriBuilder>();
			container.RegisterType<ICountriesManager, CountriesManager>();
			container.RegisterType<IRegionsManager, RegionsManager>();




			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}