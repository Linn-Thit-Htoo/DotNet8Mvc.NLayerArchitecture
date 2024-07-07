﻿using DotNet8Mvc.NLayerArchitecture.DataAccess.Features.Blog;
using DotNet8Mvc.NLayerArchitecture.Models.Features;
using DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8Mvc.NLayerArchitecture.BusinessLogic.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogs()
        {
            return await _dA_Blog.GetBlogs();
        }
    }
}
