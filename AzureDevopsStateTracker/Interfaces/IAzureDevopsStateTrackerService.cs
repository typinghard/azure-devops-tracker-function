using AzureDevopsStateTracker.DTOs;
using AzureDevopsStateTracker.DTOs.Create;
using AzureDevopsStateTracker.DTOs.Update;
using System.Threading.Tasks;

namespace AzureDevopsStateTracker.Interfaces
{
    public interface IAzureDevopsStateTrackerService
    {
        Task Create(CreateWorkItemDTO createDto, bool addWorkItemChange = true);
        Task Update(UpdatedWorkItemDTO updateDto);
        Task<WorkItemDTO> GetByWorkItemId(string workItemId);
    }
}