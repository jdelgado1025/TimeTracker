namespace TimeTracker.API.Services.Projects;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
}
