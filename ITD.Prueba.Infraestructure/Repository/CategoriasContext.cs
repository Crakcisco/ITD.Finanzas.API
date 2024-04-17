
using Dapper;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System.Xml.XPath;
using System.Linq;
using ITD.Finanzas.Domain.Enums;


namespace ITD.Finanzas.Infraestructure.Repository
{
    public class CategoriasContext : ICategoriasContext
    {
        private BDServices _bDServices;
        public CategoriasContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityCategoriasContext>> Get(string nombre)
        {
            DynamicParameters dp = new();
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityCategoriasContext>("CategoriasGET", dp);
            List<EntityCategoriasContext> categorias = result.ToList();
            if (categorias.Count > 0)
            {
                switch (categorias[0].code)
                {
                    case (int)StatusResult.Success:  return categorias; 
                    case (int)StatusResult.badRequest: return new List<EntityCategoriasContext>();
                    default: return new List<EntityCategoriasContext>();


                }

            }
            return new List<EntityCategoriasContext>();

        }
    }                 
}   
