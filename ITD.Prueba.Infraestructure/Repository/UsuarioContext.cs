using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System;


namespace ITD.Finanzas.Infraestructure.Repository
{
    public class UsuarioContext : IUsuarioContext
    {
        private BDServices _bDServices;
        public UsuarioContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityUsuarioContext>> Get(string nombre)
        {
            DynamicParameters dp = new();
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityUsuarioContext>("UsuariosGET", dp);
            List<EntityUsuarioContext> usuarios = result.ToList();
            if (usuarios.Count > 0)
            {
                switch (usuarios[0].code)
                {
                    case (int)StatusResult.Success: return usuarios;
                    case (int)StatusResult.badRequest: return new List<EntityUsuarioContext>();
                    default: return new List<EntityUsuarioContext>();


                }

            }
            return new List<EntityUsuarioContext>();

        }
    }
}
