namespace DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;

public class BlogListResponseModel
{
    public List<BlogModel> DataLst { get; set; }

    public BlogListResponseModel(List<BlogModel> dataLst)
    {
        DataLst = dataLst;
    }
}
