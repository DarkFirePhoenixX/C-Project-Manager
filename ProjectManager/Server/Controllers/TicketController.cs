using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Shared.Dto;
using ProjectManager.Shared.Interfaces;

namespace ProjectManager.Server.Controllers {
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase {

        public TicketController(ITicket ticketModel) {
            TicketModel = ticketModel;
        }

        [Inject]
        protected ITicket TicketModel { get; set; }
        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                List<TicketDto> tickets = await TicketModel.List();
                return Ok(tickets);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) {
            try
            {
                TicketDto tickets = await TicketModel.Get(id);
                return Ok(tickets);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("project/{projectId:guid}")]
        public async Task<IActionResult> GetByProject(Guid projectId) {
            try
            {
                List<TicketDto> tickets = await TicketModel.ListTicketsByProject(projectId);
                return Ok(tickets);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("project/{userId}")]
        public async Task<IActionResult> GetByUser(String userId) {
            try
            {
                List<TicketDto> tickets = await TicketModel.ListTicketsByUser(userId);
                return Ok(tickets);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketDto ticket) {
            try
            {
                TicketDto newTicket = await TicketModel.Create(ticket);
                return Ok(newTicket);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TicketDto ticket) {
            try
            {
                TicketDto tickets = await TicketModel.Update(id, ticket);
                return Ok(tickets);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) {
            try
            {
                Boolean deleted = await TicketModel.Delete(id);
                return Ok(deleted);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
