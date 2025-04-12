
namespace TimeTracker.API.Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectResponse>?> DeleteProject(int id)
    {
        try
        {
            var result = await _projectRepository.DeleteProject(id);
            return result.Adapt<List<ProjectResponse>>();
        }
        catch (EntityNotFoundException)
        {
            return null;
        }
    }

    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        var result = await _projectRepository.GetAllProjects();
        return result.Adapt<List<ProjectResponse>>();
    }

    public async Task<ProjectResponse?> GetProjectById(int id)
    {
        var result = await _projectRepository.GetProjectById(id);
        if (result == null)
            return null;

        return result.Adapt<ProjectResponse>();
    }
}
