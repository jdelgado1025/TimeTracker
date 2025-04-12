namespace TimeTracker.API.Services.Projects;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse?> GetProjectById(int id);
    Task<List<ProjectResponse>?> DeleteProject(int id);
}
