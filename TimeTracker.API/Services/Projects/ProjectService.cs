
namespace TimeTracker.API.Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        var result = await _projectRepository.GetAllProjects();
        return result.Adapt<List<ProjectResponse>>();
    }
}
