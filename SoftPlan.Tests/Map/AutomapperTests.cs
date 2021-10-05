using AutoMapper;
using Softplan.Domain.Dto.Category;
using Softplan.Domain.Entities;
using Softplan.Domain.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Tests.Map
{
    public class AutomapperTests
    {
        public static IMapper _mapper;
        public AutomapperTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {   
                    mc.AddProfile(new EntityToDto());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
