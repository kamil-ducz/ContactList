
using ContactList.Api.Dictionaries.Services;
using ContactList.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DictionaryController : ControllerBase
{
    private readonly IDictionaryService _dictionaryService;

    public DictionaryController(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet("contactCategories")]
    public IReadOnlyCollection<ContactCategory> GetAllContactCategories()
    {
        return _dictionaryService.GetAll<ContactCategory>();
    }

    [HttpGet("contactSubCategories")]
    public IReadOnlyCollection<ContactSubCategory> GetAllContactSubCategories()
    {
        return _dictionaryService.GetAll<ContactSubCategory>();
    }
}
