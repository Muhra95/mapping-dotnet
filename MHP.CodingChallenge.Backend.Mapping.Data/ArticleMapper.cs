using System;
using System.Collections.Generic;
using System.Linq;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DB.Blocks;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO.Blocks;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleMapper
    {
        ArticleBlockToArticleDtoBlock articleBlockToArticleDtoBlock = new ArticleBlockToArticleDtoBlock();
        public ArticleDto Map(Article article)
        {

            ArticleDto articleDto = new ArticleDto();
            ArticleBlockDto articleBlockDto = new ArticleBlockDto();
            articleDto.Id = article.Id;
            articleDto.Author = article.Author;
            articleDto.Title = article.Title;
            articleDto.Description = article.Description;
            articleDto.Blocks =  articleBlockToArticleDtoBlock.convertArticleBlockToArticleDtoBlock (article).OrderBy(o => o.SortIndex).ToList();
            



            return articleDto;
        }


        public Article Map(ArticleDto articleDto)
        {
            // Nicht Teil dieser Challenge.
            return new Article();
        }
    }
}
