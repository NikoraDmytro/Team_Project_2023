using BLL.Models.Judge;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/judges")]
public class JudgesController: ControllerBase
{
    private readonly IJudgeService _judgeService;

    public JudgesController(IJudgeService judgeService)
    {
        _judgeService = judgeService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var judges = await _judgeService.GetAllAsync();
        return Ok(judges);
    }

    [HttpGet("{cardNum}", Name = nameof(GetByMembershipCardNum))]
    public async Task<IActionResult> GetByMembershipCardNum(int cardNum)
    {
        var judge = await _judgeService.GetByMembershipCardNumAsync(cardNum);
        return Ok(judge);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateJudgeModel createJudgeModel)
    {
        var judge = await _judgeService.CreateAsync(createJudgeModel);
        return CreatedAtRoute(nameof(GetByMembershipCardNum), new { cardNum = judge.MembershipCardNum }, judge);
    }

    [HttpPut("{cardNum}")]
    public async Task<IActionResult> Put(int cardNum, UpdateJudgeModel updateJudgeModel)
    {
        await _judgeService.UpdateAsync(cardNum, updateJudgeModel);
        return NoContent();
    }

    [HttpDelete("{cardNum}")]
    public async Task<IActionResult> Delete(int cardNum)
    {
        await _judgeService.DeleteAsync(cardNum);
        return NoContent();
    }
}