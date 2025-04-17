namespace TimeTracker.API.Repositories.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly DataContext _context;

    public ProjectRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> CreateProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return await GetAllProjects();
    }

    public async Task<List<Project>?> DeleteProject(int id)
    {
        var project = await _context.Projects
            .Where(p => p.IsDeleted == false)
            .FirstOrDefaultAsync(p => p.Id == id);

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

    public async Task<List<Project>?> UpdateProject(int id, Project project)
    {
        var projectEntry = await _context.Projects
            .Include(p => p.ProjectDetails)
            .Where(p => p.IsDeleted == false)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (projectEntry is null)
            throw new EntityNotFoundException($"Entity with ID {id} was not found.");

        projectEntry.Name = project.Name;

        if(project.ProjectDetails.Description is not null)
            projectEntry.ProjectDetails.Description = project.ProjectDetails.Description;

        if(project.ProjectDetails.StartDate is not null)
            projectEntry.ProjectDetails.StartDate = project.ProjectDetails.StartDate;

        if(project.ProjectDetails.EndDate is not null)
            projectEntry.ProjectDetails.EndDate = project.ProjectDetails.EndDate;

        projectEntry.DateUpdated = DateTime.Now;

        await _context.SaveChangesAsync();

        return await GetAllProjects();
    }
}
