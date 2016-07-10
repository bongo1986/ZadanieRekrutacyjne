using BusinessLogic;
using BusinessLogic.Dto;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationLayer.Controllers
{

    public class DevContractController : ApiController
    {
        private IDevContractsService _devContractsService;

        public DevContractController(IDevContractsService devContractsService)
        {
            _devContractsService = devContractsService;
        }
        // GET: api/DevContract
        public GridPageInfoOutputDto Get([FromUri]GridFilterInputDto filter)
        {
            if (ModelState.IsValid)
            {
                return _devContractsService.GetGridPage(filter);
            }
            else
            {
                return null;
            }
        }

        // POST: api/DevContract
        public void Put([FromBody]DevContractInputDto newDevContract)
        {
            if (ModelState.IsValid)
            {
                _devContractsService.Add(newDevContract);
            }
        }

      

       
    }
}
