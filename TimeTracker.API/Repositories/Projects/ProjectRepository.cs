namespace TimeTracker.API.Repositories.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly DataContext _context;

    public ProjectRepository(DataContext context)
    {
        _context = context;
    }

    public Task<List<Project>> CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<List<Project>?> DeleteProject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _context.Projects
            .Include(p => p.ProjectDetails)
            .ToListAsync();
    }

    public async Task<Project?> GetProjectById(int id)
    {
        return await _context.Projects
            .Include(p => p.ProjectDetails)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<TimeEntry>> GetTimeEntriesByProject(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Project>?> UpdateProject(int id, Project project)
    {
        throw new NotImplementedException();
    }
}
