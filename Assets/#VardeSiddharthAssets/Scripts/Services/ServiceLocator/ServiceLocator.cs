using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : GenericSingleton<ServiceLocator>
{
    Dictionary<TypesOfService, IGameService> services = new Dictionary<TypesOfService, IGameService>();

    public void RegesterService<T>(TypesOfService type, T service) where T : IGameService
    {
        if(!services.ContainsKey(type))
        {
            services.Add(type, service);
        }
    }

    public T GetService<T>(TypesOfService type) where T : class, IGameService
    {
        if(services.ContainsKey(type))
        {
            return (T)services[type];
        }

        return null;
    }
}
