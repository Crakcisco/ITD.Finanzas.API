using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
        public class ConfiguracionesLogic : IConfiguracionesLogic
        {
            private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

            public ConfiguracionesLogic(IFinanzasRepositoryContext iConfiguracionesRepositoryContext)
            {
                _finanzasRepositoryContext = iConfiguracionesRepositoryContext;
            }
            public async Task<List<ConfiguracionesAttributes>> GetConfiguracionesAsync()
            {
                List<EntityConfiguracionesContext> configuraciones = await _finanzasRepositoryContext.ConfiguracionesContext.Get(true);
                List<ConfiguracionesAttributes> configuracionesAttributes = new List<ConfiguracionesAttributes>();
                foreach (var configuracion in configuraciones)
                {
                    configuracionesAttributes.Add(new ConfiguracionesAttributes() 
                    {
                        notificaciones_activas = configuraciones[0].notificaciones_activas,

                    });
                }
                return configuracionesAttributes;

            }

            public Task<List<ConfiguracionesAttributes>> GetConfiguracionesAsync(bool notificaciones_activas)
            {
                throw new NotImplementedException();
            }
        }
    }

