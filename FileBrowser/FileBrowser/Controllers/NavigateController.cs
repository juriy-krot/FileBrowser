using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileBrowser.Models;
using System.IO;

namespace FileBrowser.Controllers
{
    public class NavigateController : ApiController
    {
        FileBrowserClass FB = new FileBrowserClass();

        // GET api/navigate
        public IEnumerable<FileBrowserClass> Get()
        {
            return FB.GetDrivs();
        }


        // GET api/navigate/5
        public IEnumerable<FileBrowserClass> Get(string path)
        {

           return FB.Enter(path);
           
        }

    }
}
