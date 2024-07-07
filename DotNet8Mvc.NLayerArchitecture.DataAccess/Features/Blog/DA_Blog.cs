using DotNet8Mvc.NLayerArchitecture.DbService.AppDbContexts;
using DotNet8Mvc.NLayerArchitecture.Mapper;
using DotNet8Mvc.NLayerArchitecture.Models.Enums;
using DotNet8Mvc.NLayerArchitecture.Models.Features;
using DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;
using DotNet8Mvc.NLayerArchitecture.Models.Resources;
using DotNet8Mvc.NLayerArchitecture.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNet8Mvc.NLayerArchitecture.DataAccess.Features.Blog;

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
            var lst = await _context.TblBlogs.OrderByDescending(x => x.BlogId).ToListAsync();

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

    public async Task<Result<BlogModel>> GetBlogById(int id)
    {
        Result<BlogModel> responseModel;
        try
        {
            var item = await _context.TblBlogs.FindAsync(id);
            if (item is null)
            {
                responseModel = Result<BlogModel>.FailureResult(
                    MessageResource.NotFound,
                    EnumStatusCode.NotFound
                );
                goto result;
            }

            var model = item.Map();
            responseModel = Result<BlogModel>.SuccessResult(model);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogModel>.FailureResult(ex);
        }

    result:
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

    public async Task<Result<BlogResponseModel>> PatchBlog(BlogRequestModel requestModel, int id)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            var item = await _context.TblBlogs.FindAsync(id);
            if (item is null)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(
                    MessageResource.NotFound,
                    EnumStatusCode.NotFound
                );
                goto result;
            }

            if (!requestModel.BlogTitle.IsNullOrEmpty())
            {
                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!requestModel.BlogAuthor.IsNullOrEmpty())
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }

            if (!requestModel.BlogContent.IsNullOrEmpty())
            {
                item.BlogContent = requestModel.BlogContent;
            }

            _context.Entry(item).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

    result:
        return responseModel;
    }

    public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            var item = await _context.TblBlogs.FindAsync(id);
            if (item is null)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(
                    MessageResource.NotFound,
                    EnumStatusCode.NotFound
                );
                goto result;
            }

            _context.TblBlogs.Remove(item);
            int result = await _context.SaveChangesAsync();

            responseModel = Result<BlogResponseModel>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

    result:
        return responseModel;
    }
}
