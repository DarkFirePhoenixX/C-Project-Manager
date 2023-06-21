using ProjectManager.Shared.Dto;

namespace ProjectManager.Shared.Interfaces
{
    public interface ITicket
    {
        Task<List<TicketDto>> List();
        Task<List<TicketDto>> ListTicketsByProject(Guid projectId);
        Task<List<TicketDto>> ListTicketsByUser(string userId);
        Task<TicketDto> Get(Guid ticketId);
        Task<TicketDto> Create(TicketDto ticket);
        Task<TicketDto> Update(Guid ticketId, TicketDto ticket);
        Task<bool> Delete(Guid ticketId);
    }
}
