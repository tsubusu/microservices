﻿using Catalogo.Api.Data;
using Catalogo.Api.Repository;

namespace Catalogo.Api.Config
{
    public static class InjecaoDependenciaConfig
    {
        public static void CriarInjecao(IServiceCollection services)
        {
            services.AddScoped<ICatalogoContext, CatalogoContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
