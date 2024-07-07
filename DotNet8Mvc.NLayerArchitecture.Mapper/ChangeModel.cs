using DotNet8Mvc.NLayerArchitecture.DbService.AppDbContexts;
using DotNet8Mvc.NLayerArchitecture.Models.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8Mvc.NLayerArchitecture.Mapper
{
    public static class ChangeModel
    {
        public static BlogModel Map(this TblBlog dataModel)
        {
            return new BlogModel
            {
                BlogId = dataModel.BlogId,
                BlogTitle = dataModel.BlogTitle,
                BlogAuthor = dataModel.BlogAuthor,
                BlogContent = dataModel.BlogContent
            };
        }

        public static TblBlog Map(this BlogRequestModel requestModel)
        {
            return new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
        }
    }
}
