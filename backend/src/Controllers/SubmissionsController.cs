using FormAPI.Mappers;
using FormAPI.Models;
using FormAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FormAPI.Controllers;

[ApiController]
[Route("/api/submissions/")]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionsController(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    /// <summary>
    /// Gets all submissions in the database.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubmissionDto>>> GetAll()
    {
        var entityList = await _submissionRepository.GetAll();
        var dtoList = entityList.Select(SubmissionMappers.ToDto).ToList();
        return Ok(dtoList);
    }

    /// <summary>
    /// Gets a single submission. Not used.
    /// </summary>
    [HttpGet("{submissionId}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult<SubmissionDto>> GetSingle(Guid submissionId)
    {
        var entity = await _submissionRepository.GetSingle(submissionId);

        if (entity == null)
        {
            return NotFound();
        }

        var dto = SubmissionMappers.ToDto(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Gets all submissions belonging to a form.
    /// </summary>
    [HttpGet("/api/forms/{formId:guid}/submissions")]
    public async Task<ActionResult<IEnumerable<SubmissionDto>>> GetFormSubmissions(Guid formId)
    {
        var entityList = await _submissionRepository.GetFormSubmissions(formId);
        var dtoList = entityList.Select(SubmissionMappers.ToDto).ToList();
        return Ok(dtoList);
    }

    /// <summary>
    /// Stores a new submission.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<SubmissionDto>> Create([FromBody] SubmissionDto dto)
    {
        var entity = SubmissionMappers.ToEntity(dto);
        var result = await _submissionRepository.Create(entity);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a single submission. Not in use.
    /// </summary>
    [HttpDelete("{submissionId}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult<SubmissionDto>> Delete(Guid submissionId)
    {
        var entity = await _submissionRepository.Delete(submissionId);

        if (entity == null)
        {
            return NotFound();
        }

        var dto = SubmissionMappers.ToDto(entity);
        return Ok(dto);
    }
}