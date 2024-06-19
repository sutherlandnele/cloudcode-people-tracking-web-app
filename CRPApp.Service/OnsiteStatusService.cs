using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRPApp.Data;
using CRPApp.Data.DBModels;
using CRPApp.Data.ViewModels;
using AutoMapper;
using CRPApp.Service.Mappings;


namespace CRPApp.Service
{
    public class OnsiteStatusService: IDisposable
    {
        private readonly CRPDbContext _crpAppEntities;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;


        public OnsiteStatusService(CRPDbContext entities)
        {
            this._crpAppEntities = entities;

            _config = new MapperConfiguration(cfg => {
               cfg.AddProfile<DomainToViewModelMappingProfile>();
               cfg.AddProfile<ViewModelToDomainMappingProfile>();

            });
            _mapper = _config.CreateMapper();

        }

        public IEnumerable<OnsiteStatusViewModel> Read()
        {
            var vm =  _mapper.Map<IEnumerable<CRPOnsiteStatus>, IEnumerable<OnsiteStatusViewModel>>(_crpAppEntities.CRPOnsiteStatuses.ToList());
            return vm;
        }



        public void Update(OnsiteStatusViewModel onsiteStatus)
        {
            var md = _mapper.Map<OnsiteStatusViewModel, CRPOnsiteStatus>(onsiteStatus);

            _crpAppEntities.CRPOnsiteStatuses.Attach(md);
            _crpAppEntities.Entry(md).State = EntityState.Modified;
            _crpAppEntities.SaveChanges();
        }



        public void Dispose()
        {
            _crpAppEntities.Dispose();

        }
    }
}
