using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODM.Models;
using ODM.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRest.Controllers;

[ApiController]
[Route("[Controller]")]
public class BlogController : ControllerBase
{
    private readonly ILogger<BlogController> _logger;

    public BlogController(ILogger<BlogController> logger){
        _logger = logger;
    }

    [HttpGet( Name ="blogs")]
    public List<Blog> Get()
    {
        var db  = new BlogContext();
        return db.Blogs.ToList<Blog>();
    }

    [HttpPost]
    public Dictionary<string, string> Add(Blog blog)
    {

        Dictionary<string, string> response  = new Dictionary<string , string>();

        try{

            var db = new BlogContext();
            db.Add( new Blog(){
                    id = blog.id,
                    title = blog.title,
                    content = blog.content
                    });
            db.SaveChanges();
            response.Add("response" ,"OK");
            return response;
        }catch(Exception e){
            response.Add("error", "true");
            response.Add("message", e.Message);
            return response;
        }

    }
}
