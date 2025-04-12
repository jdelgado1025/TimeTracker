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

    public async Task<List<Project>?> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project is null)
            throw new EntityNotFoundException($"Entity with the given ID {id} was not found.");

        project.IsDeleted = true;
        project.DateDeleted = DateTime.Now;
        await _context.SaveChangesAsync();

        return await GetAllProjects();
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _context.Projects
            .Include(p => p.ProjectDetails)
            .Where(p => p.IsDeleted == false)
            .ToListAsync();
    }

    public async Task<Project?> GetProjectById(int id)
    {
        var project = await _context.Projects
            .Include(p => p.ProjectDetails)
            .Where (p => p.IsDeleted == false)
            .FirstOrDefaultAsync(p => p.Id == id);

        return project;
    }

    public async Task<Project?> GetTimeEntriesByProject(int id)
    {
        return await _context.Projects
            .Include(p => p.ProjectDetails)
            .Include(p => p.TimeEntries)
            .Where( p => p.IsDeleted == false)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<Project>?> UpdateProject(int id, Project project)
    {
        throw new NotImplementedException();
    }
}
