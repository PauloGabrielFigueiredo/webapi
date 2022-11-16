using System.Net;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using webapi.Data;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using System.Drawing;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace webapi.Controllers;

public class ImageController : BaseApiController
{

    // public readonly IConfiguration _configuration;
    // public readonly ILogger<ImageController> _logger;
    // public readonly DataContext _dataContext;
    // private readonly IMapper _mapper;

    // public ImageController(
    //     IConfiguration config, IMapper mapper,
    //     ITokenService tokenService, ILogger<ImageController> logger,
    //     DataContext dataContext
    //          )
    // {
    //     _configuration = config;
    //     _logger = logger;
    //     _dataContext = dataContext;
    //     _mapper = mapper;
    // }

    //   [HttpPost("add-photo"), DisableRequestSizeLimit]
    //     public async Task<ActionResult> AddPhoto(IFormFile file)
    //     {

    //     byte[] image = null;
    //     byte[] image_small = null;

    //         if(file == null)
    //         { 
    //             return BadRequest("Problem addding photo");
    //         }
    //         if (file.Length > 0)
    //         {
    //             using (var ms = new MemoryStream())
    //             {
    //                 file.CopyTo(ms);
    //                 image = ms.ToArray();
    //                 image_small = ResizeImage(image);
    //             }
    //         }
    //         return BadRequest("Problem addding photo");
    //     }

    //     [NonAction]
    //     public byte[] ResizeImage(byte[] byteImageIn)
    //     {
    //         byte[] currentByteImageArray = byteImageIn;
    //         double scale = 1f;
    //         MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
    //         Image fullsizeImage = Image.FromStream(inputMemoryStream);
    //         // 50  000 bytes  = 0.05 megabytes
    //         // 500 0000 bytes = 5 megabytes
    //         while (currentByteImageArray.Length > 5000000)
    //         {
    //             Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
    //             MemoryStream resultStream = new MemoryStream();
    //             fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);
    //             currentByteImageArray = resultStream.ToArray();
    //             resultStream.Dispose();
    //             resultStream.Close();
    //             scale -= 0.05f;
    //         }
    //         return currentByteImageArray;
    //     }

}