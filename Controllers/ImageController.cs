using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

[Route("api/images")]
[ApiController]
public class ImageController : ControllerBase
{
    private static readonly List<string> GoogleDriveLinks = new List<string>
    {
        "https://drive.google.com/file/d/1WbjZYXfktT83c7giPhTUqH_EagrkC_10/view?usp=sharing",
        "https://drive.google.com/file/d/1A2B3C4D5E6F7G8H9IJKLMNOP/view?usp=sharing"
    };

    [HttpGet("get-images")]
    public IActionResult GetImages()
    {
        var images = GoogleDriveLinks.Select(link => new
        {
            OriginalUrl = link,
            DisplayUrl = ConvertGoogleDriveUrl(link)
        }).ToList();

        return Ok(images);
    }

    private string ConvertGoogleDriveUrl(string originalUrl)
    {
        var match = Regex.Match(originalUrl, @"/d/([^/]+)/");
        return match.Success ? $"https://drive.google.com/uc?export=view&id={match.Groups[1].Value}" : originalUrl;
    }
}
