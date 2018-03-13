using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.AutoMapper.Profiles.BLLToModel;
using TestProject.DLL;
using TestProject.Model;

namespace TestProject.BLL.BusinessCommands.FakturaCommands
{
    public class CreateFakturaCommandHandler : ICommandHandler<CreateFakturaCommand>
    {
        private UnitOfWork _unitOfWork;

        public CreateFakturaCommandHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreateFakturaCommand command)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FakturaBLLToModelProfile>();
            });
            var mapper = new Mapper(config);
            Faktura faktura = mapper.DefaultContext.Mapper.Map<Faktura>(command.Faktura);

            _unitOfWork.FakturaRepository.Insert(faktura);

            _unitOfWork.Save();
        }
    }
}
