using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.BusinessCommands.FakturaCommands;
using TestProject.BLL.BusinessModels;
using TestProject.BLL.BusinessQueries.FakturaQueries;
using TestProject.DLL;

namespace TestProject.BLL.BusinessServices
{
    public class FakturaService
    {
        public string CreateFaktura(Faktura faktura)
        {
            UnitOfWork uow;
            CreateFakturaCommand command = new CreateFakturaCommand()
            {
                Faktura = faktura
            };
            using (uow = new UnitOfWork())
            {
                CreateFakturaCommandHandler handler = new CreateFakturaCommandHandler(uow);
                try
                {
                    handler.Handle(command);
                    return "OK";
                }
                catch
                {
                    return "Not OK";
                }
            }
        }

        public List<Faktura> GetAllFakture()
        {
            UnitOfWork uow;
            GetAllFaktureQuery query = new GetAllFaktureQuery();
            using (uow = new UnitOfWork())
            {
                GetAllFaktureQueryHandler handler = new GetAllFaktureQueryHandler(uow);
                try
                {
                    var fakture = handler.Handle(query);
                    return fakture;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
