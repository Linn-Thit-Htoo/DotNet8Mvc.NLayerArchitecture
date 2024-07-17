namespace DotNet8Mvc.NLayerArchitecture.BusinessLogic.Features.Blog;

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

    public async Task<Result<BlogModel>> GetBlogById(int id)
    {
        Result<BlogModel> responseModel;
        try
        {
            if (id <= 0)
            {
                responseModel = Result<BlogModel>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            responseModel = await _dA_Blog.GetBlogById(id);
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
            responseModel = requestModel.IsValid();
            if (responseModel.IsError)
                goto result;

            responseModel = await _dA_Blog.CreateBlog(requestModel);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        result:
        return responseModel;
    }

    public async Task<Result<BlogResponseModel>> PatchBlog(BlogRequestModel requestModel, int id)
    {
        Result<BlogResponseModel> responseModel;
        try
        {
            if (id <= 0)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            responseModel = await _dA_Blog.PatchBlog(requestModel, id);
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
            if (id <= 0)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            responseModel = await _dA_Blog.DeleteBlog(id);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex);
        }

        result:
        return responseModel;
    }
}
