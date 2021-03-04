using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using TenmoServer.DAO;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private ITransferDAO TransferDAO;

        public TransfersController (ITransferDAO transferDAO)
        {
            this.TransferDAO = transferDAO;
        }

        // Transfers AKA List
        [HttpGet]
        public List<Transfer> GetTransfers()
        {
            List<Transfer> transfers = TransferDAO.GetTransfers();
           
            return transfers;
        }

        //Transfers
        [HttpPost]
        public ActionResult<Transfer> CreateTransfer(Transfer newTrasfer)
        {
            Transfer transfer = TransferDAO.CreateTransfer(newTrasfer);
            return Created($"/transfers/{transfer.TransferId}", transfer);
        }

        //Transfers/{id}

    }
}
