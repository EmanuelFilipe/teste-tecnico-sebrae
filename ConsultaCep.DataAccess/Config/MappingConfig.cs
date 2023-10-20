using AutoMapper;
using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCep.DataAccess.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ContaDTO, Conta>();
                config.CreateMap<Conta, ContaDTO>();
            });

            return mappingConfig;
        }
    }
}
