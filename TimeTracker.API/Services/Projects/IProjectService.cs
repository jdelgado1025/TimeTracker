namespace TimeTracker.API.Services.Projects;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse?> GetProjectById(int id);
    Task<ProjectTimeEntriesResponse?> GetProjectWithTimeEntries(int id);
    Task<List<ProjectResponse>?> DeleteProject(int id);
    Task<List<ProjectResponse>> CreateProject(ProjectRequest request);
    Task<List<ProjectResponse>?> UpdateProject(int id, ProjectRequest request);
}
