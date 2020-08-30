using Annexio.Controllers.HttpClients;
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

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}