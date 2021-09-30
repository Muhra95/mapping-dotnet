using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DB.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.CodingChallenge.Backend.Mapping.Data.DTO.Blocks
{
    public class ArticleBlockToArticleDtoBlock
    {
        

        public List<ArticleBlockDto> convertArticleBlockToArticleDtoBlock(Article article)
        {
            List<ArticleBlockDto> result = new List<ArticleBlockDto>();
            foreach (ArticleBlock articleBlock in article.Blocks)
            {
                var typ = articleBlock.GetType();
                TextBlock textBlock = new TextBlock();
                GalleryBlock galleryBlock = new GalleryBlock();
                ImageBlock imageBlock = new ImageBlock();
                VideoBlock videoBlock = new VideoBlock();
                

                if (typ == textBlock.GetType())
                {
                    TextBlockDto textBlockDto = new TextBlockDto();
                    textBlockDto.Text= (String)typ.GetProperty("Text").GetValue(articleBlock);
                    textBlockDto.SortIndex = articleBlock.SortIndex;
                    result.Add(textBlockDto);
                }

                if (typ == imageBlock.GetType())
                {
                    ImageBlockDto imageBlockDto = new ImageBlockDto();
                    //ImageDtoToImge
                    //ImageSizeDtoTo ImageSize
                    Image image = (Image)typ.GetProperty("Image").GetValue(articleBlock);

                    imageBlockDto.Image = ConvertImageToImageDto(image);
                    imageBlockDto.SortIndex = articleBlock.SortIndex;
                    result.Add(imageBlockDto);
                }

                if (typ == galleryBlock.GetType())
                {
                    GalleryBlockDto galleryBlockDto = new GalleryBlockDto();
                    galleryBlockDto.Images = new List<ImageDto>();
                    List<ImageDto> imageDtos = new List<ImageDto>();
                    var images = (List<Image>)typ.GetProperty("Images").GetValue(articleBlock);
                    foreach (Image image in images)
                    {
                        galleryBlockDto.Images.Add(ConvertImageToImageDto(image));
                    }
                    galleryBlockDto.SortIndex = articleBlock.SortIndex;
                    result.Add(galleryBlockDto);


                }
               
                if (typ == videoBlock.GetType())
                {
                    VideoBlockDto videoBlockDto = new VideoBlockDto();
                    videoBlockDto.Url = (String)typ.GetProperty("Url").GetValue(articleBlock);
                    videoBlockDto.Type = (VideoBlockType)typ.GetProperty("Type").GetValue(articleBlock);
                    videoBlockDto.SortIndex = articleBlock.SortIndex;
                    result.Add(videoBlockDto);

                }
            }
            return result;
        }

        public ImageDto ConvertImageToImageDto(Image image)
        {
            ImageDto imageDto = new ImageDto();
            if (image != null)
            {
                imageDto.Id = image.Id;
                imageDto.Url = image.Url;
                imageDto.ImageSize = image.ImageSize;
                imageDto.LastModified = image.LastModified;
                imageDto.LastModifiedBy = image.LastModifiedBy;
                return imageDto;
            }

                return null;

        }
    }
}
