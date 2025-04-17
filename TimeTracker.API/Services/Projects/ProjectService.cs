
namespace TimeTracker.API.Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectResponse>> CreateProject(ProjectRequest request)
    {
        var newProject = request.Adapt<Project>();
        var result = await _projectRepository.CreateProject(newProject);

        return result.Adapt<List<ProjectResponse>>();
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

    public async Task<List<ProjectResponse>?> UpdateProject(int id, ProjectRequest request)
    {
        try
        {
            var updateProject = request.Adapt<Project>();
            var result = await _projectRepository.UpdateProject(id, updateProject);

            return result.Adapt<List<ProjectResponse>>();
        }
        catch (EntityNotFoundException)
        {
            return null;
        }
    }
}
