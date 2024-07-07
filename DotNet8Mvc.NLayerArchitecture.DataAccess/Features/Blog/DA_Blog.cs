using DotNet8Mvc.NLayerArchitecture.DbService.AppDbContexts;
using DotNet8Mvc.NLayerArchitecture.Mapper;
using DotNet8Mvc.NLayerArchitecture.Models.Features;
using DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8Mvc.NLayerArchitecture.DataAccess.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogs()
        {
            Result<BlogListResponseModel> responseModel;
            try
            {
                var lst = await _context.TblBlogs
                    .OrderByDescending(x => x.BlogId)
                    .ToListAsync();

                var dataLst = lst.Select(x => x.Map()).ToList();
                var model = new BlogListResponseModel(dataLst);

                responseModel = Result<BlogListResponseModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
        {
            Result<BlogResponseModel> responseModel;
            try
            {
                await _context.TblBlogs.AddAsync(requestModel.Map());
                int result = await _context.SaveChangesAsync();

                responseModel = Result<BlogResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }
    }
}
