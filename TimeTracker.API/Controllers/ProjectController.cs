using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

	public ProjectController(IProjectService projectService)
	{
        _projectService = projectService;
    }

	[HttpGet]
	public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects()
	{
		return Ok(await _projectService.GetAllProjects());
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ProjectResponse>> GetProjectById(int id)
	{
		var result = await _projectService.GetProjectById(id);
		if(result is null)
			return NotFound("Project with ID not found or does not exist");

		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<List<ProjectResponse>>> DeleteProject(int id)
	{
		var result = await _projectService.DeleteProject(id);
		if (result is null)
			return NotFound($"Project with ID ({id}) not found or unable to delete");

		return Ok(result);
	}
}
