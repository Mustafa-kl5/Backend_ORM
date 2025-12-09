using Microsoft.AspNetCore.Mvc;
using ORM.Core.DTOs.Common;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

public class CommonController : BaseController
{
    private readonly ICommonService _commonService;

    public CommonController(ICommonService commonService)
    {
        _commonService = commonService;
    }

    /// <summary>
    /// Get all file extensions
    /// </summary>
    [HttpGet("getExtensions")]
    public async Task<IActionResult> GetExtensions()
    {
        var extensions = await _commonService.GetExtensionsAsync();
        return Success(extensions);
    }
}
